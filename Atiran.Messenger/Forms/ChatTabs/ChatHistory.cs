﻿using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Atiran.DataLayer.Context;
using Atiran.DataLayer.Model;
using Atiran.Messenger.Class;
using Atiran.Utility.Docking2;
using Atiran.Utility.Docking2.Desk;

namespace Atiran.Messenger.Forms.ChatTabs
{
    class ChatHistory : DeskTab
    {
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Panel panel4;

        private string _userNameFrom, _userNameTo;
        private int _userIdFrom, _userIdTo;
        private ContextMenuStrip contextMenuStrip1;
        private System.ComponentModel.IContainer components;
        private ToolStripMenuItem tsmiEditMessage;
        private ToolStripMenuItem tsmiDeleteMessage;
        private List<Messages> _historyMessagese;
        private DataGridView dataGridView1;
        private Label label1;
        private TextBox txtMessage;
        private Label lblSituation;
        private Panel panel5;
        private PictureBox pictureBox1;
        private static PersianCalendar _pc = new PersianCalendar();

        public ChatHistory(string UserName)
        {
            InitializeComponent();
            ShowQuestionClose = false;
            _userNameFrom = UserName;
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChatHistory));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblSituation = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiEditMessage = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDeleteMessage = new System.Windows.Forms.ToolStripMenuItem();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnSend = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtSearch);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(634, 60);
            this.panel1.TabIndex = 3;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.pictureBox1);
            this.panel5.Controls.Add(this.lblSituation);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(105, 60);
            this.panel5.TabIndex = 5;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(6, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(59, 54);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // lblSituation
            // 
            this.lblSituation.AutoSize = true;
            this.lblSituation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.lblSituation.Location = new System.Drawing.Point(66, 34);
            this.lblSituation.Name = "lblSituation";
            this.lblSituation.Size = new System.Drawing.Size(0, 20);
            this.lblSituation.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(534, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "جستجو در پيام ها:";
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.Location = new System.Drawing.Point(109, 3);
            this.txtSearch.Multiline = true;
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtSearch.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtSearch.Size = new System.Drawing.Size(425, 51);
            this.txtSearch.TabIndex = 14;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dataGridView1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 60);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(634, 596);
            this.panel2.TabIndex = 2;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.ColumnHeadersVisible = false;
            this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(634, 596);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.TabStop = false;
            this.dataGridView1.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dataGridView1_DataBindingComplete);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Font = new System.Drawing.Font("IRANSans(FaNum)", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiEditMessage,
            this.tsmiDeleteMessage});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.contextMenuStrip1.Size = new System.Drawing.Size(117, 52);
            // 
            // tsmiEditMessage
            // 
            this.tsmiEditMessage.Name = "tsmiEditMessage";
            this.tsmiEditMessage.Size = new System.Drawing.Size(116, 24);
            this.tsmiEditMessage.Text = "ويرايش";
            this.tsmiEditMessage.Click += new System.EventHandler(this.tsmiEditMessage_Click);
            // 
            // tsmiDeleteMessage
            // 
            this.tsmiDeleteMessage.Name = "tsmiDeleteMessage";
            this.tsmiDeleteMessage.Size = new System.Drawing.Size(116, 24);
            this.tsmiDeleteMessage.Text = "حذف";
            this.tsmiDeleteMessage.Click += new System.EventHandler(this.tsmiDeleteMessage_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.txtMessage);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 656);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(634, 93);
            this.panel3.TabIndex = 2;
            // 
            // txtMessage
            // 
            this.txtMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMessage.Location = new System.Drawing.Point(0, 0);
            this.txtMessage.Multiline = true;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtMessage.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtMessage.Size = new System.Drawing.Size(559, 93);
            this.txtMessage.TabIndex = 12;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.btnSend);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel4.Location = new System.Drawing.Point(559, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(75, 93);
            this.panel4.TabIndex = 0;
            // 
            // btnSend
            // 
            this.btnSend.BackColor = System.Drawing.Color.White;
            this.btnSend.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnSend.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSend.Location = new System.Drawing.Point(0, 55);
            this.btnSend.Name = "btnSend";
            this.btnSend.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnSend.Size = new System.Drawing.Size(75, 38);
            this.btnSend.TabIndex = 13;
            this.btnSend.Text = "ارسال";
            this.btnSend.UseVisualStyleBackColor = false;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            this.btnSend.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnSend_KeyDown);
            this.btnSend.MouseEnter += new System.EventHandler(this.btnSend_MouseEnter);
            this.btnSend.MouseLeave += new System.EventHandler(this.btnSend_MouseLeave);
            // 
            // ChatHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.ClientSize = new System.Drawing.Size(634, 749);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("IRANSans(FaNum)", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ChatHistory";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.RightToLeftLayout = false;
            this.ToolTipText = "";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ChatHistory_FormClosed);
            this.Load += new System.EventHandler(this.ChatHistory_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private void ChatHistory_Load(object sender, EventArgs e)
        {
            _userNameTo = this.Text;


            _userIdFrom = Connection.AllUser.First(f => f.UserName == _userNameFrom).UserID;
            _userIdTo = Connection.AllUser.First(f => f.UserName == _userNameTo).UserID;

            var ali = Connection.GetMessages(_userIdFrom, _userIdTo);
            _historyMessagese = (ali.Count > 0) ? ali : new List<Messages>();
            dataGridView1.DataSource = _historyMessagese;
            SetGrid();
            dataGridView1.Columns[dataGridView1.ColumnCount - 1].Selected = true;

            if (!(Connection.AllUser.First(f => f.UserName == Text).avtive ?? true))
            {
                MessageBox.Show("هشدار", "كاربر از سيستم حذف شده امكان ارسال پيام به كاربر وجود ندارد.",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                btnSend.Enabled = false;
                txtMessage.Enabled = false;
            }
            //دريافت پيام از سرور فعال ميشود
            else
            {
                //th = new Thread(listenRoutine);
                listenRoutineLocal();
                //th.IsBackground = true;
                ////th.Priority = ThreadPriority.Normal;
                //th.Start();

                //مارك كردن پيام هاي خوانده نشده اين كاربر 
                //model : 7|to|red|From

                sendMessageToServerLocal("login|" + Text);

            }
            //--------
        }

        #region Event

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (txtMessage.Text.Trim() != "")
                Send();
        }

        private void tsmiEditMessage_Click(object sender, EventArgs e)
        {
            //edit
        }

        private void tsmiDeleteMessage_Click(object sender, EventArgs e)
        {
            //Show Form Delete and question Delete from content 
        }

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells["FromTocen"].Value.ToString() == _userIdFrom.ToString())
                {
                    row.DefaultCellStyle.BackColor = Color.SkyBlue;
                    row.Cells["Text"].Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                    //row.DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight;
                }
            }
        }

        private void btnSend_MouseEnter(object sender, EventArgs e)
        {
            btnSend.BackColor = Color.DeepSkyBlue;
        }

        private void btnSend_MouseLeave(object sender, EventArgs e)
        {
            btnSend.BackColor = Color.White;
        }

        private void btnSend_KeyDown(object sender, KeyEventArgs e)
        {
            btnSend.BackColor = Color.MediumAquamarine;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (txtSearch.Text.Trim() != "")
            {
                dataGridView1.DataSource = _historyMessagese.Where(w => w.Text.Contains(txtSearch.Text)).ToList();
                if (dataGridView1.Rows.Count > 0)
                {
                    dataGridView1.Rows[dataGridView1.Rows.Count - 1].Selected = true;
                }
            }
            else if (txtMessage.Text == "")
            {
                dataGridView1.DataSource = _historyMessagese.ToList();
                dataGridView1.Columns[dataGridView1.ColumnCount - 1].Selected = true;
            }

        }

        private void ChatHistory_FormClosed(object sender, FormClosedEventArgs e)
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
            if ((Keys.Enter | Keys.Control) == keyData && txtMessage.Focused)
            {
                if (txtMessage.Text.Trim() != "")
                    Send();
                return true;
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

            dataGridView1.Columns["Text"].Visible = true;
            dataGridView1.Columns["Text"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns["Text"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridView1.Columns["Text"].HeaderText = "پيام";

            dataGridView1.Columns["DateTimeSend"].Visible = true;
            dataGridView1.Columns["DateTimeSend"].Width = 65;
            dataGridView1.Columns["DateTimeSend"].HeaderText = "تاريخ ارسال پيام";
            dataGridView1.Columns["DateTimeSend"].DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

        }

        private void Send()
        {
            //var dt = DateTime.Now;
            //var Message = new Message_Temp()
            //{
            //    Text = txtMessage.Text.Trim(),
            //    FromTocen = _userIdFrom,
            //    ToTocen = _userIdTo,
            //    DateTimeSend = _pc.GetYear(dt).ToString("0000") + "/" + _pc.GetMonth(dt).ToString("00") + "/" + _pc.GetDayOfMonth(dt).ToString("00") + " " + dt.Hour.ToString("00") + ":" + dt.Minute.ToString("00") + ":" + dt.Second.ToString("00"),
            //    MessageDeleteFrom = false,
            //    MessageDeleteTo = false,
            //    MessageID = Connection.AllUser.First(f => f.UserID == _userIdFrom).NextMessageID ?? 1
            //};
            //if (Connection.SendMessage(Message))
            //{
            //    txtMessage.Text = "";
            //    var MessageSend = new Messages()
            //    {
            //        Text = Message.Text,
            //        FromTocen = Message.FromTocen,
            //        ToTocen = Message.ToTocen,
            //        MessageDeleteTo = Message.MessageDeleteTo,
            //        MessageID = Message.MessageID,
            //        MessageDeleteFrom = Message.MessageDeleteFrom,
            //        DateTimeSend = Message.DateTimeSend
            //    };
            //    _historyMessagese.Add(MessageSend);
            //    dataGridView1.DataSource = _historyMessagese.ToList();
            //    SetGrid();
            //}
            //else
            //{
            //    MessageBox.Show("خطا", "مشكل در ارتباط وجود دارد لطفا مجددا تلاش كنيد", MessageBoxButtons.OK,
            //        MessageBoxIcon.Error);
            //}
            sendMessageToServerLocal("send|" + _userNameFrom + "|" + txtMessage.Text.Trim() + "|" + _userNameTo);

        }

        #endregion

        #region Messenger Link To Server Local

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
            string who;
            string str;

            await Task.Run(
                () =>
                {
                    while (true)
                    {
                        try
                        {
                            inLength = T.ReceiveFrom(buffer, ref serverEP);

                            msg = Encoding.UTF8.GetString(buffer, 0, inLength);

                            string[] c = msg.Split('|');
                            cmd = c[0];
                            who = c[1];
                            str = c[2];
                            //MessageBox.Show("CLIENT   Cmd:" + cmd + " Who:" + who+ " Str:" + str);
                            switch (cmd)
                            {
                                case "0":
                                case "99":
                                    {
                                        string[] M = str.Split(',');
                                        if (M.Any(a => a == _userNameTo))
                                        {
                                            lblSituation.Text = "انلاين";
                                            lblSituation.BackColor = Color.FromArgb(128, 255, 128);
                                        }
                                        else
                                        {
                                            lblSituation.Text = "افلاين";
                                            lblSituation.BackColor = Color.FromArgb(255, 192, 128);
                                        }

                                        break;
                                    }

                                case "2":
                                    {
                                        int fromId = Connection.AllUser.FirstOrDefault(f => f.UserName == who).UserID;
                                        int toId = Connection.AllUser.FirstOrDefault(f => f.UserName == c[3]).UserID;
                                        string dateTime = c[4];
                                        string MessageId = c[5];
                                        var MessageSend = new Messages()
                                        {
                                            Text = str,
                                            FromTocen = fromId,
                                            ToTocen = toId,
                                            MessageDeleteTo = false,
                                            MessageDeleteFrom = false,
                                            DateTimeSend = dateTime,
                                            MessageID = Convert.ToInt32(MessageId)
                                        };
                                        if (fromId == _userIdFrom && toId == _userIdTo)
                                        {
                                            _historyMessagese.Add(MessageSend);
                                            dataGridView1.DataSource = _historyMessagese.ToList();
                                            //flashWindow();
                                            txtMessage.Text = "";
                                            dataGridView1.Columns[dataGridView1.ColumnCount - 1].Selected = true;
                                        }
                                        else if (toId == _userIdFrom && fromId == _userIdTo)
                                        {

                                            _historyMessagese.Add(MessageSend);
                                            dataGridView1.DataSource = _historyMessagese.ToList();
                                            dataGridView1.Columns[dataGridView1.ColumnCount - 1].Selected = true;
                                            //flashWindow();

                                        }

                                        break;
                                    }

                            }
                        }
                        catch (Exception)
                        {
                            T.Close();
                            MessageBox.Show("ارتباط با سرور لوكال پيام رسان ممکن نیست!");
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
                MessageBox.Show("اتصال سوكت برقرار نيست");
            }
        }

        #endregion

        //#region Flash Window

        //[DllImport("user32.dll")]
        //private static extern bool FlashWindowEx(ref FLASHWINFO fi);

        //private struct FLASHWINFO
        //{
        //    public uint cbSize;
        //    public IntPtr hwnd;
        //    public uint dwFlags;
        //    public uint uCount;
        //    public uint dwTimeout;
        //}
        //private void flashWindow()
        //{
        //    FLASHWINFO FlashWINInfo = new FLASHWINFO();
        //    FlashWINInfo.cbSize = Convert.ToUInt32(Marshal.SizeOf(FlashWINInfo));
        //    FlashWINInfo.hwnd = this.Handle;
        //    FlashWINInfo.dwFlags = 3 | 2 | 12;
        //    FlashWINInfo.uCount = uint.MaxValue;
        //    FlashWINInfo.dwTimeout = 0;
        //    FlashWindowEx(ref FlashWINInfo);
        //}

        //#endregion

        //private async void SetMessage()
        //{
        //    await System.Threading.Tasks.Task.Run(() => MessageBox.Show("Test"));
        //}
    }
}