using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System;
using System.IO;

namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.youtube.com/watch?v=9Jq16iEzyOI");
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string fivemPath = Utils.GetFiveMPath();

            if (string.IsNullOrEmpty(fivemPath))
            {
                MessageBox.Show("Could not find FiveM installation. Cancelling auto clean up.");
                return;
            }

            if (!Directory.Exists(fivemPath))
            {
                MessageBox.Show("FiveM directory does not exist. Cancelling auto clean up.");
                return;
            }

            string yourDirectoryPath = Path.Combine(fivemPath, "FiveM.app", "data");

            // Check if the main directory exists
            if (Directory.Exists(yourDirectoryPath))
            {
                // Delete the 'cache' folder if it exists
                string cacheFolderPath = Path.Combine(yourDirectoryPath, "cache");
                if (Directory.Exists(cacheFolderPath))
                {
                    Directory.Delete(cacheFolderPath, true);
                    MessageBox.Show("Deleted 'cache' folder.");
                }

                // Delete the 'server-cache' folder if it exists
                string serverCacheFolderPath = Path.Combine(yourDirectoryPath, "server-cache");
                if (Directory.Exists(serverCacheFolderPath))
                {
                    Directory.Delete(serverCacheFolderPath, true);
                    MessageBox.Show("Deleted 'server-cache' folder.");
                }

                // Delete the 'server-cache-priv' folder if it exists
                string serverCachePrivFolderPath = Path.Combine(yourDirectoryPath, "server-cache-priv");
                if (Directory.Exists(serverCachePrivFolderPath))
                {
                    Directory.Delete(serverCachePrivFolderPath, true);
                    MessageBox.Show("Deleted 'server-cache-priv' folder.");
                }
                MessageBox.Show("Cache Fully Cleaned.");
                this.Close();
            }
            else
            {
                MessageBox.Show("Directory does not exist. Cancelling auto clean up");
            }
        }
    }
}
