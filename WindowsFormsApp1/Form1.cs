using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System;
using System.IO;
using System;
using System;
using System.Net.Http;
using System.Threading.Tasks;


namespace WindowsFormsApp1
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }
        protected override void OnMouseDown(MouseEventArgs e)

        {
            base.OnMouseDown(e);
            if (e.Button == MouseButtons.Left)
            {
                this.Capture = false;
                Message msg = Message.Create(this.Handle, 0XA1, new IntPtr(2), IntPtr.Zero);
                this.WndProc(ref msg);
            }
        }
        public class WebClientWithTimeout : WebClient
        {
            protected override WebRequest GetWebRequest(Uri address)
            {
                WebRequest wc = base.GetWebRequest(address);
                wc.Timeout = 1000;
                return wc;
            }
        }

        public bool GetConnection()
        {
            try
            {
                using (WebClient wc = new WebClientWithTimeout())
                {
                    string json = wc.DownloadString($"https://lifecorerp.com/pcount.php");
                    if (json == "0")
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
            }
            catch
            {
                return false;
            }
        }

        public int pCount()
        {
            try
            {
                using (WebClient wc = new WebClientWithTimeout())
                {
                    string json = wc.DownloadString($"https://lifecorerp.com/pcount.php");
                    return int.Parse(json);
                }
            }
            catch
            {
                return 0;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (GetConnection())
            {
                label22.Text = "SERVER IS ONLINE";
                label22.ForeColor = Color.FromArgb(25, 200, 25);
            }
            int playerCount = pCount();
            if (playerCount == 0)
            {
                label15.Text = "";
            }else
            {
                string playerCountString = Convert.ToString(playerCount);
                label15.Text = $"PLAYER COUNT: {playerCountString} / 60";
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            System.Diagnostics.Process.Start("https://lifecorerp.com");
        }

        private void label4_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            System.Diagnostics.Process.Start("https://lifecorerp.com");
        }

        private void label5_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            System.Diagnostics.Process.Start("https://discord.gg/lifecorerp");
        }

        private void label8_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            System.Diagnostics.Process.Start("explorer.exe", "fivem://connect/play.lifecorerp.com");
            Application.Exit();
        }

        private void rjButton1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            System.Diagnostics.Process.Start("explorer.exe", "fivem://connect/play.lifecorerp.com");
            //System.Diagnostics.Process.Start("fivem://connect/play.lifecorerp.com");
            //Application.Exit();
        }

        private void label8_Click_1(object sender, EventArgs e)
        {

            Form2 frm2 = new Form2();
            frm2.ShowDialog();

        }
    }
}
