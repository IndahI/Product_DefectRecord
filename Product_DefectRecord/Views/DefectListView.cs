using Product_DefectRecord._Repositories;
using Product_DefectRecord.Models;
using Product_DefectRecord.Presenters;
using Product_DefectRecord.Views;
using System;
using System.Configuration;
using System.Drawing;
using System.Windows.Forms;
using static Product_DefectRecord.Presenters.DefectListPresenter;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Product_DefectRecord.Views
{
    public partial class DefectListView : Form, IDefectListView
    {
        private PrintRecordPresenter printRecordPresenter;
        public LoginModel _user;
        public DefectListView(LoginModel user)
        {
            _user = user;
            InitializeComponent();
            InitializeTabControl();
            HandleAction();
        }

        public void InitializeTabControl()
        {
            PrintRecord printRecord = new PrintRecord();
            DefectListDataPresenter presenterData = new DefectListDataPresenter(printRecord, new DefectRepository(), new ModelNumberRepository(), _user);
            printRecordPresenter = new PrintRecordPresenter(presenterData); // Inisialisasi variabel instance
            splitContainer1.Panel2.Controls.Add(printRecord);
            printRecord.Dock = DockStyle.Fill;
        }

        private void HandleAction() 
        {
            btnRecord.Click += delegate
            {
                int selectedTabPageIndex = 1;
                printRecordPresenter.ChangeTabPage(selectedTabPageIndex);
                //btnHome.BackColor = Color.FromArgb(0, 133, 181);
                //btnRePrint.BackColor = Color.FromArgb(0, 35, 105);
            };

            btnPrint.Click += delegate
            {
                int selectedTabPageIndex = 0;
                printRecordPresenter.ChangeTabPage(selectedTabPageIndex);
                //btnHome.BackColor = Color.FromArgb(0, 133, 181);
                //btnRePrint.BackColor = Color.FromArgb(0, 35, 105);
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
                // Menyembunyikan view saat ini
                this.Hide();

                // Membuat dan menampilkan form login baru
                ILoginView loginView = new LoginView();
                LoginPresenter loginPresenter = new LoginPresenter(loginView, new LoginRepository());
                loginView.Show();

                // Menutup form saat ini
                //this.Close();
            };
        }

        // Singleton pattern (open a single form instance)
        private static DefectListView instance;
        public static DefectListView GetInstance(LoginModel loginModel)
        {
            if (instance == null || instance.IsDisposed)
                instance = new DefectListView(loginModel);
            else
            {
                if (instance.WindowState == FormWindowState.Minimized)
                    instance.WindowState = FormWindowState.Normal;
                instance.BringToFront();
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
