/*  
 *  JNode class - TreeNode extension
 *
 *	(c) Junction BI LLC
 * 
 *	Revision History -
 *
 *	03/21/14 JMM Initial Version, replaced DotNetMagic Controls
 *
*/

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Text;
namespace JControls
{
/// <summary>
/// Provides an derived TreeNode with extended capabilities
/// </summary>
/// <remarks>
/// This is used primarily for compatability with older functionality of a third-party tree control that was previously used.
/// </remarks>
public class JNode : TreeNode
    {
    /// <summary>Indicates how check-able nodes are displayed.</summary>
    public enum NodeCheckStates {Checkbox, Radio}

    /// <summary>Indicates how check-able nodes are displayed.</summary>
    public NodeCheckStates CheckStates {get;set;}

    /// <summary>
    /// Whether the node is selected.
    /// </summary>
    /// <remarks>
    /// Defined for compatibility: Wraps MSTreeView.IsNodeSelected().
    /// </remarks>
    /// <returns></returns>
    public new bool IsSelected
        {get {MSTreeView tv = this.TreeView as MSTreeView; 
              return tv == null ? base.IsSelected : tv.IsNodeSelected(this);}}

    /// <summary>
    /// Select node
    /// </summary>
    /// <remarks>
    /// Defined for compatibility
    /// </remarks>
    /// <param name="DoFocus"></param>
    public void Select(bool DoFocus)
        {
        MSTreeView tv = this.TreeView as MSTreeView; 
        if (tv == null)
            this.TreeView.SelectedNode = this;
        else
            tv.SelectNode(this, true, TreeViewAction.Unknown);
        }

    /// <summary>Default constructor</summary>
    public JNode() {}

    /// <summary>Constructor with text.</summary>
    /// <param name="T"></param>
    public JNode(string T) : base(T) {}

    /// <summary>Constructor with text and child nodes.</summary>
    /// <param name="text"></param>
    /// <param name="children"></param>
    public JNode(string text, TreeNode[] children) : base(text, children) {}
    }
}
