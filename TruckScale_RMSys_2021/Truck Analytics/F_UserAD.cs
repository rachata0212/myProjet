using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;
using System.IO;
//using Quick_Lab;

//using CustomUI;

namespace Truck_Analytics
{
    public partial class F_UserAD : Form
    {
        //public FormUserAD()
        private DataGridView dtg_domain;
        private Panel panel1;
        private TextBox txt_emailselect;
        private Label label2;
        private TextBox txt_nameselect;
        private Label label3;
        private Label label1;
        private ComboBox cb_ou;

        //private FullLayeredWindow fc;
        #region "Form Shadow for Windows XP+"
        // Define the CS_DROPSHADOW constant
        private const int CS_DROPSHADOW = 0x00020000;
        // Override the CreateParams property
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ClassStyle |= CS_DROPSHADOW;
                return cp;
            }
        }
        #endregion

        public F_UserAD()
        {
            InitializeComponent();
            //fc = new FullLayeredWindow(this);
            //fc.ShowInTaskbar = false;
            //fc.Show();

           
        }

        //update 05/09/2019    Rachata.h
        int idselect = 0;
        private enum EunmDataGrid { empty, users, computers };
        private EunmDataGrid EnumDataGrid1 = EunmDataGrid.empty;
        private static string stringDomainName = System.Net.NetworkInformation.IPGlobalProperties.GetIPGlobalProperties().DomainName;

        public string id_user = "";
        public string email_user = "";

       
        //update 05/09/2019  Rachata.h
        private void Load_AD()
        {
            try
            {
                string stringDomainName = System.Net.NetworkInformation.IPGlobalProperties.GetIPGlobalProperties().DomainName;
                if (stringDomainName != null)
                {
                    PrincipalContext PrincipalContext1 = new PrincipalContext(ContextType.Domain, stringDomainName);
                    GroupPrincipal GroupPrincipal1 = new GroupPrincipal(PrincipalContext1);
                    PrincipalSearcher search = new PrincipalSearcher(GroupPrincipal1);

                    foreach (GroupPrincipal GroupPrincipal2 in search.FindAll())
                    {
                        cb_ou.Items.Add(GroupPrincipal2.Name);
                    }
                    // cb_ou.Items.SortDescriptions.Add(new System.ComponentModel.SortDescription("Content", System.ComponentModel.ListSortDirection.Descending));

                    cb_ou.Text = "Domain Users";


                }
                else
                {
                    MessageBox.Show("Your computer is not a member of domain", "Active Directory Users", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        //update 05/09/2019    Rachata.h
        public Users Users1 = new Users();
        public class Users : List<User> { }

        //update 05/09/2019    Rachata.h
        public class User
        {
            public String SamAccountName { get; set; }
            public String DisplayName { get; set; }
            public String Name { get; set; }
            public String GivenName { get; set; }
            public String Surname { get; set; }
            public String Email { get; set; }
            public String Description { get; set; }
            public Boolean? Enabled { get; set; }
            public DateTime? LastLogon { get; set; }

            public User(String SamAccountName, String DisplayName, String Name, String GivenName, String Surname,String Email, String Description,
                Boolean? Enabled, DateTime? LastLogon)
            {
                this.SamAccountName = SamAccountName;
                this.DisplayName = DisplayName;
                this.Name = Name;
                this.GivenName = GivenName;
                this.Surname = Surname;
                this.Email = Email;
                this.Description = Description;
                this.Enabled = Enabled;
                this.LastLogon = LastLogon;
            }
            public List<string> Properties()
            {
                return new List<string> { SamAccountName, DisplayName, Name, GivenName, Surname,Email, Description, Enabled.ToString(), LastLogon.ToString() };
            }
            public int UserPropertiesTotal = 8;
            public static string[] StringArrayUesrProperties = { "SamAccountName", "DisplayName", "Name", "GivenName", "Surname","Email", "Description", "Enabled", "LastLogon" };
        }

        //update 05/09/2019    Rachata.h
        private void ShowUsers()
        {
            //Check password
            Boolean boolPass;
            //Check groups
            Boolean boolGroup;
            Users1.Clear();
            int intCounter = 0;
            PrincipalContext PrincipalContext1 = new PrincipalContext(ContextType.Domain, stringDomainName);
            UserPrincipal UserPrincipal1 = new UserPrincipal(PrincipalContext1);
            PrincipalSearcher search = new PrincipalSearcher(UserPrincipal1);

            foreach (UserPrincipal result in search.FindAll())
            {                
                PrincipalSearchResult<Principal> PrincipalSearchResults1 = result.GetGroups();
                foreach (Principal PrincipalSearchResult1 in PrincipalSearchResults1)
                {
                    if (PrincipalSearchResult1.Name == cb_ou.SelectedItem.ToString())
                    {
                        boolGroup = true;
                        break;
                    }
                }

                User User1 = new User(result.SamAccountName, result.DisplayName, result.Name, result.GivenName, result.Surname,result.EmailAddress,result.Description, result.Enabled, result.LastLogon);
                Users1.Add(User1);
                intCounter++;
                //}
            }
            search.Dispose();
            dtg_domain.DataSource = Users1;
            dtg_domain.Update();
            dtg_domain.Refresh();
            //MessageBox.Show(intCounter + " users. ");
            EnumDataGrid1 = EunmDataGrid.users;

            int x = dtg_domain.Width;

            dtg_domain.Columns[0].Width = (10 * x) / 100;
            dtg_domain.Columns[1].Width = (10 * x) / 100;
            dtg_domain.Columns[2].Width = (10 * x) / 100;
            dtg_domain.Columns[3].Width = (10 * x) / 100;
            dtg_domain.Columns[4].Width = (10 * x) / 100;
            dtg_domain.Columns[5].Width = (10 * x) / 100;
            dtg_domain.Columns[6].Width = (20 * x) / 100;
            dtg_domain.Columns[7].Width = (5 * x) / 100;
            dtg_domain.Columns[8].Width = (10 * x) / 100;

            dtg_domain.Columns[0].DefaultCellStyle.BackColor = Color.Violet;
            dtg_domain.Columns[5].DefaultCellStyle.BackColor = Color.Violet;

         

        }
        private void frmAddUser_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char) (13))SendKeys .Send ("{Tab}");
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

           
            

            this.Close();
        }

  

        private void frmUserDetails_FormClosed(object sender, FormClosedEventArgs e)
        {
            //fc.Dispose();
        }
        
        //update 05/09/2019    Rachata.h
        private void btn_loaduser_Click(object sender, EventArgs e)
        {
            try
            {
                if (stringDomainName != null)
                {
                    txt_nameselect.Clear();
                    txt_emailselect.Clear();                   
                    idselect = 1;
                    ShowUsers();
                }
                else
                {
                    MessageBox.Show("Your computer is not a member of domain", "Active Directory Users", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message); // lbl_wait.Visible = false;
            }
        }
        
           

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dtg_domain = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.cb_ou = new System.Windows.Forms.ComboBox();
            this.txt_emailselect = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_nameselect = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dtg_domain)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtg_domain
            // 
            this.dtg_domain.AllowUserToAddRows = false;
            this.dtg_domain.AllowUserToDeleteRows = false;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtg_domain.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dtg_domain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtg_domain.DefaultCellStyle = dataGridViewCellStyle4;
            this.dtg_domain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtg_domain.Location = new System.Drawing.Point(0, 35);
            this.dtg_domain.Name = "dtg_domain";
            this.dtg_domain.ReadOnly = true;
            this.dtg_domain.RowHeadersWidth = 11;
            this.dtg_domain.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtg_domain.Size = new System.Drawing.Size(905, 525);
            this.dtg_domain.TabIndex = 68;
            this.dtg_domain.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dtg_domain_CellMouseClick);
            this.dtg_domain.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dtg_domain_CellMouseDoubleClick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cb_ou);
            this.panel1.Controls.Add(this.txt_emailselect);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txt_nameselect);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(905, 35);
            this.panel1.TabIndex = 69;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 20);
            this.label1.TabIndex = 60;
            this.label1.Text = "OU:";
            // 
            // cb_ou
            // 
            this.cb_ou.FormattingEnabled = true;
            this.cb_ou.Location = new System.Drawing.Point(55, 4);
            this.cb_ou.Name = "cb_ou";
            this.cb_ou.Size = new System.Drawing.Size(160, 28);
            this.cb_ou.TabIndex = 59;
            this.cb_ou.SelectedIndexChanged += new System.EventHandler(this.cb_ou_SelectedIndexChanged);
            // 
            // txt_emailselect
            // 
            this.txt_emailselect.Location = new System.Drawing.Point(537, 4);
            this.txt_emailselect.Name = "txt_emailselect";
            this.txt_emailselect.Size = new System.Drawing.Size(227, 26);
            this.txt_emailselect.TabIndex = 58;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(492, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 20);
            this.label2.TabIndex = 57;
            this.label2.Text = "อีเมล์:";
            // 
            // txt_nameselect
            // 
            this.txt_nameselect.Location = new System.Drawing.Point(324, 4);
            this.txt_nameselect.Name = "txt_nameselect";
            this.txt_nameselect.Size = new System.Drawing.Size(162, 26);
            this.txt_nameselect.TabIndex = 56;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(234, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 20);
            this.label3.TabIndex = 55;
            this.label3.Text = "ชื่อเข้าระบบ:";
            // 
            // F_UserAD
            // 
            this.ClientSize = new System.Drawing.Size(905, 560);
            this.Controls.Add(this.dtg_domain);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "F_UserAD";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "User Account on Active Directory Sapthip";
            this.Load += new System.EventHandler(this.FormUserDetails_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtg_domain)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        private void FormUserDetails_Load(object sender, EventArgs e)
        {
            Load_AD();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dtg_domain_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {

                txt_nameselect.Text = dtg_domain.Rows[e.RowIndex].Cells[0].Value.ToString();
              
            }
            catch
            {
                txt_nameselect.Clear(); 
            }

            try
            {

                txt_emailselect.Text = dtg_domain.Rows[e.RowIndex].Cells[5].Value.ToString();
            }
            catch
            {
                txt_emailselect.Clear();
            }
        }

        private void cb_ou_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowUsers();
        }

        private void dtg_domain_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            id_user = txt_nameselect.Text.Trim();
            email_user = txt_emailselect.Text.Trim();
            this.Close();
        }
    }
}
