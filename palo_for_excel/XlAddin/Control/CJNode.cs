using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Crownwood.DotNetMagic.Controls;
namespace aPalo.XlAddin
{
/// <summary>
/// Class replaces Node to correct Tag/Key definition
/// </summary>
class CJNode : Node
		{

		[DefaultValue("")]
		[Browsable(false)]
		[Category("Data")]
		[Description("User defined unique key to associate with node.")]
		public new object Key { get; set; }

		[Category("Data")]
		[Description("User defined data associated with node.")]
		[Browsable(false)]
		[DefaultValue("")]
		public object oTag { get; set; }

		public CJNode() {}

		public CJNode(string text, IEnumerable<Node> child_nodes = null) : base(text, child_nodes) {}

		public new object Clone()
				{
				CJNode jn = new CJNode(this.Text);

				//		TODO: Complete if needed
				jn.BackColor = this.BackColor;
				jn.Checked = this.Checked;
				jn.CheckState = this.CheckState;
				jn.CheckStates = this.CheckStates;
				jn.ForeColor = this.ForeColor;
				jn.Icon = this.Icon;
				jn.Image = this.Image;
				jn.ImageIndex = this.ImageIndex;
				jn.Indicator = this.Indicator;

				jn.Key = this.Key;
				jn.Tag = this.Tag;
				jn.oTag = this.oTag;
				return jn;
				}

		/// <summary>
		/// Clones an entire node collection
		/// </summary>
		/// <param name="From"></param>
		/// <returns></returns>
		public static object CloneCollection(NodeCollection From)
				{
				NodeCollection nc = new NodeCollection();
				return nc;
				}
		}
}
