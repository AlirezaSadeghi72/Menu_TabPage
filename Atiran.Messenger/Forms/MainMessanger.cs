using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Atiran.DataLayer.Context;
using Atiran.DataLayer.Model;
using Atiran.Messenger.Forms.ChatTabs;
using Atiran.Utility.Docking2;
using Form = System.Windows.Forms.Form;

namespace Atiran.Messenger.Forms
{
    public class MainMessanger : Form
    {
        private Atiran.Utility.Docking2.Theme.ThemeVS2017.VS2017LightTheme vS2017LightTheme1;
        private DockPanel dockPanel1;
        private ToolStripMenuItem tsmContact;
        private MenuStrip menuStrip1;
        private ContactTab _contactTab;
        private ToolStripMenuItem tsmProfile;
        private ToolStripComboBox toolStripComboBox1;
        private string _userName;

        private List<Users> AllUsers;
        //private DeskTab _deskTab;

        public MainMessanger(string UserName)
        {
            InitializeComponent();
            _userName = UserName;
            _contactTab = new ContactTab(dockPanel1, _userName);
            AllUsers = Connection.AllUser;
        }

        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tsmContact = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmProfile = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripComboBox1 = new System.Windows.Forms.ToolStripComboBox();
            this.vS2017LightTheme1 = new Atiran.Utility.Docking2.Theme.ThemeVS2017.VS2017LightTheme();
            this.dockPanel1 = new Atiran.Utility.Docking2.DockPanel();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dockPanel1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("IRANSans(FaNum)", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmContact,
            this.tsmProfile,
            this.toolStripComboBox1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.menuStrip1.Size = new System.Drawing.Size(793, 28);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tsmContact
            // 
            this.tsmContact.Font = new System.Drawing.Font("IRANSans(FaNum)", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsmContact.Name = "tsmContact";
            this.tsmContact.Size = new System.Drawing.Size(96, 24);
            this.tsmContact.Text = "ليست مخاطبين";
            this.tsmContact.Click += new System.EventHandler(this.tsmContact_Click);
            // 
            // tsmProfile
            // 
            this.tsmProfile.Name = "tsmProfile";
            this.tsmProfile.Size = new System.Drawing.Size(57, 24);
            this.tsmProfile.Text = "پروفايل";
            // 
            // toolStripComboBox1
            // 
            this.toolStripComboBox1.Name = "toolStripComboBox1";
            this.toolStripComboBox1.Size = new System.Drawing.Size(121, 24);
            this.toolStripComboBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.toolStripComboBox1_KeyDown);
            this.toolStripComboBox1.TextChanged += new System.EventHandler(this.toolStripComboBox1_TextChanged);
            // 
            // dockPanel1
            // 
            this.dockPanel1.AllowDrop = true;
            this.dockPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dockPanel1.DockBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(242)))));
            this.dockPanel1.Font = new System.Drawing.Font("IRANSans(FaNum)", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dockPanel1.Location = new System.Drawing.Point(0, 28);
            this.dockPanel1.Name = "dockPanel1";
            this.dockPanel1.Padding = new System.Windows.Forms.Padding(6);
            this.dockPanel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dockPanel1.RightToLeftLayout = true;
            this.dockPanel1.ShowAutoHideContentOnHover = false;
            this.dockPanel1.ShowDocumentIcon = true;
            this.dockPanel1.Size = new System.Drawing.Size(793, 683);
            this.dockPanel1.TabIndex = 2;
            this.dockPanel1.TabStop = true;
            this.dockPanel1.Theme = this.vS2017LightTheme1;
            // 
            // MainMessanger
            // 
            this.ClientSize = new System.Drawing.Size(793, 711);
            this.Controls.Add(this.dockPanel1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("IRANSans(FaNum)", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainMessanger";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainMessanger_FormClosed);
            this.Load += new System.EventHandler(this.MainMessanger_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dockPanel1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void MainMessanger_Load(object sender, EventArgs e)
        {
            toolStripComboBox1.Items.Clear();
            toolStripComboBox1.Items.AddRange(AllUsers.ToArray());
            toolStripComboBox1.ComboBox.DisplayMember = "UserName";
            toolStripComboBox1.ComboBox.ValueMember = "UserID";
        }

        private void tsmContact_Click(object sender, EventArgs e)
        {
            _contactTab.Text = "alireza";
            _contactTab.Show(dockPanel1);
        }

        private void MainMessanger_FormClosed(object sender, FormClosedEventArgs e)
        {
            _contactTab.timer1.Stop();

        }

        private void toolStripComboBox1_TextChanged(object sender, EventArgs e)
        {

            toolStripComboBox1.Items.Clear();
            toolStripComboBox1.Items.AddRange(
                AllUsers.Where(w => w.UserName.Contains(toolStripComboBox1.Text)).ToArray());
        }

        private void toolStripComboBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && toolStripComboBox1.Text.Trim() != "")
            {
                if (AllUsers.Any(a => a.UserName == toolStripComboBox1.Text.Trim()))
                {
                    OpenTab(toolStripComboBox1.Text);
                }
                else
                {
                    MessageBox.Show("كاربري با اين نام وجود ندارد دوباره تلاش كنيد.", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void OpenTab(string UserName)
        {
            if (!MdiChildren.Any(a => a.Text == UserName))
            {
                var ChatTab = new ChatHistory(_userName);
                ChatTab.Text = UserName;
                ChatTab.Show(dockPanel1);
            }
            else
            {
                MdiChildren.First(f => f.Text == UserName).Focus();
            }
        }
    }
}
