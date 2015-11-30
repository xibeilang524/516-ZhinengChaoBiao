namespace ZhinengChaoBiao
{
    partial class FrmDivisionDetail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDivisionDetail));
            this.txtParentCategory = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.lnkParentCategory = new System.Windows.Forms.LinkLabel();
            this.txtMemo = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.txtName = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.txtID = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(300, 162);
            this.btnClose.TabIndex = 5;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(191, 162);
            this.btnOk.TabIndex = 4;
            // 
            // txtParentCategory
            // 
            this.txtParentCategory.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtParentCategory.Location = new System.Drawing.Point(66, 83);
            this.txtParentCategory.MaxLength = 100;
            this.txtParentCategory.Name = "txtParentCategory";
            this.txtParentCategory.ReadOnly = true;
            this.txtParentCategory.Size = new System.Drawing.Size(311, 21);
            this.txtParentCategory.TabIndex = 2;
            this.txtParentCategory.DoubleClick += new System.EventHandler(this.txtParentCategory_DoubleClick);
            // 
            // lnkParentCategory
            // 
            this.lnkParentCategory.AutoSize = true;
            this.lnkParentCategory.Location = new System.Drawing.Point(10, 86);
            this.lnkParentCategory.Name = "lnkParentCategory";
            this.lnkParentCategory.Size = new System.Drawing.Size(53, 12);
            this.lnkParentCategory.TabIndex = 1;
            this.lnkParentCategory.TabStop = true;
            this.lnkParentCategory.Text = "上级区域";
            this.lnkParentCategory.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkParentCategory_LinkClicked);
            // 
            // txtMemo
            // 
            this.txtMemo.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtMemo.Location = new System.Drawing.Point(66, 114);
            this.txtMemo.Multiline = true;
            this.txtMemo.Name = "txtMemo";
            this.txtMemo.Size = new System.Drawing.Size(311, 21);
            this.txtMemo.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 118);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 42;
            this.label2.Text = "备注";
            // 
            // txtName
            // 
            this.txtName.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtName.Location = new System.Drawing.Point(66, 53);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(311, 21);
            this.txtName.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(34, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 41;
            this.label3.Text = "名称";
            // 
            // txtID
            // 
            this.txtID.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtID.Location = new System.Drawing.Point(66, 20);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(311, 21);
            this.txtID.TabIndex = 43;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 44;
            this.label1.Text = "编号";
            // 
            // FrmDivisionDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(387, 197);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtParentCategory);
            this.Controls.Add(this.lnkParentCategory);
            this.Controls.Add(this.txtMemo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label3);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmDivisionDetail";
            this.Text = "区域信息";
            this.Controls.SetChildIndex(this.btnOk, 0);
            this.Controls.SetChildIndex(this.btnClose, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.txtName, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.txtMemo, 0);
            this.Controls.SetChildIndex(this.lnkParentCategory, 0);
            this.Controls.SetChildIndex(this.txtParentCategory, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.txtID, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private LJH.GeneralLibrary.WinformControl.DBCTextBox txtParentCategory;
        private System.Windows.Forms.LinkLabel lnkParentCategory;
        private LJH.GeneralLibrary.WinformControl.DBCTextBox txtMemo;
        private System.Windows.Forms.Label label2;
        private LJH.GeneralLibrary.WinformControl.DBCTextBox txtName;
        private System.Windows.Forms.Label label3;
        private LJH.GeneralLibrary.WinformControl.DBCTextBox txtID;
        private System.Windows.Forms.Label label1;
    }
}