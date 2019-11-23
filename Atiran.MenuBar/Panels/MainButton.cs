using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Atiran.DataLayer.Context;
using Atiran.DataLayer.Services;
using Atiran.MenuBar.Class;
using Atiran.MenuBar.Forms;
using Atiran.MenuBar.Properties;
using Atiran.Messenger.Class;
using Atiran.Messenger.Forms;
using Atiran.Utility.Docking2;
using Atiran.Utility.Docking2.Desk;
using Atiran.Utility.MassageBox;
using Timer = System.Windows.Forms.Timer;

namespace Atiran.MenuBar.Panels
{
    public class MainButton : UserControl
    {
        private Label lblMaximis;
        private Label lblMinimis;
        private Timer timer1;
        private System.ComponentModel.IContainer components;
        private DockPanel mainPane;
        private Label lblDateTime;
        private Label label2;
        private Label label3;
        private Label lblSalMali;
        private Label btnLine;
        private Label label6;
        private Label label8;
        private Label btnShortcutDesk;
        private Label label10;
        private MenuStrip msUserActivs;
        private ToolStripMenuItem miUserActivs;
        private ToolStripMenuItem sadfsfToolStripMenuItem;
        private ShortcutDesk sh1;
        private PersianCalendar pc = new PersianCalendar();
        public int UserID, SalMaliID;
        private PictureBox lblClose;
        private ToolStripMenuItem miRestartApplication;
        private bool isCLoseAll = false;
        private bool isCanselCLoseAll = false;
        private Label btnMessenger;
        private Label label4;
        private List<Form> deskTabs;

        public MainButton()
        {
            InitializeComponent();
            this.BackColor = Color.Transparent;
            timer1.Start();

        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lblDateTime = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblSalMali = new System.Windows.Forms.Label();
            this.btnLine = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btnShortcutDesk = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.msUserActivs = new System.Windows.Forms.MenuStrip();
            this.miRestartApplication = new System.Windows.Forms.ToolStripMenuItem();
            this.miUserActivs = new System.Windows.Forms.ToolStripMenuItem();
            this.sadfsfToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblClose = new System.Windows.Forms.PictureBox();
            this.lblMinimis = new System.Windows.Forms.Label();
            this.lblMaximis = new System.Windows.Forms.Label();
            this.btnMessenger = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.msUserActivs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblClose)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lblDateTime
            // 
            this.lblDateTime.BackColor = System.Drawing.Color.Transparent;
            this.lblDateTime.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.lblDateTime.Font = new System.Drawing.Font("IRANSans(FaNum)", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDateTime.Location = new System.Drawing.Point(3, 5);
            this.lblDateTime.Name = "lblDateTime";
            this.lblDateTime.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblDateTime.Size = new System.Drawing.Size(160, 31);
            this.lblDateTime.TabIndex = 5;
            this.lblDateTime.Text = "1398/08/08   12/12/12";
            this.lblDateTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(81)))), ((int)(((byte)(100)))));
            this.label2.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.label2.Font = new System.Drawing.Font("IRANSans(FaNum)", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(164, 2);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(3, 38);
            this.label2.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(81)))), ((int)(((byte)(100)))));
            this.label3.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.label3.Font = new System.Drawing.Font("IRANSans(FaNum)", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(287, 1);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(3, 38);
            this.label3.TabIndex = 8;
            // 
            // lblSalMali
            // 
            this.lblSalMali.BackColor = System.Drawing.Color.Transparent;
            this.lblSalMali.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.lblSalMali.Font = new System.Drawing.Font("IRANSans(FaNum)", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSalMali.Location = new System.Drawing.Point(167, 5);
            this.lblSalMali.Name = "lblSalMali";
            this.lblSalMali.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblSalMali.Size = new System.Drawing.Size(120, 31);
            this.lblSalMali.TabIndex = 7;
            this.lblSalMali.Text = "سال جاري";
            this.lblSalMali.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnLine
            // 
            this.btnLine.BackColor = System.Drawing.Color.Transparent;
            this.btnLine.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLine.Font = new System.Drawing.Font("IRANSans(FaNum)", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLine.Location = new System.Drawing.Point(292, 1);
            this.btnLine.Name = "btnLine";
            this.btnLine.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnLine.Size = new System.Drawing.Size(200, 36);
            this.btnLine.TabIndex = 7;
            this.btnLine.Text = "لاين فروش انتخاب نشده";
            this.btnLine.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnLine.Click += new System.EventHandler(this.btnLine_Click);
            this.btnLine.MouseEnter += new System.EventHandler(this.label_MouseEnter);
            this.btnLine.MouseLeave += new System.EventHandler(this.label_MouseLeave);
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(81)))), ((int)(((byte)(100)))));
            this.label6.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.label6.Font = new System.Drawing.Font("IRANSans(FaNum)", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(493, 1);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(3, 38);
            this.label6.TabIndex = 8;
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(81)))), ((int)(((byte)(100)))));
            this.label8.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.label8.Font = new System.Drawing.Font("IRANSans(FaNum)", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(621, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(3, 38);
            this.label8.TabIndex = 8;
            // 
            // btnShortcutDesk
            // 
            this.btnShortcutDesk.BackColor = System.Drawing.Color.Transparent;
            this.btnShortcutDesk.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnShortcutDesk.Font = new System.Drawing.Font("IRANSans(FaNum)", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShortcutDesk.Location = new System.Drawing.Point(625, 1);
            this.btnShortcutDesk.Name = "btnShortcutDesk";
            this.btnShortcutDesk.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnShortcutDesk.Size = new System.Drawing.Size(150, 36);
            this.btnShortcutDesk.TabIndex = 7;
            this.btnShortcutDesk.Text = "ميزكار";
            this.btnShortcutDesk.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnShortcutDesk.Click += new System.EventHandler(this.lblShortcutDesk_Click);
            this.btnShortcutDesk.MouseEnter += new System.EventHandler(this.label_MouseEnter);
            this.btnShortcutDesk.MouseLeave += new System.EventHandler(this.label_MouseLeave);
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(81)))), ((int)(((byte)(100)))));
            this.label10.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.label10.Font = new System.Drawing.Font("IRANSans(FaNum)", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(776, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(3, 38);
            this.label10.TabIndex = 8;
            // 
            // msUserActivs
            // 
            this.msUserActivs.AutoSize = false;
            this.msUserActivs.BackColor = System.Drawing.Color.Transparent;
            this.msUserActivs.Dock = System.Windows.Forms.DockStyle.None;
            this.msUserActivs.Font = new System.Drawing.Font("IRANSans(FaNum)", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.msUserActivs.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miRestartApplication,
            this.miUserActivs});
            this.msUserActivs.Location = new System.Drawing.Point(439, 1);
            this.msUserActivs.Name = "msUserActivs";
            this.msUserActivs.Size = new System.Drawing.Size(180, 36);
            this.msUserActivs.TabIndex = 9;
            this.msUserActivs.Text = "menuStrip1";
            // 
            // miRestartApplication
            // 
            this.miRestartApplication.AutoSize = false;
            this.miRestartApplication.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.miRestartApplication.Image = global::Atiran.MenuBar.Properties.Resources.icoUser;
            this.miRestartApplication.Name = "miRestartApplication";
            this.miRestartApplication.Size = new System.Drawing.Size(28, 37);
            this.miRestartApplication.Text = " ";
            this.miRestartApplication.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            this.miRestartApplication.Click += new System.EventHandler(this.miRestartApplication_Click);
            // 
            // miUserActivs
            // 
            this.miUserActivs.AutoSize = false;
            this.miUserActivs.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.miUserActivs.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sadfsfToolStripMenuItem});
            this.miUserActivs.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.miUserActivs.ForeColor = System.Drawing.Color.White;
            this.miUserActivs.Name = "miUserActivs";
            this.miUserActivs.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.miUserActivs.Size = new System.Drawing.Size(94, 37);
            this.miUserActivs.Text = "كاربر";
            this.miUserActivs.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.miUserActivs.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            // 
            // sadfsfToolStripMenuItem
            // 
            this.sadfsfToolStripMenuItem.AutoSize = false;
            this.sadfsfToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.sadfsfToolStripMenuItem.Image = global::Atiran.MenuBar.Properties.Resources.expandleft;
            this.sadfsfToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.sadfsfToolStripMenuItem.Name = "sadfsfToolStripMenuItem";
            this.sadfsfToolStripMenuItem.Size = new System.Drawing.Size(180, 24);
            this.sadfsfToolStripMenuItem.Text = "sadfsf";
            // 
            // lblClose
            // 
            this.lblClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblClose.BackColor = System.Drawing.Color.Transparent;
            this.lblClose.BackgroundImage = global::Atiran.MenuBar.Properties.Resources.Exit_1;
            this.lblClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.lblClose.Location = new System.Drawing.Point(1060, 1);
            this.lblClose.Name = "lblClose";
            this.lblClose.Size = new System.Drawing.Size(34, 38);
            this.lblClose.TabIndex = 10;
            this.lblClose.TabStop = false;
            this.lblClose.Click += new System.EventHandler(this.lblClose_Click);
            this.lblClose.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lblClose_MouseDown);
            this.lblClose.MouseEnter += new System.EventHandler(this.label_MouseEnter);
            this.lblClose.MouseLeave += new System.EventHandler(this.label_MouseLeave);
            // 
            // lblMinimis
            // 
            this.lblMinimis.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMinimis.BackColor = System.Drawing.Color.Transparent;
            this.lblMinimis.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.lblMinimis.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblMinimis.ForeColor = System.Drawing.Color.Transparent;
            this.lblMinimis.Image = global::Atiran.MenuBar.Properties.Resources.Minimis_1;
            this.lblMinimis.Location = new System.Drawing.Point(996, 1);
            this.lblMinimis.Name = "lblMinimis";
            this.lblMinimis.Size = new System.Drawing.Size(32, 38);
            this.lblMinimis.TabIndex = 4;
            this.lblMinimis.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblMinimis.Click += new System.EventHandler(this.lblMinimis_Click);
            this.lblMinimis.MouseDown += new System.Windows.Forms.MouseEventHandler(this.label_MouseDown);
            this.lblMinimis.MouseEnter += new System.EventHandler(this.label_MouseEnter);
            this.lblMinimis.MouseLeave += new System.EventHandler(this.label_MouseLeave);
            // 
            // lblMaximis
            // 
            this.lblMaximis.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMaximis.BackColor = System.Drawing.Color.Transparent;
            this.lblMaximis.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.lblMaximis.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblMaximis.ForeColor = System.Drawing.Color.Transparent;
            this.lblMaximis.Image = global::Atiran.MenuBar.Properties.Resources.Maximis_1;
            this.lblMaximis.Location = new System.Drawing.Point(1028, 1);
            this.lblMaximis.Name = "lblMaximis";
            this.lblMaximis.Size = new System.Drawing.Size(32, 38);
            this.lblMaximis.TabIndex = 3;
            this.lblMaximis.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblMaximis.Click += new System.EventHandler(this.lblMaximis_Click);
            this.lblMaximis.MouseDown += new System.Windows.Forms.MouseEventHandler(this.label_MouseDown);
            this.lblMaximis.MouseEnter += new System.EventHandler(this.label_MouseEnter);
            this.lblMaximis.MouseLeave += new System.EventHandler(this.label_MouseLeave);
            // 
            // btnMessenger
            // 
            this.btnMessenger.BackColor = System.Drawing.Color.Transparent;
            this.btnMessenger.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMessenger.Font = new System.Drawing.Font("IRANSans(FaNum)", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMessenger.Location = new System.Drawing.Point(781, 0);
            this.btnMessenger.Name = "btnMessenger";
            this.btnMessenger.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnMessenger.Size = new System.Drawing.Size(150, 36);
            this.btnMessenger.TabIndex = 7;
            this.btnMessenger.Text = "پيام ها";
            this.btnMessenger.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnMessenger.Click += new System.EventHandler(this.btnMessenger_Click);
            this.btnMessenger.MouseEnter += new System.EventHandler(this.label_MouseEnter);
            this.btnMessenger.MouseLeave += new System.EventHandler(this.label_MouseLeave);
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(81)))), ((int)(((byte)(100)))));
            this.label4.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.label4.Font = new System.Drawing.Font("IRANSans(FaNum)", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(932, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(3, 38);
            this.label4.TabIndex = 11;
            // 
            // MainButton
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(100)))), ((int)(((byte)(123)))));
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblClose);
            this.Controls.Add(this.lblDateTime);
            this.Controls.Add(this.lblSalMali);
            this.Controls.Add(this.btnLine);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.btnMessenger);
            this.Controls.Add(this.btnShortcutDesk);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblMinimis);
            this.Controls.Add(this.lblMaximis);
            this.Controls.Add(this.msUserActivs);
            this.Font = new System.Drawing.Font("IRANSans(FaNum)", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "MainButton";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(1094, 278);
            this.Load += new System.EventHandler(this.MainButton_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainButton_MouseDown);
            this.msUserActivs.ResumeLayout(false);
            this.msUserActivs.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblClose)).EndInit();
            this.ResumeLayout(false);

        }

        private void MainButton_Load(object sender, EventArgs e)
        {
            if (!this.DesignMode)
            {
                mainPane = (DockPanel)((Form)(this.TopLevelControl)).Controls.Find("MainTab", true).FirstOrDefault();
                sh1 = new ShortcutDesk(ref mainPane, 1);
                lblMaximis.Image = (((Form)this.TopLevelControl).WindowState == FormWindowState.Normal)
                    ? Resources.Maximis_1
                    : Resources.Maximis_2;
                List<ActiveUser> users = Connection.GetActiveUsers();

                miUserActivs.DropDownItems.Clear();
                List<ToolStripMenuItem> list = new List<ToolStripMenuItem>();
                foreach (var u in users)
                    list.Add(new ToolStripMenuItem()
                    {
                        Text = u.user_name,
                        RightToLeft = RightToLeft.Yes,
                        ForeColor = SystemColors.ButtonFace,
                        BackColor = Color.FromArgb(40, 130, 150),
                        Font = new Font("IRANSans(FaNum)", 11),
                    });

                miUserActivs.DropDownItems.AddRange(toolStripItems: list.ToArray());

                miUserActivs.Text = users.FirstOrDefault(u => u.user_id == UserID)?.user_name;
                lblSalMali.Text = Connection.GetNameSalMali(SalMaliID);

                //messenger
                //ServiceServer.serverIP = "192.168.1.103";
                ServiceServer.serverIP = "127.0.0.1";
                ServiceServer.serverPort = "1372";
                //setLabelMessageNotRed(Connection.GetNumberMessageNotRed(UserID));
                //LoginMessenger();
                //-------

            }
            msUserActivs.Renderer = new ToolStripProfessionalRendererAtiran();
        }

        #region Event

        private void lblClose_MouseDown(object sender, MouseEventArgs e)
        {
            ((Control)sender).BackColor = Color.DarkRed;
        }

        private void lblClose_Click(object sender, EventArgs e)
        {
            ((Form)this.TopLevelControl).Close();
        }

        private void lblMaximis_Click(object sender, EventArgs e)
        {
            if (((Form)this.TopLevelControl).WindowState == FormWindowState.Normal)
            {
                ((Form)this.TopLevelControl).WindowState = FormWindowState.Maximized;
                lblMaximis.Image = Resources.Maximis_2;
            }
            else
            {
                ((Form)this.TopLevelControl).WindowState = FormWindowState.Normal;
                lblMaximis.Image = Resources.Maximis_1;
            }
        }

        private void lblMinimis_Click(object sender, EventArgs e)
        {
            ((Form)this.TopLevelControl).WindowState = FormWindowState.Minimized;
        }

        private void lblShortcutDesk_Click(object sender, EventArgs e)
        {

            sh1.Text = "ميزكار";
            sh1.Show(mainPane);
        }

        private void label_MouseDown(object sender, MouseEventArgs e)
        {
            ((Label)sender).BackColor = Color.DeepSkyBlue;
        }
        private void label_MouseEnter(object sender, EventArgs e)
        {
            //msUserActivs.BackColor = Color.FromArgb(21, 100, 123);
            ((Control)sender).BackColor = Color.FromArgb(128, Color.FromArgb(20, 130, 150)); //Color.Wheat;
            //((Control)sender).ForeColor = Color.Black;
            ((Control)sender).Focus();
        }

        private void label_MouseLeave(object sender, EventArgs e)
        {
            ((Control)sender).BackColor = Color.Transparent;
            //((Control)sender).ForeColor = Color.White;
        }

        private void btnLine_Click(object sender, EventArgs e)
        {
            DeskTab deskTab = new DeskTab()
            {
                Text = "انتخاب لاين فروش",
                StartPosition = FormStartPosition.CenterParent
            };
            deskTab.ShowDialog();
        }

        private void miRestartApplication_Click(object sender, EventArgs e)
        {
            deskTabs = ((Form)TopLevelControl).MdiChildren.ToList();

            foreach (DeskTab form in ((Form)TopLevelControl).MdiChildren)
            {
                if (!isCanselCLoseAll)
                    TryClose(form, deskTabs.Where(f => f != form).ToArray());
            }

            isCLoseAll = false;
            isCanselCLoseAll = false;

            if (((Form)TopLevelControl).MdiChildren.Length < 1)
            {
                Application.Restart();
            }
        }

        private void TryClose(Atiran.Utility.Docking2.Desk.DeskTab form, Form[] forms)
        {
            if (form.ShowQuestionClose)
            {
                if (!isCLoseAll)
                {
                    string TextTabs = form.Text;
                    foreach (Form tab in forms)
                    {
                        TextTabs += "\n" + tab.Text;
                    }
                    var result = ShowPersianMessageBox.ShowMessge("آيا تب ها بسته شوند؟", TextTabs,
                        MessageBoxButtons.YesNo, false);
                    if (result == DialogResult.Yes)
                    {
                        form.Close();
                    }
                    else if (result == DialogResult.OK)
                    {
                        isCLoseAll = true;
                        form.Close();
                    }
                    else if (result == DialogResult.Cancel)
                    {
                        isCanselCLoseAll = true;
                    }
                }
                else
                {
                    form.Close();
                }
            }
            else
            {
                form.Close();
            }

            deskTabs.Remove(form);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime td = DateTime.Now;
            lblDateTime.Text = String.Format("{0}/{1}/{2}   {3}:{4}:{5}", pc.GetYear(td).ToString("0000"), pc.GetMonth(td).ToString("00"), pc.GetDayOfMonth(td).ToString("00"), td.Hour.ToString("00"), td.Minute.ToString("00"), td.Second.ToString("00"));
        }

        #endregion

        #region Messenger

        #region Private Messenger

        private Thread th;
        private int loginState = 0;
        private int NumberMessageNotRed = 0;

        #endregion

        private async void btnMessenger_Click(object sender, EventArgs e)
        {
            if (ServiceServer.socketSever != null && ServiceServer.socketSever.Connected)
            {
                //th.Abort();

                ((Form)TopLevelControl).Hide();
                MainMessanger messanger = new MainMessanger(miUserActivs.Text);
                messanger.ShowDialog();
                ((Form)TopLevelControl).Show();

                //th = new Thread(listenRoutine);
                //listenRoutine();
                //th.IsBackground = true;
                ////th.Priority = ThreadPriority.Normal;
                //th.Start();
            }
            else
            {
                btnMessenger.Enabled = false;
                await Task.Run(() => LoginMessenger());
                btnMessenger.Enabled = true;

            }
        }


        private void setLabelMessageNotRed(int Number)
        {
            NumberMessageNotRed = Number;
            if (NumberMessageNotRed > 0)
            {
                //نمايش روي پيام ها
            }
        }

        private void LoginMessenger()
        {
            CheckForIllegalCrossThreadCalls = false;

            try
            {
                IPEndPoint EP = new IPEndPoint(IPAddress.Parse(ServiceServer.serverIP), int.Parse(ServiceServer.serverPort));
                ServiceServer.socketSever = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                ServiceServer.socketSever.Connect(EP);
                //th = new Thread(listenRoutine);
                //listenRoutine();
                //th.IsBackground = true;
                ////th.Priority = ThreadPriority.Normal;
                //th.Start();
                sendMessageToServer("0|" + miUserActivs.Text + "|login");
                loginState = 1;
                MessageBox.Show("اتصال به سرور پيام رسال با موفقيت انجام شد.");
            }
            catch (Exception)
            {
                loginState = 0;
                ServiceServer.socketSever.Close();
                MessageBox.Show("ارتباط با سرور پيام رسان ممکن نیست!");
            }
        }

        //private async void listenRoutine()
        //{
        //    EndPoint serverEP = (EndPoint)ServiceServer.T.RemoteEndPoint;
        //    byte[] buffer = new byte[4096];
        //    int inLength = 0;
        //    string msg;
        //    string cmd;
        //    while (true)
        //    {
        //        try
        //        {
        //            await Task.Run(()=>inLength = ServiceServer.T.ReceiveFrom(buffer, ref serverEP));
        //        }

        //        catch (Exception)
        //        {
        //            //ServiceServer.T.Close();
        //            //listBoxUserList.Items.Clear();
        //            //richTextBoxBoard.AppendText(time + " اتصال از بین رفته است");
        //            //MessageBox.Show("اتصال از بین رفته است فرم را بسته و مجدد باز كنيد");
        //            //loginState = 0;
        //            //labelStatus.Text = " بدون اتصال ";
        //            //th.Abort();
        //            continue;
        //        }

        //        msg = Encoding.UTF8.GetString(buffer, 0, inLength);

        //        string[] c = msg.Split('|');
        //        cmd = c[0];
        //        //MessageBox.Show("CLIENT   Cmd:" + cmd + " Who:" + who+ " Str:" + str);
        //        if (cmd == "2")
        //        {
        //            //تعداد پيام هاي خانده نشده را اپديت كنه
        //            setLabelMessageNotRed(NumberMessageNotRed + 1);
        //        }
        //        else if (cmd == "64")
        //        {
        //            loginState = 0;
        //            MessageBox.Show("نام کاربری نامعتبر است ، لطفا دوباره وارد شوید!");
        //            //th.Abort();
        //        }
        //    }

        //}

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

        public void QuitMessenger()
        {
            try
            {
                sendMessageToServer("9|" + miUserActivs.Text + "|quit");
                ServiceServer.socketSever.Close();
                //th.Abort();
            }
            catch (Exception)
            {
            }
        }

        #endregion

        #region moving form by muse in header

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd,
            int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        private void MainButton_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(((Form)TopLevelControl).Handle, 0x00A1, 0x2, 0);
            }
        }

        #endregion

    }
}
