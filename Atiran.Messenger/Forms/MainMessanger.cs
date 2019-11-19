using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Atiran.DataLayer.Context;
using Atiran.DataLayer.Model;
using Atiran.Messenger.Class;
using Atiran.Messenger.Forms.ChatTabs;
using Atiran.Utility.Docking2;
using Form = System.Windows.Forms.Form;

namespace Atiran.Messenger.Forms
{
    public class MainMessanger : Form
    {
        private Atiran.Utility.Docking2.Theme.ThemeVS2017.VS2017LightTheme vS2017LightTheme1;
        private DockPanel dockPanel1;
        private ContactTab _contactTab;
        private string _userName;
        private ToolStrip toolStrip1;
        private ToolStripButton tsbContact;
        private ToolStripSplitButton tssbProfile;
        private ToolStripComboBox toolStripComboBox2;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainMessanger));
            this.vS2017LightTheme1 = new Atiran.Utility.Docking2.Theme.ThemeVS2017.VS2017LightTheme();
            this.dockPanel1 = new Atiran.Utility.Docking2.DockPanel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbContact = new System.Windows.Forms.ToolStripButton();
            this.tssbProfile = new System.Windows.Forms.ToolStripSplitButton();
            this.toolStripComboBox2 = new System.Windows.Forms.ToolStripComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dockPanel1)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dockPanel1
            // 
            this.dockPanel1.AllowDrop = true;
            this.dockPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dockPanel1.DockBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(242)))));
            this.dockPanel1.Font = new System.Drawing.Font("IRANSans(FaNum)", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dockPanel1.Location = new System.Drawing.Point(0, 0);
            this.dockPanel1.Name = "dockPanel1";
            this.dockPanel1.Padding = new System.Windows.Forms.Padding(6);
            this.dockPanel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dockPanel1.RightToLeftLayout = true;
            this.dockPanel1.ShowAutoHideContentOnHover = false;
            this.dockPanel1.ShowDocumentIcon = true;
            this.dockPanel1.Size = new System.Drawing.Size(793, 711);
            this.dockPanel1.TabIndex = 2;
            this.dockPanel1.TabStop = true;
            this.dockPanel1.Theme = this.vS2017LightTheme1;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbContact,
            this.tssbProfile,
            this.toolStripComboBox2});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.toolStrip1.Size = new System.Drawing.Size(793, 25);
            this.toolStrip1.TabIndex = 5;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbContact
            // 
            this.tsbContact.Image = ((System.Drawing.Image)(resources.GetObject("tsbContact.Image")));
            this.tsbContact.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbContact.Name = "tsbContact";
            this.tsbContact.Size = new System.Drawing.Size(102, 22);
            this.tsbContact.Text = "ليست مخاطبين";
            this.tsbContact.Click += new System.EventHandler(this.tsbContact_Click);
            // 
            // tssbProfile
            // 
            this.tssbProfile.Image = ((System.Drawing.Image)(resources.GetObject("tssbProfile.Image")));
            this.tssbProfile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tssbProfile.Name = "tssbProfile";
            this.tssbProfile.Size = new System.Drawing.Size(74, 22);
            this.tssbProfile.Text = "پروفايل";
            this.tssbProfile.Click += new System.EventHandler(this.tssbProfile_Click);
            // 
            // toolStripComboBox2
            // 
            this.toolStripComboBox2.Name = "toolStripComboBox2";
            this.toolStripComboBox2.Size = new System.Drawing.Size(121, 25);
            this.toolStripComboBox2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.toolStripComboBox2_KeyDown);
            this.toolStripComboBox2.TextChanged += new System.EventHandler(this.toolStripComboBox2_TextChanged);
            // 
            // MainMessanger
            // 
            this.ClientSize = new System.Drawing.Size(793, 711);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.dockPanel1);
            this.Font = new System.Drawing.Font("IRANSans(FaNum)", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IsMdiContainer = true;
            this.Name = "MainMessanger";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainMessanger_FormClosed);
            this.Load += new System.EventHandler(this.MainMessanger_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dockPanel1)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void MainMessanger_Load(object sender, EventArgs e)
        {
            toolStripComboBox2.Items.Clear();
            toolStripComboBox2.Items.AddRange(AllUsers.ToArray());
            toolStripComboBox2.ComboBox.DisplayMember = "UserName";
            toolStripComboBox2.ComboBox.ValueMember = "UserID";
        }
        private void tsbContact_Click(object sender, EventArgs e)
        {
            _contactTab.Text = "ليست مخاطبين";
            _contactTab.Show(dockPanel1);
            
        }

        private void tssbProfile_Click(object sender, EventArgs e)
        {
            //profiler
        }
        private void toolStripComboBox2_TextChanged(object sender, EventArgs e)
        {
            toolStripComboBox2.Items.Clear();
            toolStripComboBox2.Items.AddRange(
                AllUsers.Where(w => w.UserName.Contains(toolStripComboBox2.Text)).ToArray());
            toolStripComboBox2.SelectionStart = toolStripComboBox2.Text.Length;
        }

        private void toolStripComboBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && toolStripComboBox2.Text.Trim() != "")
            {
                if (AllUsers.Any(a => a.UserName == toolStripComboBox2.Text.Trim()))
                {
                    OpenTab(toolStripComboBox2.Text);
                }
                else
                {
                    MessageBox.Show("كاربري با اين نام وجود ندارد دوباره تلاش كنيد.", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void MainMessanger_FormClosed(object sender, FormClosedEventArgs e)
        {
            _contactTab.th.Abort();
        }

        #region Method

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


        #endregion

    }
}
