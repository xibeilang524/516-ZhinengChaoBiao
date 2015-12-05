using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace ZhinengChaoBiao.Controls
{
    public partial class MyTree : System.Windows.Forms.TreeView
    {
        #region 构造函数
        public MyTree()
        {
            InitializeComponent();
            this.HideSelection = false;
            this.DrawMode = TreeViewDrawMode.OwnerDrawText;
            this.DrawNode += new DrawTreeNodeEventHandler(MyTree_DrawNode);
            this.AfterCheck += MyTree_AfterCheck;
        }

        public MyTree(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
            this.HideSelection = false;
            this.AfterCheck += MyTree_AfterCheck;
        }
        #endregion

        #region 私有方法
        void MyTree_DrawNode(object sender, DrawTreeNodeEventArgs e)
        {
            Brush pen = Brushes.Black;
            if ((e.State & TreeNodeStates.Selected) != 0)
            {
                //演示为蓝底白字
                e.Graphics.FillRectangle(Brushes.Blue, e.Node.Bounds);
                pen = Brushes.White;
            }
            Font nodeFont = e.Node.NodeFont;
            if (nodeFont == null) nodeFont = ((TreeView)sender).Font;
            int topPadding = (int)Math.Abs((e.Node.Bounds.Height - nodeFont.GetHeight()) / 2);
            Rectangle r = new Rectangle(e.Bounds.X, e.Bounds.Y + topPadding, e.Bounds.Width + 5, e.Bounds.Height - topPadding * 2);
            e.Graphics.DrawString(e.Node.Text, nodeFont, pen, r);
        }

        private void MyTree_AfterCheck(object sender, TreeViewEventArgs e)
        {
            this.AfterCheck -= MyTree_AfterCheck;
            CheckChildren(e.Node);
            CheckParent(e.Node);
            this.AfterCheck += MyTree_AfterCheck;
        }

        private void CheckChildren(TreeNode curNode)
        {
            foreach (TreeNode nod in curNode.Nodes)
            {
                nod.Checked = curNode.Checked;
                CheckChildren(nod);
            }
        }

        private void CheckParent(TreeNode curNode)
        {
            TreeNode parent = curNode.Parent;
            if (parent != null)
            {
                bool allChecked = true;
                foreach (TreeNode n in parent.Nodes)
                {
                    if (n.Checked == false)
                    {
                        allChecked = false;
                        break;
                    }
                }
                parent.Checked = allChecked;
                CheckParent(parent);
            }
        }
        #endregion

        #region 重写基类方法
        protected override void OnNodeMouseClick(TreeNodeMouseClickEventArgs e)
        {
            if (!object.ReferenceEquals(this.SelectedNode, e.Node))
            {
                this.SelectedNode = e.Node;
            }
            base.OnNodeMouseClick(e);
        }
        #endregion
    }
}
