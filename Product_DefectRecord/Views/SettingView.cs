using Product_DefectRecord._Repositories;
using Product_DefectRecord.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Product_DefectRecord.Views
{
    public partial class SettingView : Form, ISettingView
    {
        private bool isDataLoaded = false;
        public SettingView()
        {
            InitializeComponent();
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
        public string mode 
        {
            get {
                if (radioButton1.Checked)
                    return radioButton1.Text;
                else if (radioButton2.Checked)
                    return radioButton2.Text;
                // Tambahkan kondisi untuk radio button lainnya jika perlu
                else
                    return string.Empty;
            } 
            set
            {
                if (value == radioButton1.Text)
                    radioButton1.Checked = true;
                else if (value == radioButton2.Text)
                    radioButton2.Checked = true;
            }
        }

        public event EventHandler SelectedIndexChanged;
        public event EventHandler LoadSettings;
        public event EventHandler HandleRadioButton;

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
        }

        public void InitializeComboBoxEventHandler()
        {
            if (!isDataLoaded)
            {
                locationBox.SelectedIndexChanged += (sender, e) => SelectedIndexChanged?.Invoke(sender, e);
                isDataLoaded = true;
            }
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
