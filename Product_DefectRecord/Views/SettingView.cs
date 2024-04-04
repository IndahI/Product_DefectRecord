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

        public event EventHandler SelectedIndexChanged;
        public event EventHandler LoadSettings;

        public void DisplaySetting(string myData)
        {
            locationBox.Text = myData;
        }

        public void ShowSelectedItem(string item)
        {
            MessageBox.Show(item);
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


    }
}
