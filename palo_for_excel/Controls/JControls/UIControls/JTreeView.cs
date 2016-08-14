/*
 *	JTreeView class - TreeView extension
 *
 *	(c) Junction BI LLC
 *
 *	Revision History -
 *
 *	03/21/14 JMM Initial Version, replaces DotNetMagic Tree Control
 *
*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using System.Text;

namespace JControls
{
/// <summary>
/// This class provides an extension of the Multi-Select TreeView which can also display groupings
/// separated at root nodes - the root node provides a header and expansion area.
/// </summary>
/// <remarks>
/// This is not yet a complete implementation - only the features needed for the Palo designer
/// have been added so far.
/// </remarks>
public class JTreeView : MSTreeView
	{

	#region Properties used for drawing groups headed by root nodes

	/// <summary>When set, provides grouping by separating at root nodes.</summary>
	[Browsable(true)]
	[Category("Groups")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
	public bool GroupByRootNodes
		{
		get { return _groupByRootNodes; }
		set { if (_groupByRootNodes != value) {_groupByRootNodes = value; OnGroupByRootNodesChanged();}}
		}
	private bool _groupByRootNodes;

	/// <summary>Whether to collapse all other nodes when a root node is selected</summary>
	[Browsable(true)]
	[Category("Groups")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
	public bool GroupAutoCollapse {get;set;}

	/// <summary>Background color for group root nodes</summary>
	[Browsable(true)]
	[Category("Groups")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
	public Color GroupBackColor {get;set;}

	/// <summary>Background color for selected group root nodes</summary>
	[Browsable(true)]
	[Category("Groups")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
	public Color GroupSelectedBackColor {get;set;}

	/// <summary>Foreground color for group root nodes</summary>
	[Browsable(true)]
	[Category("Groups")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
	public Color GroupForeColor {get;set;}

	/// <summary>Foreground color for selected group root nodes</summary>
	[Browsable(true)]
	[Category("Groups")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
	public Color GroupSelectedForeColor {get;set;}

	/// <summary>Font group root node text</summary>
	[Browsable(true)]
	[Category("Groups")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
	public Font GroupFont {get;set;}

	/// <summary>Font for selected root node.</summary>
	[Browsable(true)]
	[Category("Groups")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
	public Font GroupSelectedFont {get;set;}


	//	Constants used for adjusting node height and position
	//	These improve the appearance when drawing
	private const int addNodeHeight = 7;
	private const int addTextTop = 3;
	private const int addTextLeft = 2;

	#endregion


	#region Additional functions defined for compatibility with older controls

	/// <summary>
	/// Defined for compatability
	/// </summary>
	public void DeselectAll()
		{UnselectAllNodes();}

	/// <summary>
	/// Select a node
	/// </summary>
	/// <param name="tn"></param>
	/// <returns></returns>
	public bool SelectNode(TreeNode tn)
		{
		return SelectNode(tn, true, TreeViewAction.Unknown);
		}

	/// <summary>
	/// Select or Unselect a node
	/// </summary>
	/// <param name="tn"></param>
	/// <param name="DoSelect"></param>
	/// <returns></returns>
	public bool SelectNode(TreeNode tn, bool DoSelect)
		{
		return SelectNode(tn, DoSelect, TreeViewAction.Unknown);
		}

	#endregion


	#region Additional helper functions

	/// <summary>
	/// Returns text of all selected nodes
	/// </summary>
	/// <returns></returns>
	public string[] GetSelectedNodeLabels()
		{
		NodesCollection SelNodes = SelectedNodes;
		string[] Labels = new string[SelNodes.Count];
		for (int i=0; i<SelNodes.Count; i++)
			Labels[i] = SelNodes[i].Text;
		return Labels;
		}

	/// <summary>
	/// Clear all nodes in tree
	/// </summary>
	/// <remarks>
	/// Can use instead of Nodes.Clear to insure selections cleared first.
	/// </remarks>
	public void ClearNodes()
		{
		htblSelectedNodes.Clear();
		this.Nodes.Clear();
		}
	#endregion


	#region Functions to handle node drawing and selection for groups

	/// <summary>
	/// Handles node checked event
	/// </summary>
	/// <param name="e"></param>
	protected override void OnAfterCheck(TreeViewEventArgs e)
		{
		base.OnAfterCheck(e);

		//	If node is a radio button, uncheck all other nodes under the same parent
		if (e.Node.Checked && e.Node is JNode && ((JNode)e.Node).CheckStates == JNode.NodeCheckStates.Radio && e.Node.Parent != null)
			{
			foreach (JNode n in e.Node.Parent.Nodes)
				{
				if (n != e.Node && n.CheckStates == JNode.NodeCheckStates.Radio)
					n.Checked = false;
				}
			}
		}

	/// <summary>
	/// Handles change in the GroupByRootNodes property.
	/// </summary>
	protected virtual void OnGroupByRootNodesChanged()
		{
		if (_groupByRootNodes)
			{
			//	To implement groups, root nodes are drawn as bars across the tree view.
			//	Clicking on one expands it.
			DrawMode = TreeViewDrawMode.OwnerDrawAll;
			}
		else
			DrawMode = TreeViewDrawMode.Normal;
		}

	/// <summary>
	/// Handle control creation.
	/// </summary>
	protected override void OnCreateControl()
		{
		//	Add additional item height when grouping at root nodes:
		if (_groupByRootNodes && this.ItemHeight < this.Font.Height + addNodeHeight)
			this.ItemHeight = this.Font.Height + addNodeHeight;
		base.OnCreateControl();
		}

	/// <summary>
	/// Draw nodes, handle special cases
	/// </summary>
	/// <param name="e"></param>
	protected override void OnDrawNode(DrawTreeNodeEventArgs e)
		{

		/*-----------------------------*/
		/* Draw node as a group header */
		/*-----------------------------*/

		if (_groupByRootNodes && e.Node.Parent == null)
			{
			Rectangle Area = e.Bounds;	//new Rectangle(e.Bounds.Left, e.Node.Bounds.Top, e.Node.TreeView.Bounds.Width - e.Bounds.Left, e.Node.Bounds.Height);

			//	Draw the background area and border:
			using (Brush b = new SolidBrush(e.Node.IsExpanded ? this.GroupSelectedBackColor : this.GroupBackColor))
				{
				e.Graphics.FillRectangle(b, Area.Left, Area.Top, Area.Width, Area.Height);
				e.Graphics.DrawLine(Pens.Black, Area.Left, Area.Top, Area.Right, Area.Top);
				if (e.Node.NextNode == null && !e.Node.IsExpanded)
					e.Graphics.DrawLine(Pens.Black, Area.Left, Area.Bottom-1, Area.Right, Area.Bottom-1);
				}

			 // Draw the node text:
			Font nodeFont = e.Node.NodeFont;
			if (nodeFont == null) nodeFont = this.Font;
			if (e.Node.IsExpanded && GroupSelectedFont != null)
				nodeFont = GroupSelectedFont;
			Brush textBrush = SystemBrushes.FromSystemColor(this.ForeColor);
			e.Graphics.DrawString(e.Node.Text, nodeFont, textBrush, e.Bounds.Left+addTextLeft, e.Bounds.Top+addTextTop);

			// Draw chevron:
			int x = Area.Width - Area.Height;
			int y = Area.Top + addNodeHeight;
			int h = (Area.Height/2 - addNodeHeight)*2;
			int w = h+2;
			Point[] pts = new Point[3];
			if (e.Node.IsExpanded)
				{
				pts[0] = new Point(x, y+h);
				pts[1] = new Point(x+w/2, y);
				pts[2] = new Point(x+w, y+h);
				}
			else
				{
				pts[0] = new Point(x, y);
				pts[1] = new Point(x+w/2, y+h);
				pts[2] = new Point(x+w, y);
				}
			e.Graphics.DrawLines(Pens.Black, pts);
			}


		/*-----------------------------*/
		/* Draw node as a radio-button */
		/*-----------------------------*/

		else if (CheckBoxes && e.Node is JNode && ((JNode)e.Node).CheckStates == JNode.NodeCheckStates.Radio && !e.Bounds.IsEmpty)
			{
			JNode node = (JNode)e.Node;
			Font nodeFont = e.Node.NodeFont;
			if (nodeFont == null) nodeFont = this.Font;
			bool isChecked = e.Node.Checked;

			//	Draw the background area:
			using (Brush b = new SolidBrush(BackColor))
				{e.Graphics.FillRectangle(b, e.Bounds);}

			// Determine text color/brush
			Brush textBrush = SystemBrushes.FromSystemColor(this.ForeColor);

			// Determine bounds for text and radio button
			RadioButtonState state = isChecked ? RadioButtonState.CheckedNormal : RadioButtonState.UncheckedNormal;
			Size glyphSize = RadioButtonRenderer.GetGlyphSize(e.Graphics, state);
			Point glyphLocation = e.Node.Bounds.Location;
			glyphLocation.Y += (e.Bounds.Height - glyphSize.Height) / 2;
			Rectangle bounds = new Rectangle(e.Node.Bounds.X + glyphSize.Width, e.Bounds.Y+addTextTop, e.Bounds.Width - glyphSize.Width - e.Node.Bounds.X, e.Bounds.Height-addTextTop);

			// Draws the radio button and text
			RadioButtonRenderer.DrawRadioButton(e.Graphics, glyphLocation, state);
			e.Graphics.DrawString(e.Node.Text, nodeFont, textBrush, bounds);
			}

		else
			{
			e.DrawDefault = true;
			base.OnDrawNode(e);
			}
		}

	/// <summary>
	/// Handle the mouse click event
	/// </summary>
	/// <param name="e"></param>
	protected override void OnMouseClick(MouseEventArgs e)
		{
		if (e.Button == MouseButtons.Left && _groupByRootNodes)
			{
			//	Clicking on a root node selects it
			TreeNode node = GetNodeAt(new Point(1, e.Y));
			if (node != null && node.Parent == null)
				{
				if (node.IsExpanded)
					{
					this.SelectNode(node, false, TreeViewAction.Unknown);
					node.Collapse();
					}
				else
					{
					this.UnselectAllNodesExceptNode(node, TreeViewAction.Unknown);
					this.SelectNode(node, true, TreeViewAction.Unknown);
					if (GroupAutoCollapse) this.CollapseAll();
					node.Expand();
					}
				return;
				}
			}
		base.OnMouseClick(e);
		}

	/// <summary>
	/// Handle the mouse down event
	/// </summary>
	/// <param name="e"></param>
	protected override void OnMouseDown(MouseEventArgs e)
		{
		base.OnMouseDown(e);
		}

	#endregion
	}
}
