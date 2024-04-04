using Product_DefectRecord._Repositories;
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
        private ISettingView _view;
        private SettingModel _model;
        private SaveModel _smodel;

        public SettingPresenter(ISettingView view, SettingModel model)
        {
            _view = view;
            _model = model;
            _smodel = new SaveModel();

            // Subscribe to the view's events
            _view.SelectedIndexChanged += View_SelectedIndexChanged;
            _view.LoadSettings += View_LoadSettings;
        }

        private void View_LoadSettings(object sender, EventArgs e)
        {
            LoadLocationNames();
        }

        private void LoadLocationNames()
        {
            List<string> locationNames = _model.GetLocationNames();
            _view.LocationNames = locationNames;
            string loadedSetting = _smodel.LoadSetting();
            _view.DisplaySetting(loadedSetting);

            // After loading settings, notify the view that data is loaded
            _view.DataLoaded();
        }

        private void View_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;
            string location = comboBox.SelectedItem as string;

            if (comboBox.SelectedItem != null)
            {
                string selectedLocationName = comboBox.SelectedItem.ToString();
                _view.ShowSelectedItem(selectedLocationName);
                _smodel.SaveSetting(selectedLocationName);
                Console.WriteLine("isi dari yang dipilih " + location);
                // You may need to add saving logic here if it's not handled by the model
            }
        }
    }
}
