using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Atiran.DataLayer.Context;
using Atiran.DataLayer.Model;
using Atiran.DataLayer.Services.Messenger;
using Atiran.Messenger.Class;
using Atiran.Utility.Docking2;
using Form = Atiran.DataLayer.Model.Form;

namespace Atiran.Messenger.Forms.ChatTabs
{
    public class ContactTab : DockContent
    {
        private List<contacts> _historyUser;

        private string _userName;
        private DockPanel _dockPanel;
        //private List<Users> AllUsers;
        private System.Windows.Forms.TextBox txtSearch;
        private ContextMenuStrip contextMenuStrip1;
        private System.ComponentModel.IContainer components;
        private ToolStripMenuItem tsmiDeleteContact;

        //private DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridView dataGridView1;

        public ContactTab(DockPanel dockPanel, string UserName)
        {
            InitializeComponent();
            _userName = UserName;
            _dockPanel = dockPanel;
            _historyUser = Connection.GetHistoryContacts(_userName);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiDeleteContact = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtSearch
            // 
            this.txtSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtSearch.Location = new System.Drawing.Point(0, 0);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtSearch.Size = new System.Drawing.Size(275, 28);
            this.txtSearch.TabIndex = 0;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.ColumnHeadersVisible = false;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.GridColor = System.Drawing.Color.White;
            this.dataGridView1.Location = new System.Drawing.Point(0, 28);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(275, 449);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dataGridView1_MouseDoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiDeleteContact});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(181, 48);
            // 
            // tsmiDeleteContact
            // 
            this.tsmiDeleteContact.Name = "tsmiDeleteContact";
            this.tsmiDeleteContact.Size = new System.Drawing.Size(180, 22);
            this.tsmiDeleteContact.Text = "حذف مخاطب";
            this.tsmiDeleteContact.Click += new System.EventHandler(this.tsmiDeleteContact_Click);
            // 
            // ContactTab
            // 
            this.ClientSize = new System.Drawing.Size(275, 477);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.txtSearch);
            this.DockAreas = ((Atiran.Utility.Docking2.DockAreas)((Atiran.Utility.Docking2.DockAreas.DockLeft | Atiran.Utility.Docking2.DockAreas.DockRight)));
            this.Font = new System.Drawing.Font("IRANSans(FaNum)", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HideOnClose = true;
            this.Name = "ContactTab";
            this.ShowHint = Atiran.Utility.Docking2.DockState.DockLeft;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ContactTab_FormClosed);
            this.Load += new System.EventHandler(this.Contact_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void Contact_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = _historyUser;
            SetGrid();
            //AllUsers = Connection.AllUser;
            //دريافت پيام از سرور فعال ميشود
            listenRoutineLocal();
            //--------
            sendMessageToServerLocal("login|" + Text);

        }

        #region Event

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = _historyUser.Where(w => w.UserName == txtSearch.Text.Trim()).ToList();
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            OpenTab(dataGridView1.SelectedRows[0].Cells["UserName"].Value.ToString());
        }

        private void tsmiDeleteContact_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var result = MessageBox.Show("آيا مخاطب " +
                                             dataGridView1.SelectedRows[0].Cells["UserName"].Value.ToString() +
                                             " حذف شود؟", "هشدار", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    sendMessageToServerLocal("4|" + _userName + "|delete|" +
                                             dataGridView1.SelectedRows[0].Cells["UserName"].Value.ToString());
                }
                else if (result == DialogResult.No)
                {
                    sendMessageToServerLocal("4|" + _userName + "|delete for contact|" +
                                             dataGridView1.SelectedRows[0].Cells["UserName"].Value.ToString());
                }
            }
        }

        private void ContactTab_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                sendMessageToServerLocal("close|" + Text);
                T.Close();
            }
            catch (Exception)
            {
            }
        }

        #endregion

        #region Event Override

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

        #endregion

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
            dataGridView1.Columns["MessageNotRed"].Width = 40;
            dataGridView1.Columns["MessageNotRed"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns["MessageNotRed"].HeaderText = "تعدا پيام هاي خوانده نشده";

            //dataGridView1.Columns["situation"].Visible = true;
            //dataGridView1.Columns["situation"].Width = 10;
            //dataGridView1.Columns["situation"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //dataGridView1.Columns["situation"].HeaderText = "وضعيت انلايني كاربر";
        }

        private void OpenTab(string UserNameTo)
        {
            if (!(((System.Windows.Forms.Form)TopLevelControl).MdiChildren).Any(a => a.Text == UserNameTo))
            {
                var ChatTab = new ChatHistory(_userName);
                ChatTab.Text = UserNameTo;
                ChatTab.Show(_dockPanel);
            }
            else
            {
                (((System.Windows.Forms.Form)TopLevelControl).MdiChildren).First(f => f.Text == UserNameTo).Focus();
            }
        }

        private void RefreshList()
        {
            _historyUser = Connection.GetHistoryContacts(_userName);
            dataGridView1.DataSource = _historyUser;
            SetGrid();
        }

        #endregion

        #region Messenger

        private Socket T;
        private async void listenRoutineLocal()
        {
            IPEndPoint EP = new IPEndPoint(IPAddress.Parse(ServiceServer.serverIPLocal),
                int.Parse(ServiceServer.serverPortLocal));

            T = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            T.Connect(EP);

            EndPoint serverEP = (EndPoint)T.RemoteEndPoint;
            byte[] buffer = new byte[4096];
            int inLength = 0;
            string msg;
            string cmd;

            await Task.Run(() =>
            {
                while (true)
                {
                    try
                    {
                        inLength = T.ReceiveFrom(buffer, ref serverEP);

                        msg = Encoding.UTF8.GetString(buffer, 0, inLength);

                        RefreshList();

                    }
                    catch (Exception)
                    {
                        T.Close();
                        //MessageBox.Show("ارتباط با سرور لوكال پيام رسان ممکن نیست!");
                        break;
                    }
                }
            });

        }

        private void sendMessageToServerLocal(string str)
        {
            if (T.Connected)
            {
                byte[] buffer = Encoding.UTF8.GetBytes(str);
                T.Send(buffer, 0, buffer.Length, SocketFlags.None);
            }
            else
            {
                //MessageBox.Show("اتصال سوكت برقرار نيست");
            }
        }


        #endregion

    }
}
