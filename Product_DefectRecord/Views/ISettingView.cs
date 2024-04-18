using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product_DefectRecord.Views
{
    public interface ISettingView
    {
        // Properties
        string mode { get; set; }
        List<string> LocationNames { get; set; }

        // Events
        event EventHandler LoadSettings;
        event EventHandler SelectedIndexChanged;
        event EventHandler HandleRadioButton;

        // Methods
        void DisplaySetting(string myData);
        void ShowSelectedItem(string item);
        void DataLoaded();
    }
}
