using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Atiran.DataLayer.Context;
using Atiran.DataLayer.Model;
using Atiran.Utility.Docking2;
using Atiran.Utility.Docking2.Desk;

namespace Atiran.Messenger.Forms.ChatTabs
{
    class ChatHistory : DeskTab
    {
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.RichTextBox rtxtMessage;

        private string _userName;
        private int _userIdFrom, _userIdTo;
        private ContextMenuStrip contextMenuStrip1;
        private System.ComponentModel.IContainer components;
        private ToolStripMenuItem tsmiEditMessage;
        private Timer timer1;
        private ToolStripMenuItem tsmiDeleteMessage;
        private List<Messages> _historyMessagese;

        public ChatHistory(string UserName)
        {
            InitializeComponent();
            ShowQuestionClose = false;
            _userName = UserName;
            _historyMessagese = Connection.GetMessages(_userIdFrom);
            dataGridView1.DataSource = _historyMessagese;
            SetGrid();
        }
        
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiEditMessage = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDeleteMessage = new System.Windows.Forms.ToolStripMenuItem();
            this.panel3 = new System.Windows.Forms.Panel();
            this.rtxtMessage = new System.Windows.Forms.RichTextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnSend = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
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
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(614, 60);
            this.panel1.TabIndex = 0;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(178, 9);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(375, 39);
            this.textBox1.TabIndex = 3;
            this.textBox1.Visible = false;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(559, 9);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(49, 42);
            this.button2.TabIndex = 2;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(59, 54);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dataGridView1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 60);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(614, 283);
            this.panel2.TabIndex = 1;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.ColumnHeadersVisible = false;
            this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.GridColor = System.Drawing.Color.White;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(614, 283);
            this.dataGridView1.TabIndex = 0;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiEditMessage,
            this.tsmiDeleteMessage});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.contextMenuStrip1.Size = new System.Drawing.Size(111, 48);
            // 
            // tsmiEditMessage
            // 
            this.tsmiEditMessage.Name = "tsmiEditMessage";
            this.tsmiEditMessage.Size = new System.Drawing.Size(110, 22);
            this.tsmiEditMessage.Text = "ويرايش";
            this.tsmiEditMessage.Click += new System.EventHandler(this.tsmiEditMessage_Click);
            // 
            // tsmiDeleteMessage
            // 
            this.tsmiDeleteMessage.Name = "tsmiDeleteMessage";
            this.tsmiDeleteMessage.Size = new System.Drawing.Size(110, 22);
            this.tsmiDeleteMessage.Text = "حذف";
            this.tsmiDeleteMessage.Click += new System.EventHandler(this.tsmiDeleteMessage_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.rtxtMessage);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 343);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(614, 56);
            this.panel3.TabIndex = 2;
            // 
            // rtxtMessage
            // 
            this.rtxtMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtxtMessage.Location = new System.Drawing.Point(0, 0);
            this.rtxtMessage.Name = "rtxtMessage";
            this.rtxtMessage.Size = new System.Drawing.Size(539, 56);
            this.rtxtMessage.TabIndex = 0;
            this.rtxtMessage.Text = "";
            this.rtxtMessage.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rtxtMessage_KeyDown);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.btnSend);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel4.Location = new System.Drawing.Point(539, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(75, 56);
            this.panel4.TabIndex = 1;
            // 
            // btnSend
            // 
            this.btnSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSend.Location = new System.Drawing.Point(6, 9);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(66, 38);
            this.btnSend.TabIndex = 1;
            this.btnSend.Text = "button1";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // ChatHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.ClientSize = new System.Drawing.Size(614, 399);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Name = "ChatHistory";
            this.ToolTipText = "";
            this.Load += new System.EventHandler(this.ChatHistory_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private void ChatHistory_Load(object sender, EventArgs e)
        {
            _userIdFrom = Connection.AllUser.First(f => f.UserName == _userName).UserID;
            _userIdTo = Connection.AllUser.First(f => f.UserName == Text).UserID;
            if (!(Connection.AllUser.First(f => f.UserName == Text).avtive ?? true))
            {
                MessageBox.Show("هشدار", "كاربر از سيستم حذف شده امكان ارسال پيام به كاربر وجود ندارد.",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                btnSend.Enabled = false;
                rtxtMessage.Enabled = false;
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (rtxtMessage.Text.Trim() != "")
                Send();
        }

        private void rtxtMessage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.Enter)
            {
                Send();
            }
        }

        private void tsmiEditMessage_Click(object sender, EventArgs e)
        {
            //edit
        }

        private void tsmiDeleteMessage_Click(object sender, EventArgs e)
        {
            //Show Form Delete and question Delete from content 
        }





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

        }

        private void Send()
        {
            if(Connection.SendMessage(rtxtMessage.Text, _userIdFrom, _userIdTo))
            {
                rtxtMessage.Text = "";
            }
        }

        #endregion

    }
}