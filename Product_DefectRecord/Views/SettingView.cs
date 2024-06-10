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
using static System.Windows.Forms.AxHost;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Product_DefectRecord.Views
{
    public partial class SettingView : Form, ISettingView
    {
        private bool isDataLoaded = false;
        private string lastMode = "";

        // Define event for saving IP settings
        public event EventHandler SaveIPSetting;

        public SettingView()
        {
            InitializeComponent();
            LoadRadioSettings();
        }

        private void LoadRadioSettings()
        {
            // Set radio button states based on settings
            onRadio.Checked = Properties.Settings.Default.Mode == "on";
            offRadio.Checked = Properties.Settings.Default.Mode == "off";
        }

        public void DataLoaded()
        {
            InitializeComboBoxEventHandler();
        }

        public List<string> LocationNames
        {
            get => locationBox.DataSource as List<string>;
            set => locationBox.DataSource = value;
        }
        public string mode { get; set; }
        public string ipaddress
        {
            get => IPtextBox.Text;
            set => IPtextBox.Text = value;
        }
        public int portaddress 
        {
            get { return int.Parse(PorttextBox.Text); }
            set { PorttextBox.Text = value.ToString(); }
        }

        public event EventHandler SelectedIndexChanged;
        public event EventHandler LoadSettings;
        public event EventHandler HandleRadioButton;
        public event EventHandler SaveIPSettings;
        public event EventHandler SavePortSettings;
        public event EventHandler LoadIP;
        public event EventHandler LoadPort;
        public event EventHandler RestartConnect;

        public void DisplayIP(string IPaddress)
        {
            IPtextBox.Text = IPaddress;
        }

        public void DisplayPort(int Port) 
        {
            PorttextBox.Text = Port.ToString();
        }
        public void DisplaySetting(string myData)
        {
            locationBox.Text = myData;
        }

        public void ShowSelectedItem(string item)
        {
            //pengecekan location yang dipilih
            Console.WriteLine(item);
        }

        private void SettingView_Load(object sender, EventArgs e)
        {
            LoadSettings?.Invoke(this, EventArgs.Empty);
            LoadIP?.Invoke(this, EventArgs.Empty);
            LoadPort?.Invoke(this, EventArgs.Empty);
        }

        public void InitializeComboBoxEventHandler()
        {
            if (!isDataLoaded)
            {
                locationBox.SelectedIndexChanged += (sender, e) => SelectedIndexChanged?.Invoke(sender, e);
                isDataLoaded = true;
            }

            onRadio.CheckedChanged += (sender, e) =>
            {
                if (onRadio.Checked && lastMode != "on")
                {
                    mode = "on";
                    lastMode = "on";
                    HandleRadioButton?.Invoke(sender, e);
                }
            };

            offRadio.CheckedChanged += (sender, e) =>
            {
                if (offRadio.Checked && lastMode != "off")
                {
                    mode = "off";
                    lastMode = "off";
                    HandleRadioButton?.Invoke(sender, e);
                }
            };

            btnRestart.Click += delegate 
            { 
                RestartConnect?.Invoke(this, EventArgs.Empty);
                ILoginView loginView = new LoginView();
                LoginPresenter loginPresenter = new LoginPresenter(loginView, new LoginRepository());
                (loginView as Form)?.Show();
                //Application.Exit();
                this.Close();
            };

            btnClose.Click += delegate
            {
                this.Close();
            };
        }

        //Singeleton pattern (open a single  from instance)
        private static SettingView instance;
        public static SettingView GetInstance()
        {
            if (instance == null || instance.IsDisposed)
                instance = new SettingView();
            else
            {
                if (instance.WindowState == FormWindowState.Minimized)
                    instance.WindowState = FormWindowState.Normal;
                instance.BringToFront();
            }
            return instance;
        }
    }
}
