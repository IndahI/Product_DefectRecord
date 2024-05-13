using Product_DefectRecord._Repositories;
using Product_DefectRecord.Models;
using Product_DefectRecord.Presenters;
using System;
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
            AssociateAndRaiseViewEvents();
            this.ActiveControl = textBoxNik;
            this.SetStyle(ControlStyles.ResizeRedraw, true);
        }

        private void AssociateAndRaiseViewEvents()
        {
            btnLogin.Click += BtnLogin_Click;
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(Nik))
            {
                Login?.Invoke(this, EventArgs.Empty);
            }
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            base.OnPaintBackground(e);
            using (LinearGradientBrush brush = new LinearGradientBrush(this.ClientRectangle, Color.FromArgb(0, 173, 181), Color.FromArgb(238, 238, 238), 90F))
            {
                e.Graphics.FillRectangle(brush, this.ClientRectangle);
            }
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

        public void HideView()
        {
            this.Hide();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
