using Product_DefectRecord._Repositories;
using Product_DefectRecord.Models;
using Product_DefectRecord.Presenters;
using System;
using System.Configuration;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Product_DefectRecord.Views
{
    public partial class LoginView : Form, ILoginView
    {
        public LoginView()
        {
            InitializeComponent();

            textBoxNik.TabIndex = 0;
            textBoxPassword.TabIndex = 1;
            btnLogin.TabIndex = 2;

            AssociateAndRaiseViewEvents();
            this.ActiveControl = textBoxNik;
            this.SetStyle(ControlStyles.ResizeRedraw, true);
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


        private void AssociateAndRaiseViewEvents()
        {
            textBoxNik.KeyDown += (sender, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                {
                    Login?.Invoke(this, EventArgs.Empty);
                }
            };

            textBoxPassword.KeyDown += (sender, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                {
                    Login?.Invoke(this, EventArgs.Empty);
                }
            };

            btnLogin.Click += (sender, e) =>
            {
                if(!string.IsNullOrWhiteSpace(Nik) && !string.IsNullOrWhiteSpace(Password))
                {
                    Login?.Invoke(this, EventArgs.Empty);
                }
                else
                {
                    MessageBox.Show("Masukkan Nik atau Password dengan benar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };

            btnExit.Click += delegate
            {
                Application.Exit();
            };
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            /***
            base.OnPaintBackground(e);
            using (LinearGradientBrush brush = new LinearGradientBrush(this.ClientRectangle, Color.FromArgb(0, 173, 181), Color.FromArgb(238, 238, 238), 90F))
            {
                e.Graphics.FillRectangle(brush, this.ClientRectangle);
            }
            ***/
        }

        public void ShowMessage(string message)
        {
            MessageBox.Show(message);
        }

        public void HideView()
        {
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
