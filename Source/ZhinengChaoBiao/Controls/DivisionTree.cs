using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LJH.ZNCB.BLL;
using LJH.ZNCB.Model;

namespace ZhinengChaoBiao.Controls
{
    public partial class DivisionTree : MyTree
    {
        public DivisionTree()
        {
            InitializeComponent();
        }

        public DivisionTree(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
        }

        #region 私有变量
        private List<TreeNode> _AllDivisionNodes = new List<TreeNode>();
        #endregion

        #region 私有方法
        private void AddDeptNodes(List<Division> items, TreeNode parent)
        {
            List<Division> pcs = null;
            if (parent.Tag == null)
            {
                pcs = items.Where(it => string.IsNullOrEmpty(it.Parent)).ToList();
            }
            else
            {
                pcs = items.Where(it => it.Parent == (parent.Tag as Division).ID).ToList();
            }
            if (pcs != null && pcs.Count > 0)
            {
                foreach (Division pc in pcs)
                {
                    TreeNode node = AddDivisionNode(pc, parent);
                    AddDeptNodes(items, node);
                }
            }
            parent.ImageIndex = 0;
            parent.SelectedImageIndex = 0;
        }

        private void RenderDeptNode(Division pc, TreeNode node)
        {
            node.Tag = pc;
            node.SelectedImageIndex = 0;
            node.ImageIndex = 0;
        }
        #endregion

        #region 公共方法
        /// <summary>
        /// 初始化
        /// </summary
        public void Init()
        {
            _AllDivisionNodes.Clear();
            this.ImageList = imageList1;
            this.Nodes.Clear();
            this.Nodes.Add("全校");

            List<Division> items = (new DivisionBLL(AppSettings.Current.ConnStr)).GetItems(null).QueryObjects;
            if (items != null && items.Count > 0)
            {
                AddDeptNodes(items, this.Nodes[0]);
            }
            this.ExpandAll();
        }
        /// <summary>
        /// 增加客户类别
        /// </summary>
        /// <param name="pc"></param>
        /// <param name="parent"></param>
        /// <returns></returns>
        public TreeNode AddDivisionNode(Division pc, TreeNode parent)
        {
            TreeNode node = parent.Nodes.Add(string.Format("{0}", pc.Name));
            RenderDeptNode(pc, node);
            _AllDivisionNodes.Add(node);
            return node;
        }
        /// <summary>
        /// 获取所有某个节点下的所有产品类别信息，包括此节点下所有后代产品类别节点的产品类别信息
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public List<Division> GetDivisionofNode(TreeNode node)
        {
            List<Division> items = new List<Division>();
            if (node.Tag is Division)
            {
                items.Add(node.Tag as Division);
            }
            if (node.Nodes.Count > 0)
            {
                foreach (TreeNode child in node.Nodes)
                {
                    items.AddRange(GetDivisionofNode(child));
                }
            }
            return items;
        }
        /// <summary>
        /// 通过部门ID获取部门信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Division GetDivision(string id)
        {
            if (_AllDivisionNodes != null && _AllDivisionNodes.Count > 0)
            {
                foreach (TreeNode node in _AllDivisionNodes)
                {
                    Division dept = node.Tag as Division;
                    if (dept != null && dept.ID == id) return dept;
                }
            }
            return null;
        }
        /// <summary>
        /// 选择指定部门ID的节点
        /// </summary>
        /// <param name="node"></param>
        /// <param name="parent"></param>
        public void SelectNode(string deptID)
        {
            foreach (TreeNode node in _AllDivisionNodes)
            {
                Division pdept = node.Tag as Division;
                if (pdept.ID == deptID)
                {
                    this.SelectedNode = node;
                    break;
                }
            }
        }
        #endregion
    }
}
