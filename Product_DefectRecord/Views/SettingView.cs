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
        public SettingView()
        {
            InitializeComponent();
            locationBox.SelectedIndexChanged += (sender, e) => SelectedIndexChanged?.Invoke(sender, e);
            Load += SettingView_Load;
            Console.WriteLine("View");
        }

        public int Id { get; set; }
        public string LocationName 
        {
            get { return locationBox.Text; }
            set { locationBox.Text = value; } 
        }

        public event EventHandler SelectedIndexChanged;
        public event EventHandler LoadSettings;

        public void DisplaySetting(string myData)
        {
            locationBox.Text = myData;
        }

        public void ShowSelectedItem(string item)
        {

        }

        private void SettingView_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'lSBUDBDataSet.Locations' table. You can move, or remove it, as needed.
            this.locationsTableAdapter.Fill(this.lSBUDBDataSet.Locations);
            LoadSettings?.Invoke(this, EventArgs.Empty);

        }
    }
}
