using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Product_DefectRecord.Views
{
    public partial class DefectView : Form, IDefectView
    {
        private TcpServerWrapper serverWrapper;
        private string message;
        private bool isSuccessful;
        private bool isEdit;

        public DefectView()
        {
            InitializeComponent();
            
        }

        //event
        public event EventHandler SearchEvent;
        public event EventHandler AddEvent;
        public event EventHandler EditEvent;
        public event EventHandler SaveEvent;
        public event EventHandler DeleteEvent;
        public event EventHandler CancleEvent;

        //properties
        public string SerialNumber
        {
            get { return textBoxSerial.Text; }
            set { textBoxSerial.Text = value; }
        }
        public string ModelNumber
        {
            get { return textBoxModel.Text; }
            set { textBoxModel.Text = value; }
        }
        public string ModelCode
        {
            get { return textBoxCode.Text; }
            set { textBoxCode.Text = value; }
        }
        public bool IsEdit 
        {   
            get { return isEdit; }
            set {  isEdit = value; }
        }
        public bool IsSuccessful 
        {
            get { return isSuccessful; }
            set { isSuccessful = value; } 
        }
        public string Message 
        {
            get { return message; }
            set { message = value; } 
        }

        public string DefectId { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string PartId { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string DefectName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string SearchValue { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        private void UpdateSerialBox(string message)
        {
            // Invoke UI updates on the UI thread
            if (textBoxSerial.InvokeRequired)
            {
                textBoxSerial.Invoke((MethodInvoker)(() => UpdateSerialBox(message)));
            }
            else
            {
                textBoxSerial.Text = message;
            }
        }

        private void UpdateCodeBox(string message)
        {
            // Invoke UI updates on the UI thread
            if (textBoxCode.InvokeRequired)
            {
                textBoxCode.Invoke((MethodInvoker)(() => UpdateCodeBox(message)));
            }
            else
            {
                textBoxCode.Text = message;
            }
        }

        private async void DefectView_Load(object sender, EventArgs e)
        {
            serverWrapper = new TcpServerWrapper(1234, UpdateCodeBox, UpdateSerialBox); // Passing both update methods
            await serverWrapper.StartServerAsync();
        }

        //Methods
        public void SetDefectListBindingSource(BindingSource defectList)
        {
            dataGridView1.DataSource = defectList;
        }
    }
}
