using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Windows.Forms;
using LJH.ZNCB.Model;
using LJH.ZNCB.Model.Security;

namespace ZhinengChaoBiao.Controls
{
    public partial class FunctionTree : MyTree
    {
        #region 构造函数
        public FunctionTree()
        {
            InitializeComponent();
        }

        public FunctionTree(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
        }
        #endregion

        #region 私有变量
        private readonly string RootText = "所有权限类别";
        private List<TreeNode> _rightNodes = new List<TreeNode>();
        #endregion

        #region 私有方法
        private void AddRightNode(TreeNode parent, List<OperatorRightAttribute> rights)
        {
            foreach (OperatorRightAttribute right in rights)
            {
                if (right.Catalog == parent.Tag.ToString())
                {
                    TreeNode rightNode = new TreeNode(right.Description, 1, 1);
                    rightNode.Tag = right.Value;
                    _rightNodes.Add(rightNode);
                    parent.Nodes.Add(rightNode);
                    AddActionNodes(rightNode, right.Actions);
                }
            }
        }

        private void AddActionNodes(TreeNode parent, PermissionActions actions)
        {
            for (int i = 0; i < 32; i++)
            {
                PermissionActions temp = (PermissionActions)(1 << i);
                if (Enum.IsDefined(typeof(PermissionActions), temp))
                {
                    if ((temp & actions) != 0)
                    {
                        string descr = PermissionActionDescription.GetDescription(temp);
                        if (!string.IsNullOrEmpty(descr))
                        {
                            TreeNode actionNode = new TreeNode(descr, 1, 1);
                            actionNode.Tag = temp;
                            parent.Nodes.Add(actionNode);
                        }
                    }
                }
            }
        }
        #endregion

        #region 公共方法和属性
        public void Init()
        {
            this.ImageList = images;
            this.CheckBoxes = true;
            this.Nodes.Clear();
            TreeNode root = new TreeNode(RootText, 0, 0);
            this.Nodes.Add(root);
            List<OperatorRightAttribute> items = PermissionResolver.Resolve();
            if (items != null && items.Count > 0)
            {
                List<string> categories = items.Select(it => it.Catalog).Distinct().ToList();
                foreach (string category in categories)
                {
                    TreeNode catalogNode = new TreeNode(category, 0, 0);
                    catalogNode.Tag = category;
                    root.Nodes.Add(catalogNode);
                    AddRightNode(catalogNode, items);
                }
            }
            root.Expand();
        }

        [Browsable(false)]
        [Localizable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string SelectedRights
        {
            get
            {
                if (this.Nodes[0].Checked)
                {
                    return "all";
                }
                else
                {
                    List<ulong> rights = new List<ulong>();
                    foreach (TreeNode node in _rightNodes)
                    {
                        uint permission = Convert.ToUInt32(node.Tag);
                        uint action = 0;
                        foreach (TreeNode child in node.Nodes)
                        {
                            if (child.Checked) action = (action | Convert.ToUInt32(child.Tag));
                        }
                        if (action != 0) rights.Add(((ulong)permission << 32) + action);
                    }
                    var list = from right in rights
                               select right.ToString("D");
                    return string.Join(",", list.ToArray());
                }
            }
            set
            {
                if (value.ToLower() == "all")
                {
                    this.Nodes[0].Checked = true;
                }
                else if (!string.IsNullOrEmpty(value))
                {
                    foreach (string str in value.Split(','))
                    {
                        ulong temp = 0;
                        if (ulong.TryParse(str, out temp))
                        {
                            uint permission = (uint)((temp >> 32) & 0xFFFFFFFF); //高32位表示权限
                            uint actions = (uint)(temp & 0xFFFFFFFF); //低32位表示动作
                            TreeNode node = _rightNodes.FirstOrDefault(n => Convert.ToUInt32(n.Tag) == permission);
                            if (node != null)
                            {
                                foreach (TreeNode child in node.Nodes)
                                {
                                    child.Checked = (actions & Convert.ToUInt32(child.Tag)) != 0;
                                }
                            }
                        }
                    }
                }
            }
        }
        #endregion
    }
}
