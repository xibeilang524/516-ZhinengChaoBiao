﻿namespace ZhinengChaoBiao
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDeviceMaster));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cMnu_Fresh = new System.Windows.Forms.ToolStripMenuItem();
            this.cMnu_Add = new System.Windows.Forms.ToolStripMenuItem();
            this.cMnu_Delete = new System.Windows.Forms.ToolStripMenuItem();
            this.cMnu_Export = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.模拟读表ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.colID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDeviceType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colState = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLastDt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLastValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMemo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1.SuspendLayout();
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
            this.colLastDt,
            this.colLastValue,
            this.colMemo});
            this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(904, 374);
            this.dataGridView1.TabIndex = 60;
            // 
            // 模拟读表ToolStripMenuItem
            // 
            this.模拟读表ToolStripMenuItem.Name = "模拟读表ToolStripMenuItem";
            this.模拟读表ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.模拟读表ToolStripMenuItem.Text = "模拟读表";
            this.模拟读表ToolStripMenuItem.Click += new System.EventHandler(this.模拟读表ToolStripMenuItem_Click);
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
            // colLastValue
            // 
            dataGridViewCellStyle2.Format = "N2";
            this.colLastValue.DefaultCellStyle = dataGridViewCellStyle2;
            this.colLastValue.HeaderText = "上次表读数";
            this.colLastValue.Name = "colLastValue";
            this.colLastValue.ReadOnly = true;
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
            this.ClientSize = new System.Drawing.Size(904, 396);
            this.Controls.Add(this.dataGridView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmDeviceMaster";
            this.Text = "设备管理";
            this.Controls.SetChildIndex(this.dataGridView1, 0);
            this.contextMenuStrip1.ResumeLayout(false);
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
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ToolStripMenuItem 模拟读表ToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn colID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDeviceType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn colState;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLastDt;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLastValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMemo;
    }
}