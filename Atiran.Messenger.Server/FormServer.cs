using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Atiran.Messenger.Server.DataLayer.Context;
using Atiran.Messenger.Server.DataLayer.Model;

namespace Atiran.Messenger.Server
{
    public class FormServer : Form
    {
        private object listlocker = new Object();
        private object sendlocker = new Object();
        private object receivelocker = new Object();
        private object sqlLocker = new Object();
        TcpListener server;
        Socket client;
        Thread serverTh;
        Thread clientTh;
        Hashtable HT = new Hashtable();
        string serverIP = IPAddress.Any.ToString();
        string serverPort = "1372";
        private PersianCalendar _pc = new PersianCalendar();

        public FormServer()
        {
            InitializeComponent();
        }

        private Panel panel1;
        private TextBox textBox1;
        private Label labelPort;
        private Button buttonStart;
        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel2;
        private Panel panel2;
        private Label label1;
        private ListBox listBoxUser;

        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.labelPort = new System.Windows.Forms.Label();
            this.buttonStart = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.listBoxUser = new System.Windows.Forms.ListBox();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.labelPort);
            this.panel1.Controls.Add(this.buttonStart);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(2, 3);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(162, 464);
            this.panel1.TabIndex = 0;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(60, 129);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(76, 20);
            this.textBox1.TabIndex = 3;
            this.textBox1.Text = "1372";
            // 
            // labelPort
            // 
            this.labelPort.AutoSize = true;
            this.labelPort.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPort.Location = new System.Drawing.Point(14, 131);
            this.labelPort.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelPort.Name = "labelPort";
            this.labelPort.Size = new System.Drawing.Size(43, 19);
            this.labelPort.TabIndex = 2;
            this.labelPort.Text = "Port: ";
            // 
            // buttonStart
            // 
            this.buttonStart.Font = new System.Drawing.Font("Calibri", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonStart.Location = new System.Drawing.Point(7, 8);
            this.buttonStart.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(143, 69);
            this.buttonStart.TabIndex = 1;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 166F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(400, 470);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.panel2, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.listBoxUser, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(168, 3);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(230, 464);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(2, 3);
            this.panel2.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(226, 36);
            this.panel2.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(58, 5);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 27);
            this.label1.TabIndex = 0;
            this.label1.Text = "User List";
            // 
            // listBoxUser
            // 
            this.listBoxUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxUser.Font = new System.Drawing.Font("Calibri", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxUser.FormattingEnabled = true;
            this.listBoxUser.ItemHeight = 27;
            this.listBoxUser.Location = new System.Drawing.Point(2, 45);
            this.listBoxUser.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.listBoxUser.Name = "listBoxUser";
            this.listBoxUser.Size = new System.Drawing.Size(226, 416);
            this.listBoxUser.TabIndex = 1;
            this.listBoxUser.SizeChanged += new System.EventHandler(this.listBoxUser_SizeChanged);
            // 
            // FormServer
            // 
            this.ClientSize = new System.Drawing.Size(400, 470);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FormServer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormServer_FormClosing);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #region Event

        private void buttonStart_Click(object sender, EventArgs e)
        {
            serverPort = textBox1.Text;
            textBox1.Enabled = false;
            CheckForIllegalCrossThreadCalls = false;
            serverTh = new Thread(serverRoutine);
            serverTh.IsBackground = true;
            //serverTh.Priority = ThreadPriority.Normal;
            serverTh.Start();
            buttonStart.Enabled = false;
        }
        private void listBoxUser_SizeChanged(object sender, EventArgs e)
        {
            //فردي انلاين شده
            //sendToAll("0" + "|server|" + getOnlineList());
        }
        private void FormServer_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.ExitThread();
        }

        #endregion


        #region Method

        private void serverRoutine()
        {
            IPEndPoint EP = new IPEndPoint(IPAddress.Parse(serverIP), int.Parse(serverPort));
            server = new TcpListener(EP);
            server.Start(100);
            while (true)
            {
                client = server.AcceptSocket();
                clientTh = new Thread(clientRoutine);
                clientTh.IsBackground = true;
                //clientTh.Priority = ThreadPriority.Normal;
                clientTh.Start();
            }
        }

        private void clientRoutine()
        {
            Socket sck = client;
            Thread th = clientTh;

            string socketname = "";
            while (true)
            {

                try
                {
                    byte[] buffer = new byte[4096];
                    string repeatedName = "64|server|repeated username";
                    int inLength = sck.Receive(buffer);
                    lock (receivelocker)
                    {
                        string msg = Encoding.UTF8.GetString(buffer, 0, inLength);
                        string[] c = msg.Split('|');
                        string cmd = c[0];
                        string who = c[1];
                        string str = c[2];
                        DateTime dt = DateTime.Now;
                        string dateTime = _pc.GetYear(dt).ToString("0000") + "/" + _pc.GetMonth(dt).ToString("00") +
                                          "/" + _pc.GetDayOfMonth(dt).ToString("00") + " " + dt.ToString("HH:mm:ss");
                        //MessageBox.Show("SERVER  Cmd:" + cmd + " Who:" + who + " Str:" + str);
                        switch (cmd)
                        {
                            case "0": // for user login
                                {
                                    if (HT.ContainsKey(who) || who == "" || who.Length > 20 || who == "You" ||
                                        who == "you" || who == "server" || who == "Server")
                                    {
                                        buffer = Encoding.UTF8.GetBytes(repeatedName);
                                        Thread.Sleep(10);
                                        lock (sendlocker)
                                        {
                                            //براي خود كاربر پيام خوش آمد ميفرسته
                                            sck.Send(buffer, 0, buffer.Length, SocketFlags.None);
                                        }

                                        break;

                                    }

                                    socketname = who;
                                    lock (listlocker)
                                    {
                                        HT.Add(who, sck);
                                        listBoxUser.Items.Add(who);
                                    }

                                    //براي همه پيام ميفرسته كه
                                    //(who)
                                    //آنلاين شده
                                    //sendToAll("99" + "|server|" + who + " has logged in");

                                    connection.SituationUser(who, true);
                                    //ليست افراد آنلاين رو براي همه ميفرسته
                                    sendToAll(cmd + "|server|" + getOnlineList());
                                    connection.RefreshUsers();

                                    break;
                                }
                            case "2": // for private message
                                {
                                    string to = c[3];

                                    //ثبت در ديتابيس
                                    var Message = new Message_Temp()
                                    {
                                        Text = c[2].Trim(),
                                        FromTocen = connection.AllUsers.FirstOrDefault(f => f.UserName == who).UserID,
                                        ToTocen = connection.AllUsers.FirstOrDefault(f => f.UserName == to).UserID,
                                        DateTimeSend = dateTime,
                                        MessageDeleteFrom = false,
                                        MessageDeleteTo = false,
                                        MessageID = connection.AllUsers.First(f => f.UserName == who).NextMessageID ?? 1
                                    };

                                    if ((Socket)HT[to] == null)
                                        connection.SendMessage_temp(Message);
                                    else
                                        connection.SendMessage(Message);


                                    //پيام خصوصي براي كاربر 
                                    //(to)
                                    //ميفرسته
                                    sendToClient(cmd + "|" + who + "|" + str + "|" + to + "|"
                                                 + dateTime + "|" + Message.MessageID, who, to);
                                    break;
                                }
                            case "7":
                                {
                                    int fromID = Convert.ToInt32(who);
                                    int ToID = Convert.ToInt32(c[3]);

                                    connection.RedMessage(fromID, ToID);
                                    sendToAll("0" + "|server|" + getOnlineList());

                                    break;
                                }
                            case "9":
                                {
                                    connection.SituationUser(who, false, dateTime);
                                    connection.RefreshUsers();
                                    break;
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
                            listBoxUser.Items.Remove(socketname);

                            connection.SituationUser(socketname, false);
                        }
                        Console.WriteLine(socketname + "has lost");
                        Thread.Sleep(500);
                        //براي همه پيام خروج كاربر
                        //soketname
                        //راميفرسته
                        //sendToAll("99" + "|server|" + socketname + " has lost connection");

                        //ليست افراد آنلاين رو براي همه ميفرسته
                        sendToAll(0 + "|server|" + getOnlineList());

                        th.Abort();
                    }
                }



            }
        }

        private string getOnlineList()
        {

            if (listBoxUser.Items.Count > 0)
            {
                string list = "";
                for (int i = 0; i < listBoxUser.Items.Count - 1; ++i)
                {
                    list += listBoxUser.Items[i] + ",";
                }
                list += listBoxUser.Items[listBoxUser.Items.Count - 1];
                return list;
            }

            return "";
        }

        private void sendToClient(string str, string userFrom, string userTo)
        {

            byte[] buffer = Encoding.UTF8.GetBytes(str);
            lock (listlocker)
            {
                Socket sck = (Socket)HT[userTo];

                try
                {
                    lock (sendlocker)
                    {
                        //براي
                        //userTo
                        //پيام خصوصي ارسال ميكند
                        sck.Send(buffer, 0, buffer.Length, SocketFlags.None);
                    }
                }
                catch (Exception)
                {
                    ;
                }

                Socket sck1 = (Socket)HT[userFrom];
                try
                {
                    lock (sendlocker)
                    {
                        //براي
                        //userFrom
                        //پيام خصوصي ارسال ميكند كه پيام ارسال شده
                        sck1.Send(buffer, 0, buffer.Length, SocketFlags.None);
                    }
                }
                catch (Exception)
                {
                    ;
                }
            }
        }

        private void sendToAll(string str)
        {

            byte[] buffer = Encoding.UTF8.GetBytes(str);
            /*List<Socket> sks = HT.Values.Cast<Socket>().ToList();*/

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



    }
}
