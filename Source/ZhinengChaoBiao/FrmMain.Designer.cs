namespace ZhinengChaoBiao
{
    partial class FrmMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.系统ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.mnu_Home = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.mnu_Device = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnu_ReadLogReport = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.mnu_Statistics = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.mnu_Operator = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.mnu_Role = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblOperator = new System.Windows.Forms.ToolStripStatusLabel();
            this.ucFormView1 = new LJH.GeneralLibrary.WinformControl.UCFormView();
            this.mnu_DevicesReal = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.系统ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(788, 25);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.Visible = false;
            // 
            // 系统ToolStripMenuItem
            // 
            this.系统ToolStripMenuItem.Name = "系统ToolStripMenuItem";
            this.系统ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.系统ToolStripMenuItem.Text = "系统";
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnu_Home,
            this.toolStripSeparator3,
            this.mnu_Device,
            this.toolStripSeparator2,
            this.mnu_DevicesReal,
            this.toolStripSeparator7,
            this.toolStripButton1,
            this.toolStripSeparator1,
            this.mnu_ReadLogReport,
            this.toolStripSeparator4,
            this.mnu_Statistics,
            this.toolStripSeparator6,
            this.mnu_Operator,
            this.toolStripSeparator5,
            this.mnu_Role});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(788, 48);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // mnu_Home
            // 
            this.mnu_Home.Image = ((System.Drawing.Image)(resources.GetObject("mnu_Home.Image")));
            this.mnu_Home.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnu_Home.Name = "mnu_Home";
            this.mnu_Home.Size = new System.Drawing.Size(48, 45);
            this.mnu_Home.Text = "主   页";
            this.mnu_Home.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.mnu_Home.Click += new System.EventHandler(this.mnu_Home_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 48);
            // 
            // mnu_Device
            // 
            this.mnu_Device.Image = ((System.Drawing.Image)(resources.GetObject("mnu_Device.Image")));
            this.mnu_Device.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnu_Device.Name = "mnu_Device";
            this.mnu_Device.Size = new System.Drawing.Size(60, 45);
            this.mnu_Device.Text = "设备管理";
            this.mnu_Device.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.mnu_Device.Click += new System.EventHandler(this.mnu_Device_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 48);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(60, 45);
            this.toolStripButton1.Text = "总线管理";
            this.toolStripButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 48);
            // 
            // mnu_ReadLogReport
            // 
            this.mnu_ReadLogReport.Image = ((System.Drawing.Image)(resources.GetObject("mnu_ReadLogReport.Image")));
            this.mnu_ReadLogReport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnu_ReadLogReport.Name = "mnu_ReadLogReport";
            this.mnu_ReadLogReport.Size = new System.Drawing.Size(60, 45);
            this.mnu_ReadLogReport.Text = "读表记录";
            this.mnu_ReadLogReport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.mnu_ReadLogReport.Click += new System.EventHandler(this.mnu_ReadLogReport_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 48);
            // 
            // mnu_Statistics
            // 
            this.mnu_Statistics.Image = ((System.Drawing.Image)(resources.GetObject("mnu_Statistics.Image")));
            this.mnu_Statistics.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnu_Statistics.Name = "mnu_Statistics";
            this.mnu_Statistics.Size = new System.Drawing.Size(60, 45);
            this.mnu_Statistics.Text = "能耗统计";
            this.mnu_Statistics.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.mnu_Statistics.Click += new System.EventHandler(this.mnu_Statistics_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 48);
            // 
            // mnu_Operator
            // 
            this.mnu_Operator.Image = ((System.Drawing.Image)(resources.GetObject("mnu_Operator.Image")));
            this.mnu_Operator.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnu_Operator.Name = "mnu_Operator";
            this.mnu_Operator.Size = new System.Drawing.Size(48, 45);
            this.mnu_Operator.Text = "操作员";
            this.mnu_Operator.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.mnu_Operator.Click += new System.EventHandler(this.mnu_Operator_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 48);
            // 
            // mnu_Role
            // 
            this.mnu_Role.Image = ((System.Drawing.Image)(resources.GetObject("mnu_Role.Image")));
            this.mnu_Role.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnu_Role.Name = "mnu_Role";
            this.mnu_Role.Size = new System.Drawing.Size(60, 45);
            this.mnu_Role.Text = "角色管理";
            this.mnu_Role.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.mnu_Role.Click += new System.EventHandler(this.mnu_Role_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblOperator});
            this.statusStrip1.Location = new System.Drawing.Point(0, 449);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(788, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblOperator
            // 
            this.lblOperator.Name = "lblOperator";
            this.lblOperator.Size = new System.Drawing.Size(0, 17);
            // 
            // ucFormView1
            // 
            this.ucFormView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucFormView1.FormHeaderLength = 135;
            this.ucFormView1.HideHeader = false;
            this.ucFormView1.Location = new System.Drawing.Point(0, 48);
            this.ucFormView1.Name = "ucFormView1";
            this.ucFormView1.Size = new System.Drawing.Size(788, 401);
            this.ucFormView1.TabIndex = 9;
            // 
            // mnu_DevicesReal
            // 
            this.mnu_DevicesReal.Image = ((System.Drawing.Image)(resources.GetObject("mnu_DevicesReal.Image")));
            this.mnu_DevicesReal.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnu_DevicesReal.Name = "mnu_DevicesReal";
            this.mnu_DevicesReal.Size = new System.Drawing.Size(60, 45);
            this.mnu_DevicesReal.Text = "实时读表";
            this.mnu_DevicesReal.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.mnu_DevicesReal.Click += new System.EventHandler(this.mnu_DevicesReal_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 48);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(788, 471);
            this.Controls.Add(this.ucFormView1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FrmMain";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 系统ToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private LJH.GeneralLibrary.WinformControl.UCFormView ucFormView1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton mnu_Device;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton mnu_Home;
        private System.Windows.Forms.ToolStripButton mnu_ReadLogReport;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton mnu_Statistics;
        private System.Windows.Forms.ToolStripStatusLabel lblOperator;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripButton mnu_Operator;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton mnu_Role;
        private System.Windows.Forms.ToolStripButton mnu_DevicesReal;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
    }
}

