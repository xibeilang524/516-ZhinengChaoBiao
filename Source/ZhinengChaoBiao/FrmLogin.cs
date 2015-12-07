using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;
using LJH.ZNCB.Model;
using LJH.ZNCB.Model.Security;
using LJH.ZNCB.BLL;
using LJH.GeneralLibrary;

namespace ZhinengChaoBiao
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        #region 私有变量
        private string _DBPath = Path.Combine(Application.StartupPath, "ZhinengChaoBiao.db");
        #endregion

        #region 私有方法
        private bool DoLogin(string logName, string pwd)
        {
            SaveConnectString();
            UpgradeLocalDB(); //升级本地数据库
            OperatorBLL authen = new OperatorBLL(AppSettings.Current.ConnStr);
            if (authen.Authentication(logName, pwd))
            {
                this.DialogResult = DialogResult.OK;
                if (AppSettings.Current.RememberLogID) SaveHistoryOperators();
                this.Close();
                return true;
            }
            else
            {
                return false;
            }
        }

        private void SaveConnectString()
        {
            AppSettings.Current.SaveConfig("DBPath", _DBPath);
            AppSettings.Current.ConnStr = "SQLITE:Data Source=" + _DBPath;

        }

        private void UpgradeLocalDB()
        {
            string path = System.IO.Path.Combine(Application.StartupPath, "DbUpdate_Sqlite.sql");
            if (File.Exists(path))
            {
                List<string> commands = (new LJH.GeneralLibrary.SQLHelper.SQLStringExtractor()).ExtractFromFile(path);
                if (commands != null && commands.Count > 0)
                {
                    using (System.Data.SQLite.SQLiteConnection con = new System.Data.SQLite.SQLiteConnection("Data Source=" + _DBPath))
                    {
                        using (System.Data.SQLite.SQLiteCommand cmd = new System.Data.SQLite.SQLiteCommand(con))
                        {
                            con.Open();
                            foreach (string command in commands)
                            {
                                try
                                {
                                    cmd.CommandText = command;
                                    cmd.ExecuteNonQuery();
                                }
                                catch (Exception ex)
                                {
                                    //LJH.GeneralLibrary.ExceptionHandling.ExceptionPolicy.HandleException(ex);
                                }
                            }
                        }
                    }
                }
            }
        }

        private List<string> GetHistoryOperators()
        {
            List<string> items = null;
            string file = Path.Combine(Application.StartupPath, "HistoryOperators.txt");
            if (File.Exists(file))
            {
                try
                {
                    using (FileStream stream = new FileStream(file, FileMode.Open, FileAccess.Read))
                    {
                        using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                        {
                            items = new List<string>();
                            while (!reader.EndOfStream)
                            {
                                items.Add(reader.ReadLine());
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    LJH.GeneralLibrary.ExceptionHandling.ExceptionPolicy.HandleException(ex);
                }
            }
            return items;
        }

        private void SaveHistoryOperators()
        {
            List<string> items = new List<string>();
            if (txtLogName.AutoCompleteCustomSource != null && txtLogName.AutoCompleteCustomSource.Count > 0)
            {
                string[] history = new string[txtLogName.AutoCompleteCustomSource.Count];
                txtLogName.AutoCompleteCustomSource.CopyTo(history, 0);
                items.AddRange(history);

            }
            if (!items.Contains(txtLogName.Text)) items.Add(txtLogName.Text);
            try
            {
                string file = Path.Combine(Application.StartupPath, "HistoryOperators.txt");
                using (FileStream stream = new FileStream(file, FileMode.Create, FileAccess.Write))
                {
                    using (StreamWriter writer = new StreamWriter(stream, Encoding.UTF8))
                    {
                        foreach (string item in items)
                        {
                            writer.WriteLine(item);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LJH.GeneralLibrary.ExceptionHandling.ExceptionPolicy.HandleException(ex);
            }
        }
        #endregion

        private void Login_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(CommandLineArgs.UserName))
            {
                this.txtLogName.Text = CommandLineArgs.UserName;
                this.txtPassword.Text = CommandLineArgs.Password;
                CommandLineArgs.UserName = string.Empty;
                CommandLineArgs.Password = string.Empty;
                this.btnLogin_Click(this.btnLogin, EventArgs.Empty);
                return;
            }

            this.chkRememberLogid.Checked = AppSettings.Current.RememberLogID;
            if (AppSettings.Current.RememberLogID)
            {
                List<string> history = GetHistoryOperators();
                if (history != null && history.Count > 0)
                {
                    this.txtLogName.AutoCompleteCustomSource = new AutoCompleteStringCollection();
                    foreach (string item in history)
                    {
                        this.txtLogName.AutoCompleteCustomSource.Add(item);
                        this.txtLogName.Items.Add(item);
                    }
                }
            }
        }

        private void chkRememberLogid_CheckedChanged(object sender, EventArgs e)
        {
            AppSettings.Current.RememberLogID = chkRememberLogid.Checked;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string logName = this.txtLogName.Text.Trim();
            string pwd = this.txtPassword.Text.Trim();

            if (logName.Length == 0)
            {
                MessageBox.Show("用户名不能为空!");
                return;
            }

            if (pwd.Length == 0)
            {
                MessageBox.Show("密码不能为空!");
                return;
            }

            if (DoLogin(logName, pwd) == false)
            {
                MessageBox.Show("用户名或者密码输入不正确!");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
