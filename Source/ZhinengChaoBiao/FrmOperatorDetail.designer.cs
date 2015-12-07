
namespace ZhinengChaoBiao
{
    partial class FrmOperatorDetail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmOperatorDetail));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtOperatorID = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.txtPassword = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.txtOperatorName = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.btnChangePwd = new System.Windows.Forms.Button();
            this.comRoleList = new ZhinengChaoBiao.Controls.RoleComboBox(this.components);
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(226, 147);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(113, 147);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "登录ID:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(39, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "密码:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(39, 104);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "角色:";
            // 
            // txtOperatorID
            // 
            this.txtOperatorID.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtOperatorID.Location = new System.Drawing.Point(79, 15);
            this.txtOperatorID.Name = "txtOperatorID";
            this.txtOperatorID.Size = new System.Drawing.Size(222, 21);
            this.txtOperatorID.TabIndex = 0;
            // 
            // txtPassword
            // 
            this.txtPassword.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtPassword.Location = new System.Drawing.Point(79, 71);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(188, 21);
            this.txtPassword.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 12);
            this.label3.TabIndex = 13;
            this.label3.Text = "真实姓名:";
            // 
            // txtOperatorName
            // 
            this.txtOperatorName.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtOperatorName.Location = new System.Drawing.Point(79, 43);
            this.txtOperatorName.Name = "txtOperatorName";
            this.txtOperatorName.Size = new System.Drawing.Size(222, 21);
            this.txtOperatorName.TabIndex = 1;
            // 
            // btnChangePwd
            // 
            this.btnChangePwd.Location = new System.Drawing.Point(273, 70);
            this.btnChangePwd.Name = "btnChangePwd";
            this.btnChangePwd.Size = new System.Drawing.Size(28, 23);
            this.btnChangePwd.TabIndex = 19;
            this.btnChangePwd.Text = "改";
            this.btnChangePwd.UseVisualStyleBackColor = true;
            this.btnChangePwd.Click += new System.EventHandler(this.btnChangePwd_Click);
            // 
            // comRoleList
            // 
            this.comRoleList.FormattingEnabled = true;
            this.comRoleList.Location = new System.Drawing.Point(79, 100);
            this.comRoleList.Name = "comRoleList";
            this.comRoleList.Size = new System.Drawing.Size(222, 20);
            this.comRoleList.TabIndex = 4;
            // 
            // FrmOperatorDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(313, 182);
            this.Controls.Add(this.btnChangePwd);
            this.Controls.Add(this.txtOperatorName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comRoleList);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtOperatorID);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FrmOperatorDetail";
            this.Text = "操作员明细";
            this.Controls.SetChildIndex(this.btnOk, 0);
            this.Controls.SetChildIndex(this.btnClose, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.txtOperatorID, 0);
            this.Controls.SetChildIndex(this.txtPassword, 0);
            this.Controls.SetChildIndex(this.comRoleList, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.txtOperatorName, 0);
            this.Controls.SetChildIndex(this.btnChangePwd, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private LJH.GeneralLibrary.WinformControl.DBCTextBox  txtOperatorID;
        private LJH.GeneralLibrary.WinformControl.DBCTextBox  txtPassword;
        private Controls.RoleComboBox comRoleList;
        private System.Windows.Forms.Label label3;
        private LJH.GeneralLibrary.WinformControl.DBCTextBox  txtOperatorName;
        private System.Windows.Forms.Button btnChangePwd;
    }
}