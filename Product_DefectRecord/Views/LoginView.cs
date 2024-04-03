using Product_DefectRecord._Repositories;
using Product_DefectRecord.Models;
using Product_DefectRecord.Presenters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Product_DefectRecord.Views
{
    public partial class LoginView : Form, ILoginView
    {
        public LoginView()
        {
            InitializeComponent();
            AssociateAndRaiseViewEvents();
        }

        private void AssociateAndRaiseViewEvents()
        {
            btnLogin.Click += delegate
            {
                if (!string.IsNullOrWhiteSpace(Nik))
                {
                    Login?.Invoke(this, EventArgs.Empty);
                }
            };
        }

        public string Nik
        {
            get { return textBoxNik.Text; }
            set { textBoxNik.Text = value; }
        }
        public string Password
        {
            get { return textBoxPassword.Text; }
            set { textBoxPassword.Text = value; }
        }
        public bool IsLoginSuccessful { get; private set; }

        public event EventHandler Login;

        public void ShowMessage(string message)
        {
            MessageBox.Show(message);
        }
    }
}
