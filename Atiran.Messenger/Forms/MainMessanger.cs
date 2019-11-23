using System;
using System.Collections;
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
        private ToolStripDropDownButton ListServerLocal;
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
            this.ListServerLocal = new System.Windows.Forms.ToolStripDropDownButton();
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
            this.toolStripComboBox2,
            this.ListServerLocal});
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
            // ListServerLocal
            // 
            this.ListServerLocal.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ListServerLocal.Image = ((System.Drawing.Image)(resources.GetObject("ListServerLocal.Image")));
            this.ListServerLocal.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ListServerLocal.Name = "ListServerLocal";
            this.ListServerLocal.Size = new System.Drawing.Size(196, 22);
            this.ListServerLocal.Text = "ليست فرم هاي متصل به سرور لوكال";
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

            //start Server Local For Menage Form
            StartServerRoutineLocal();

            //conect Server Local To Server
            listenRoutineServer();
        }

        #region Event

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

        #endregion

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

        #region Server Local

        private object listlocker = new Object();
        private object sendlocker = new Object();
        private object receivelocker = new Object();

        TcpListener serverLocal;
        Socket clientFormSocket;
        //Thread serverLocalTh;
        Thread clientFormTh;
        Hashtable HT = new Hashtable();
        //string serverIP = ServiceServer.serverIPLocal;
        //private string serverPort = ServiceServer.serverPortLocal;

        private async void StartServerRoutineLocal()
        {
            IPEndPoint EP = new IPEndPoint(IPAddress.Parse(ServiceServer.serverIPLocal), int.Parse(ServiceServer.serverPortLocal));
            serverLocal = new TcpListener(EP);
            serverLocal.Start(100);
            while (true)
            {
                clientFormSocket = await Task.Run(() => serverLocal.AcceptSocket());
                clientFormTh = new Thread(clientRoutine);
                clientFormTh.IsBackground = true;
                //clientTh.Priority = ThreadPriority.Normal;
                clientFormTh.Start();
            }
        }

        private void clientRoutine()
        {
            Socket sck = clientFormSocket;
            Thread th = clientFormTh;
            string socketname = "";
            try
            {
                while (true)
                {

                    byte[] buffer = new byte[4096];
                    int inLength = sck.Receive(buffer);
                    lock (receivelocker)
                    {
                        string msg = Encoding.UTF8.GetString(buffer, 0, inLength);
                        string[] c = msg.Split('|');
                        string cmd = c[0];
                        switch (cmd.ToLower())
                        {
                            case "login": // for Form login
                                {
                                    string FormName = c[1];
                                    socketname = FormName;
                                    lock (listlocker)
                                    {
                                        //add Socket Form To List Socket in Servr Local
                                        HT.Add(socketname, sck);
                                        ListServerLocal.DropDown.Items.Add(socketname);
                                        //sendMessageToServer("7|" + _userName + "|red|" + socketname);

                                    }

                                    break;
                                }
                            case "send":
                                {

                                    lock (sendlocker)
                                    {
                                        string[] msg1 = c;
                                        c[0] = "2";
                                        string ms = "";
                                        foreach (string s in msg1)
                                        {
                                            ms += s + "|";
                                        }
                                        //ms checi shavad ka dorost bashad
                                        ms = ms.Remove(ms.Length - 1);
                                        // sent message from Server Local To Server
                                        sendMessageToServer(ms);
                                    }

                                    break;
                                }
                            case "close":
                                {
                                    lock (listlocker)
                                    {
                                        HT.Remove(socketname);
                                        var ali = ListServerLocal.DropDown.Items.Cast<ToolStripItem>()
                                            .FirstOrDefault(w => w.Text == socketname);
                                        if (ali != null)
                                            ListServerLocal.DropDown.Items.Remove(ali);
                                    }
                                    break;
                                }
                        }
                    }

                }
            }
            catch (Exception)
            {
                lock (receivelocker)
                {
                    lock (listlocker)
                    {
                        HT.Remove(socketname);
                        var ali = ListServerLocal.DropDown.Items.Cast<ToolStripItem>()
                            .FirstOrDefault(w => w.Text == socketname);
                        if (ali != null)
                            ListServerLocal.DropDown.Items.Remove(ali);
                    }
                }

                th.Abort();
            }
        }

        private void sendToAllForms(string str)
        {

            byte[] buffer = Encoding.UTF8.GetBytes(str);

            lock (listlocker)
            {

                foreach (Socket s in HT.Values)
                {
                    try
                    {
                        lock (sendlocker)
                        {
                            s.Send(buffer, 0, buffer.Length, SocketFlags.None);
                        }
                    }
                    catch (Exception)
                    {
                        ;
                    }
                }
            }
        }

        #endregion

        #region Server Local To Server

        private async void listenRoutineServer()
        {
            EndPoint serverEP = (EndPoint)ServiceServer.socketSever.RemoteEndPoint;
            byte[] buffer = new byte[4096];
            int inLength = 0;
            string msg;
            while (true)
            {
                await Task.Run(() =>
                {
                    try
                    {
                        inLength = ServiceServer.socketSever.ReceiveFrom(buffer, ref serverEP);
                    }

                    catch (Exception e)
                    {
                        var ali = e.Message;
                        //th.Abort();
                        //break;
                        //continue;
                    }
                });

                msg = Encoding.UTF8.GetString(buffer, 0, inLength);
                sendToAllForms(msg);
            }
        }

        private void sendMessageToServer(string str)
        {
            if (ServiceServer.socketSever.Connected)
            {
                byte[] buffer = Encoding.UTF8.GetBytes(str);
                ServiceServer.socketSever.Send(buffer, 0, buffer.Length, SocketFlags.None);
            }
            else
            {
                MessageBox.Show("اتصال سوكت برقرار نيست");
            }
        }

        #endregion

        private void MainMessanger_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                HT.Clear();

                //serverLocalTh.Abort();
                clientFormSocket.Close();
                clientFormSocket.Dispose();
                clientFormTh.Abort();
            }
            catch (Exception)
            {
            }
        }

    }
}
