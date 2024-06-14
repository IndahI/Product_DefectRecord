using Product_DefectRecord._Repositories;
using Product_DefectRecord.Models;
using Product_DefectRecord.Presenters;
using Product_DefectRecord.Views;
using System;
using System.Configuration;
using System.Drawing;
using System.Windows.Forms;
using static Product_DefectRecord.Presenters.MainFormPresenter;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Product_DefectRecord.Views
{
    public partial class MainForm : Form, IMainFormView
    {
        private PrintRecordPresenter printRecordPresenter;
        public LoginModel _user;
        private PrintRecord printRecord;
        private TCPConnection connection;

        public MainForm(LoginModel user)
        {
            _user = user;
            InitializeComponent();
            InitializeTabControl();
            HandleAction();
        }

        public void InitializeTabControl()
        {
            PrintRecord printRecord = new PrintRecord();
            MainFormDataPresenter presenterData = new MainFormDataPresenter(printRecord, new DefectRepository(), new ModelNumberRepository(), _user);
            printRecordPresenter = new PrintRecordPresenter(presenterData); // Inisialisasi variabel instance
            splitContainer1.Panel2.Controls.Add(printRecord);
            printRecord.Dock = DockStyle.Fill;
            connection = new TCPConnection(printRecord.UpdateCodeBox, printRecord.UpdateSerialBox);
        }

        private void HandleAction() 
        {
            btnRecord.Click += delegate
            {
                int selectedTabPageIndex = 1;
                printRecordPresenter.ChangeTabPage(selectedTabPageIndex);
                btnRecord.BackColor = Color.FromArgb(64, 165, 120);
                btnPrint.BackColor = Color.FromArgb(0, 103, 105);
            };

            btnPrint.Click += delegate
            {
                int selectedTabPageIndex = 0;
                printRecordPresenter.ChangeTabPage(selectedTabPageIndex);
                btnPrint.BackColor = Color.FromArgb(64, 165, 120);
                btnRecord.BackColor = Color.FromArgb(0, 103, 105);
            };

            timer1.Tick += delegate
            {
                Time.Text = DateTime.Now.ToLongTimeString();
                Date.Text = DateTime.Now.ToLongDateString();
            };

            btnSetting.Click += (sender, e) =>
            {
                ISettingView settingView = SettingView.GetInstance();
                SettingPresenter settingPresenter = new SettingPresenter(settingView, new SettingModel());
                (settingView as Form)?.Show();
            };

            btnLogout.Click += (sender, e) =>
            {
                connection.CloseConnection();

                printRecordPresenter.UnassociateViewEvents();
                ResetBinding();

                this.Close();

                // Membuat dan menampilkan form login baru
                ILoginView loginView = new LoginView();
                LoginPresenter loginPresenter = new LoginPresenter(loginView, new LoginRepository());
                (loginView as Form)?.Show();

                _user = loginPresenter.User;
                InitializeTabControl();
            };
        }

        private void ResetBinding()
        {
            printRecordPresenter.ResetDataBinding();
        }

        // Singleton pattern (open a single form instance)
        private static MainForm instance;
        public static MainForm GetInstance(LoginModel loginModel)
        {
            if (instance == null || instance.IsDisposed)
                instance = new MainForm(loginModel);
            else
            {
                if (instance.WindowState == FormWindowState.Minimized)
                    instance.WindowState = FormWindowState.Normal;
                instance.BringToFront();
                instance._user = loginModel; // Set new user
                instance.InitializeTabControl();
            }
            return instance;
        }

        private void DefectListView_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void DefectListView_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }
    }
}
