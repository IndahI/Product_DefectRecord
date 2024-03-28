using Product_DefectRecord.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Product_DefectRecord.Views
{
    public partial class EditDefectName : Form, IEditDefect
    {
        private string message;
        private bool isSuccessful;
        private bool isEdit;

        public EditDefectName()
        {
            InitializeComponent();
            AssociateAndRaiseViewEvents();
        }

        private void AssociateAndRaiseViewEvents()
        {
            //SaveDefect
            btnSave.Click += delegate
            {
                SaveDefectEvent?.Invoke(this, EventArgs.Empty);
                if (isSuccessful)
                {
                    MessageBox.Show("Berhasil");
                }
                MessageBox.Show("Gagal");
            };

            //cancle
            btnCancle.Click += delegate
            {
                this.Close();
            };
        }

        public bool IsEdit
        {
            get { return isEdit; }
            set { isEdit = value; }
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

        public string DefectId
        {
            get { return textDefectId.Text; }
            set { textDefectId.Text = value; }
        }

        public string PartId
        {
            get { return textPartId.Text; }
            set { textPartId.Text = value; }
        }

        public string DefectName
        {
            get { return textDefectName.Text; }
            set { textDefectName.Text = value; }
        }

        public event EventHandler AddEvent;
        public event EventHandler EditEvent;
        public event EventHandler SaveDefectEvent;
        public event EventHandler DeleteEvent;
        public event EventHandler CancleEvent;
    }
}
