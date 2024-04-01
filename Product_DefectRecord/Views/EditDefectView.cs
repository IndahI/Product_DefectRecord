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
    public partial class EditDefectView : Form, IEditDefectView
    {
        private string message;

        public EditDefectView()
        {
            InitializeComponent();
            AssociateAndRaiseViewEvents();
        }

        private void AssociateAndRaiseViewEvents()
        {
            //SaveDefect
            btnSave.Click += delegate
            {
                EditEvent?.Invoke(this, EventArgs.Empty);
            };

            //cancle
            btnCancle.Click += delegate
            {
                this.Close();
            };
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
            get { return textPartName.Text; }
            set { textPartName.Text = value; }
        }

        public string DefectName
        {
            get { return textDefectName.Text; }
            set { textDefectName.Text = value; }
        }

        public string PartName 
        { 
            get { return textPartName.Text; }
            set { textPartName.Text = value; }
        }

        public event EventHandler EditEvent;
    }
}
