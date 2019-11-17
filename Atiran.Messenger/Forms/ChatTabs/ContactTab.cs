using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Atiran.DataLayer.Context;
using Atiran.DataLayer.Model;
using Atiran.DataLayer.Services.Messenger;
using Atiran.Utility.Docking2;
using Form = Atiran.DataLayer.Model.Form;

namespace Atiran.Messenger.Forms.ChatTabs
{
    public class ContactTab : DockContent
    {
        private List<contacts> _historyUser;

        private string _userName;
        private DockPanel _dockPanel;
        private List<Users> AllUsers;
        //private List<Contacts> HistoryUserChat;
        private System.Windows.Forms.TextBox txtSearch;
        public Timer timer1;
        private System.ComponentModel.IContainer components;
        private DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridView dataGridView1;

        public ContactTab(DockPanel dockPanel, string UserName)
        {
            InitializeComponent();
            _userName = UserName;
            _dockPanel = dockPanel;
            _historyUser = Connection.GetHistoryContactse(_userName);
        }
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtSearch
            // 
            this.txtSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtSearch.Location = new System.Drawing.Point(0, 0);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtSearch.Size = new System.Drawing.Size(284, 28);
            this.txtSearch.TabIndex = 0;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.ColumnHeadersVisible = false;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.GridColor = System.Drawing.Color.White;
            this.dataGridView1.Location = new System.Drawing.Point(0, 28);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(284, 233);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dataGridView1_MouseDoubleClick);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Column1";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // timer1
            // 
            this.timer1.Interval = 5000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Contact
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.txtSearch);
            this.DockAreas = ((Atiran.Utility.Docking2.DockAreas)((Atiran.Utility.Docking2.DockAreas.DockLeft | Atiran.Utility.Docking2.DockAreas.DockRight)));
            this.Font = new System.Drawing.Font("IRANSans(FaNum)", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HideOnClose = true;
            this.Name = "Contact";
            this.ShowHint = Atiran.Utility.Docking2.DockState.DockLeft;
            this.Load += new System.EventHandler(this.Contact_Load);
            this.Enter += new System.EventHandler(this.Contact_Enter);
            this.Validated += new System.EventHandler(this.Contact_Validated);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void Contact_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = _historyUser;
            SetGrid();
            AllUsers = Connection.AllUser;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (IsHidden)
            { timer1.Stop(); }
            else
            {
                _historyUser = Connection.GetHistoryContactse(_userName);
                dataGridView1.DataSource = _historyUser;
                SetGrid();
            }
        }

        private void Contact_Validated(object sender, EventArgs e)
        {
            if (IsHidden)
                timer1.Stop();
        }

        private void Contact_Enter(object sender, EventArgs e)
        {
            timer1.Start();
        }


        #region Method

        private void SetGrid()
        {
            foreach (DataGridViewColumn col in dataGridView1.Columns)
            {
                col.Visible = false;
            }

            dataGridView1.Columns["Image"].Visible = true;
            dataGridView1.Columns["Image"].Width = 30;
            dataGridView1.Columns["Image"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns["Image"].HeaderText = "عكس كاربر";

            dataGridView1.Columns["UserName"].Visible = true;
            dataGridView1.Columns["UserName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns["UserName"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns["UserName"].HeaderText = "نام كاربر";

            dataGridView1.Columns["MessageNotRed"].Visible = true;
            dataGridView1.Columns["MessageNotRed"].Width = 20;
            dataGridView1.Columns["MessageNotRed"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns["MessageNotRed"].HeaderText = "تعدا پيام هاي خوانده نشده";

            dataGridView1.Columns["situation"].Visible = true;
            dataGridView1.Columns["situation"].Width = 10;
            dataGridView1.Columns["situation"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns["situation"].HeaderText = "وضعيت انلايني كاربر";
        }

        private void OpenTab(string UserName)
        {
            if (!(((System.Windows.Forms.Form)TopLevelControl).MdiChildren).Any(a => a.Text == UserName))
            {
                var ChatTab = new ChatHistory();
                ChatTab.Text = UserName;
                ChatTab.Show(_dockPanel);
            }
            else
            {
                (((System.Windows.Forms.Form)TopLevelControl).MdiChildren).First(f => f.Text == UserName).Focus();
            }
        }

        #endregion

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Enter:
                    {
                        if (dataGridView1.SelectedRows.Count > 0)
                        {
                            OpenTab(dataGridView1.SelectedRows[0].Cells["UserName"].Value.ToString());
                        }
                        return true;
                    }
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }



        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            OpenTab(dataGridView1.SelectedRows[0].Cells["UserName"].Value.ToString());
        }
    }
}
