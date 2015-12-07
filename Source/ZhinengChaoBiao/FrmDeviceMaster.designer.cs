namespace ZhinengChaoBiao
{
    partial class FrmDeviceMaster
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDeviceMaster));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cMnu_Fresh = new System.Windows.Forms.ToolStripMenuItem();
            this.cMnu_Add = new System.Windows.Forms.ToolStripMenuItem();
            this.cMnu_Delete = new System.Windows.Forms.ToolStripMenuItem();
            this.cMnu_Export = new System.Windows.Forms.ToolStripMenuItem();
            this.模拟读表ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.facilityTree = new ZhinengChaoBiao.Controls.DivisionTree(this.components);
            this.DivisionMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnu_AddDevice = new System.Windows.Forms.ToolStripMenuItem();
            this.mnu_AddDivision = new System.Windows.Forms.ToolStripMenuItem();
            this.mnu_DeleteDivision = new System.Windows.Forms.ToolStripMenuItem();
            this.mnu_DepartmentProperty = new System.Windows.Forms.ToolStripMenuItem();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.colID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDeviceType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colState = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDivision = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLastDt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMemo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.DivisionMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cMnu_Fresh,
            this.cMnu_Add,
            this.cMnu_Delete,
            this.cMnu_Export,
            this.模拟读表ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(125, 114);
            // 
            // cMnu_Fresh
            // 
            this.cMnu_Fresh.Name = "cMnu_Fresh";
            this.cMnu_Fresh.Size = new System.Drawing.Size(124, 22);
            this.cMnu_Fresh.Text = "刷新";
            // 
            // cMnu_Add
            // 
            this.cMnu_Add.Name = "cMnu_Add";
            this.cMnu_Add.Size = new System.Drawing.Size(124, 22);
            this.cMnu_Add.Text = "新建";
            this.cMnu_Add.Visible = false;
            // 
            // cMnu_Delete
            // 
            this.cMnu_Delete.Name = "cMnu_Delete";
            this.cMnu_Delete.Size = new System.Drawing.Size(124, 22);
            this.cMnu_Delete.Text = "删除";
            // 
            // cMnu_Export
            // 
            this.cMnu_Export.Name = "cMnu_Export";
            this.cMnu_Export.Size = new System.Drawing.Size(124, 22);
            this.cMnu_Export.Text = "导出...";
            // 
            // 模拟读表ToolStripMenuItem
            // 
            this.模拟读表ToolStripMenuItem.Name = "模拟读表ToolStripMenuItem";
            this.模拟读表ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.模拟读表ToolStripMenuItem.Text = "模拟读表";
            this.模拟读表ToolStripMenuItem.Click += new System.EventHandler(this.模拟读表ToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.facilityTree);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 374);
            this.panel1.TabIndex = 61;
            // 
            // facilityTree
            // 
            this.facilityTree.ContextMenuStrip = this.DivisionMenu;
            this.facilityTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.facilityTree.DrawMode = System.Windows.Forms.TreeViewDrawMode.OwnerDrawText;
            this.facilityTree.HideSelection = false;
            this.facilityTree.ItemHeight = 20;
            this.facilityTree.Location = new System.Drawing.Point(0, 0);
            this.facilityTree.Name = "facilityTree";
            this.facilityTree.Size = new System.Drawing.Size(200, 374);
            this.facilityTree.TabIndex = 0;
            this.facilityTree.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.facilityTree_NodeMouseClick);
            // 
            // DivisionMenu
            // 
            this.DivisionMenu.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.DivisionMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnu_AddDevice,
            this.mnu_AddDivision,
            this.mnu_DeleteDivision,
            this.mnu_DepartmentProperty});
            this.DivisionMenu.Name = "contextMenuStrip1";
            this.DivisionMenu.Size = new System.Drawing.Size(127, 92);
            // 
            // mnu_AddDevice
            // 
            this.mnu_AddDevice.Name = "mnu_AddDevice";
            this.mnu_AddDevice.Size = new System.Drawing.Size(126, 22);
            this.mnu_AddDevice.Text = "增加设备";
            this.mnu_AddDevice.Click += new System.EventHandler(this.mnu_AddDevice_Click);
            // 
            // mnu_AddDivision
            // 
            this.mnu_AddDivision.Name = "mnu_AddDivision";
            this.mnu_AddDivision.Size = new System.Drawing.Size(126, 22);
            this.mnu_AddDivision.Text = "增加区域";
            this.mnu_AddDivision.Click += new System.EventHandler(this.mnu_AddDivision_Click);
            // 
            // mnu_DeleteDivision
            // 
            this.mnu_DeleteDivision.Name = "mnu_DeleteDivision";
            this.mnu_DeleteDivision.Size = new System.Drawing.Size(126, 22);
            this.mnu_DeleteDivision.Text = "删除";
            this.mnu_DeleteDivision.Click += new System.EventHandler(this.mnu_DeleteDivision_Click);
            // 
            // mnu_DepartmentProperty
            // 
            this.mnu_DepartmentProperty.Name = "mnu_DepartmentProperty";
            this.mnu_DepartmentProperty.Size = new System.Drawing.Size(126, 22);
            this.mnu_DepartmentProperty.Text = "属性";
            this.mnu_DepartmentProperty.Click += new System.EventHandler(this.mnu_DivisionProperty_Click);
            // 
            // splitter1
            // 
            this.splitter1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.splitter1.Location = new System.Drawing.Point(200, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(6, 374);
            this.splitter1.TabIndex = 62;
            this.splitter1.TabStop = false;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colID,
            this.colName,
            this.colDeviceType,
            this.colBus,
            this.colAddress,
            this.colState,
            this.colDivision,
            this.colLastDt,
            this.colMemo});
            this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(206, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1077, 374);
            this.dataGridView1.TabIndex = 63;
            // 
            // colID
            // 
            this.colID.HeaderText = "编号";
            this.colID.Name = "colID";
            this.colID.ReadOnly = true;
            // 
            // colName
            // 
            this.colName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colName.HeaderText = "名称";
            this.colName.MinimumWidth = 100;
            this.colName.Name = "colName";
            this.colName.ReadOnly = true;
            // 
            // colDeviceType
            // 
            this.colDeviceType.HeaderText = "设备类型";
            this.colDeviceType.Name = "colDeviceType";
            this.colDeviceType.ReadOnly = true;
            // 
            // colBus
            // 
            this.colBus.HeaderText = "总线";
            this.colBus.Name = "colBus";
            this.colBus.ReadOnly = true;
            this.colBus.Width = 120;
            // 
            // colAddress
            // 
            this.colAddress.HeaderText = "地址";
            this.colAddress.Name = "colAddress";
            this.colAddress.ReadOnly = true;
            // 
            // colState
            // 
            this.colState.HeaderText = "状态";
            this.colState.Name = "colState";
            this.colState.ReadOnly = true;
            // 
            // colDivision
            // 
            this.colDivision.HeaderText = "区域";
            this.colDivision.Name = "colDivision";
            this.colDivision.ReadOnly = true;
            // 
            // colLastDt
            // 
            dataGridViewCellStyle1.Format = "G";
            dataGridViewCellStyle1.NullValue = null;
            this.colLastDt.DefaultCellStyle = dataGridViewCellStyle1;
            this.colLastDt.HeaderText = "上次读表日期";
            this.colLastDt.Name = "colLastDt";
            this.colLastDt.ReadOnly = true;
            this.colLastDt.Width = 130;
            // 
            // colMemo
            // 
            this.colMemo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colMemo.HeaderText = "";
            this.colMemo.Name = "colMemo";
            this.colMemo.ReadOnly = true;
            // 
            // FrmDeviceMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1283, 396);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmDeviceMaster";
            this.Text = "设备管理";
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.splitter1, 0);
            this.Controls.SetChildIndex(this.dataGridView1, 0);
            this.contextMenuStrip1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.DivisionMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem cMnu_Fresh;
        private System.Windows.Forms.ToolStripMenuItem cMnu_Add;
        private System.Windows.Forms.ToolStripMenuItem cMnu_Delete;
        private System.Windows.Forms.ToolStripMenuItem cMnu_Export;
        private System.Windows.Forms.ToolStripMenuItem 模拟读表ToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private Controls.DivisionTree facilityTree;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ContextMenuStrip DivisionMenu;
        private System.Windows.Forms.ToolStripMenuItem mnu_AddDevice;
        private System.Windows.Forms.ToolStripMenuItem mnu_AddDivision;
        private System.Windows.Forms.ToolStripMenuItem mnu_DeleteDivision;
        private System.Windows.Forms.ToolStripMenuItem mnu_DepartmentProperty;
        private System.Windows.Forms.DataGridViewTextBoxColumn colID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDeviceType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn colState;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDivision;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLastDt;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMemo;
    }
}