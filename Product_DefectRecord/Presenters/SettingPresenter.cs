using Product_DefectRecord._Repositories;
using Product_DefectRecord.Models;
using Product_DefectRecord.Views;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Product_DefectRecord.Presenters
{
    public class SettingPresenter
    {
        private readonly ISettingView _view;
        private readonly SettingModel _model;
        private readonly SaveModel _smodel;

        public SettingPresenter(ISettingView view, SettingModel model)
        {
            _view = view;
            _model = model;
            _smodel = new SaveModel();

            // Subscribe to the view's events
            _view.SelectedIndexChanged += View_SelectedIndexChanged;
            _view.LoadSettings += View_LoadSettings;
            _view.HandleRadioButton += HandleRadioButton;
            _view.SaveIPSettings += SaveIPSettings;
            _view.SavePortSettings += SavePortSettings;
            _view.LoadIP += View_LoadIP;
            _view.LoadPort += View_LoadPort;
            _view.SaveConnect += SaveConnect;
        }

        private void SaveConnect(object sender, EventArgs e)
        {
            _smodel.SaveSettingIP(_view.ipaddress);
            _smodel.SaveSettingPort(_view.portaddress);
            MessageBox.Show("Connected to server!", "Connection Status", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void View_LoadIP(object sender, EventArgs e)
        {
            string loadedIP = _smodel.LoadIP();
            _view.DisplayIP(loadedIP);
        }

        private void View_LoadPort(object sender, EventArgs e)
        {
            int loadedPort = _smodel.LoadPort();
            _view.DisplayPort(loadedPort);
        }

        private void View_LoadSettings(object sender, EventArgs e)
        {
            LoadLocationNames();
        }

        private void HandleRadioButton(object sender, EventArgs e)
        {
            if (_view.mode == "on")
                onRadio_Checked();
            else if (_view.mode == "off")
                offRadio_Checked();
        }

        private void onRadio_Checked()
        {
            _smodel.SaveData(_view.mode);
            //Console.WriteLine(_view.mode);
        }

        private void offRadio_Checked()
        {
            _smodel.SaveData(_view.mode);
            Console.WriteLine(_view.mode);
        }

        private void LoadLocationNames()
        {
            List<string> locationNames = _model.GetLocationNames();
            _view.LocationNames = locationNames;
            string loadedSetting = _smodel.LoadSetting();
            _view.DisplaySetting(loadedSetting);
            int loadId = _smodel.LoadId();

            // Setelah memuat pengaturan, memberi tahu view bahwa data telah dimuat
            _view.DataLoaded();
        }

        private void SaveIPSettings(object sender, EventArgs e)
        {
            _smodel.SaveSettingIP(_view.ipaddress);
        }

        private void SavePortSettings(object sender, EventArgs e)
        {
            _smodel.SaveSettingPort(_view.portaddress);
        }

        private void View_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;
            string location = comboBox?.SelectedItem as string;

            if (comboBox?.SelectedItem != null)
            {
                string selectedLocationName = comboBox.SelectedItem.ToString();
                _view.ShowSelectedItem(selectedLocationName);
                _smodel.SaveSetting(selectedLocationName);

                // Memeriksa apakah selectedLocationName memiliki nilai sebelum memanggil repo
                if (!string.IsNullOrEmpty(selectedLocationName))
                {
                    // Panggil metode repo di sini dengan selectedLocationName sebagai parameter
                    int locationId = _model.GetLocationId(selectedLocationName);
                    _smodel.SaveId(locationId);
                    Console.WriteLine(locationId);
                }
            }
        }
    }
}
