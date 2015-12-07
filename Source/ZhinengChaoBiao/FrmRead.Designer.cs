namespace ZhinengChaoBiao
{
    partial class FrmRead
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRead));
            this.label1 = new System.Windows.Forms.Label();
            this.txtValue = new LJH.GeneralLibrary.WinformControl.DecimalTextBox(this.components);
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.txtLastValue = new LJH.GeneralLibrary.WinformControl.DecimalTextBox(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(43, 92);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "当前表读数";
            // 
            // txtValue
            // 
            this.txtValue.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtValue.Location = new System.Drawing.Point(114, 89);
            this.txtValue.MaxLength = 20;
            this.txtValue.MaxValue = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.txtValue.MinValue = new decimal(new int[] {
            -1,
            -1,
            -1,
            -2147483648});
            this.txtValue.Name = "txtValue";
            this.txtValue.PointCount = 2;
            this.txtValue.Size = new System.Drawing.Size(187, 21);
            this.txtValue.TabIndex = 84;
            this.txtValue.Text = "0";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(209, 168);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(119, 34);
            this.btnCancel.TabIndex = 88;
            this.btnCancel.Text = "取消(&C)";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.Location = new System.Drawing.Point(63, 168);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(119, 34);
            this.btnOk.TabIndex = 87;
            this.btnOk.Text = "确定(&O)";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // txtLastValue
            // 
            this.txtLastValue.Enabled = false;
            this.txtLastValue.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtLastValue.Location = new System.Drawing.Point(114, 50);
            this.txtLastValue.MaxLength = 20;
            this.txtLastValue.MaxValue = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.txtLastValue.MinValue = new decimal(new int[] {
            -1,
            -1,
            -1,
            -2147483648});
            this.txtLastValue.Name = "txtLastValue";
            this.txtLastValue.PointCount = 2;
            this.txtLastValue.Size = new System.Drawing.Size(187, 21);
            this.txtLastValue.TabIndex = 90;
            this.txtLastValue.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(43, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 89;
            this.label2.Text = "上次表读数";
            // 
            // FrmRead
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(366, 229);
            this.Controls.Add(this.txtLastValue);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.txtValue);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmRead";
            this.Text = "模拟读卡";
            this.Load += new System.EventHandler(this.FrmRead_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private LJH.GeneralLibrary.WinformControl.DecimalTextBox txtValue;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private LJH.GeneralLibrary.WinformControl.DecimalTextBox txtLastValue;
        private System.Windows.Forms.Label label2;
    }
}