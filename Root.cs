using AQWInterceptor.Extensions;
using AQWInterceptor.Proxy;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace AQWInterceptor
{
    public partial class Root : Form
    {
        private List<string> proxyMessages;
        private Proxy.Proxy proxyServer;
        public Root()
        {
            proxyMessages = new List<string>();
            proxyServer = new Proxy.Proxy();
            InitializeComponent();
            Proxy.Proxy.OnPacketIntercepted += OnPacketIntercepted;
            startConnectionToolStripMenuItem_Click(null, null);
        }

        private void startConnectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            startConnectionToolStripMenuItem.Enabled = false;
            stopConnectionToolStripMenuItem.Enabled = true;
            proxyServer.StartProxy("twig.aqw.aq.com");
            toolStripStatusLabel1.Text = "Listening...";
        }

        private void OnPacketIntercepted(string message, SenderType type)
        {
            if (!showClientToolStripMenuItem.Checked && type == SenderType.Client)
                return;

            if (!showServerToolStripMenuItem.Checked && type == SenderType.Server)
                return;

            proxyMessages.Add(message);
            if (message.Length > 60)
                message = type.ToString() + " : " + message.Substring(0, 60) + "...";
            else
                message = type.ToString() + " : " + message;

            AddItem(message);
            UpdateListBoxView();
        }

        private void UpdateListBoxView()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => UpdateListBoxView()));
                return;
            }

            int NumberOfItems = listBox1.ClientSize.Height / listBox1.ItemHeight;
            if (listBox1.TopIndex == listBox1.Items.Count - NumberOfItems - 1)
            {
                listBox1.TopIndex = listBox1.Items.Count - NumberOfItems + 1;
            }
        }

        private void AddItem(string item)
        {
            if (InvokeRequired)
                Invoke(new Action(() => AddItem(item)));
            else
                listBox1.Items.Add(item);
        }

        private void Root_FormClosing(object sender, FormClosingEventArgs e)
        {
            proxyServer.StopProxy();
        }

        private void stopConnectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            stopConnectionToolStripMenuItem.Enabled = false;
            startConnectionToolStripMenuItem.Enabled = true;
            proxyServer.StopProxy();
            toolStripStatusLabel1.Text = "Stopped.";
        }

        private void clearLogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            proxyMessages.Clear();
        }

        private void showClientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showClientToolStripMenuItem.Checked = !showClientToolStripMenuItem.Checked;
        }

        private void showServerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showServerToolStripMenuItem.Checked = !showServerToolStripMenuItem.Checked;
        }

        private void listBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (listBox1.SelectedIndex == -1)
                return;

            string item = proxyMessages[listBox1.SelectedIndex];
            treeView1.Nodes.Clear();
            if (item[0] != '{')
                treeView1.Nodes.Add(item);
            else
            {
                JObject obj = JObject.Parse(item);
                treeView1.SetObjectAsJson(obj);
            }
        }
    }
}
