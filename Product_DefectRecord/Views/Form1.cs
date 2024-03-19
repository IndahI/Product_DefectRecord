using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Product_DefectRecord
{
    public partial class Form1 : Form
    {
        private TcpServerWrapper serverWrapper;
        public Form1()
        {
            InitializeComponent();
        }

        private async void StartButton_Click(object sender, EventArgs e)
        {
            serverWrapper = new TcpServerWrapper(1234, UpdateServerBox, UpdateClientBox); // Passing both update methods
            await serverWrapper.StartServerAsync();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Implement closing logic if needed
        }

        private void UpdateServerBox(string message)
        {
            // Invoke UI updates on the UI thread
            if (ServerBox.InvokeRequired)
            {
                ServerBox.Invoke((MethodInvoker)(() => UpdateServerBox(message)));
            }
            else
            {
                ServerBox.Text = message;
            }
        }

        private void UpdateClientBox(string message)
        {
            // Invoke UI updates on the UI thread
            if (clientBox.InvokeRequired)
            {
                clientBox.Invoke((MethodInvoker)(() => UpdateClientBox(message)));
            }
            else
            {
                clientBox.Text = message;
            }
        }
    }
}
