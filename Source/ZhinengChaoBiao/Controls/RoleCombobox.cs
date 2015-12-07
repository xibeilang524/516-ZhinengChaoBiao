using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LJH.ZNCB.Model;
using LJH.ZNCB.Model.Security;
using LJH.ZNCB.BLL;

namespace ZhinengChaoBiao.Controls
{
    public partial class RoleComboBox:ComboBox 
    {
        public RoleComboBox()
        {
            InitializeComponent();
        }

        public RoleComboBox(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        public void Init()
        {
            RoleBLL bll = new RoleBLL(AppSettings.Current.ConnStr);
            List<Role> roles = bll.GetItems(null).QueryObjects;
            if (roles != null) roles.Insert(0, new Role());
            this.DataSource = roles;
            this.DisplayMember = "Name";
            this.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        [Browsable(false)]
        [Localizable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Role Role
        {
            get
            {
                if (this.SelectedIndex <= 0)
                {
                    return null;
                }
                else
                {
                    return ((Role)this.Items[SelectedIndex]);
                }
            }
            set
            {
                for (int i = 1; i < this.Items.Count; i++)
                {
                    Role info = (Role)this.Items[i];
                    if (info.ID == value.ID)
                    {
                        this.SelectedIndex = i;
                        break;
                    }
                }
            }
        }

        [Browsable(false)]
        [Localizable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string SelectedRoleID
        {
            get
            {
                if (this.SelectedIndex <= 0)
                {
                    return string.Empty;
                }
                else
                {
                    Role role = (Role)this.Items[SelectedIndex];
                    return role.ID;
                }
            }
            set
            {
                for (int i = 1; i < this.Items.Count; i++)
                {
                    Role info = (Role)this.Items[i];
                    if (info.ID == value)
                    {
                        this.SelectedIndex = i;
                        break;
                    }
                }
            }
        }
    }
}
