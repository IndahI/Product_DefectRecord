using Product_DefectRecord.Models;
using Product_DefectRecord.Views;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Product_DefectRecord.Presenters
{
    public class SettingPresenter
    {
        private ISettingView _settingView;
        private SaveModel _model;
        private string _selectedLocationName; // Menyimpan selectedLocationName di properti kelas

        public SettingPresenter(ISettingView settingView)
        {
            _settingView = settingView;
            _model = new SaveModel();
            _settingView.LoadSettings += OnLoadSettings;
            _settingView.SelectedIndexChanged += View_SelectedIndexChanged;
            Console.WriteLine("Presenter");
        }

        private void View_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;

            // Check if any item is selected
            if (comboBox.SelectedItem != null)
            {
                // Get the selected item (assuming the data source is a DataRowView)
                DataRowView selectedItem = (DataRowView)comboBox.SelectedItem;

                // Access column values by DisplayMember and ValueMember
                //int selectedId = (int)selectedItem["id"]; // Use ValueMember
                _selectedLocationName = (string)selectedItem["LocationName"]; // Simpan selectedLocationName ke properti kelas
                _settingView.ShowSelectedItem(_selectedLocationName);
                _model.SaveSetting(_selectedLocationName); // Menggunakan nilai selectedLocationName dari properti kelas
            }
            else{}
        }


        private void OnLoadSettings(object sender, EventArgs e)
        {
            string loadedSetting = _model.LoadSetting();
            _settingView.DisplaySetting(loadedSetting);
        }

    }
}
