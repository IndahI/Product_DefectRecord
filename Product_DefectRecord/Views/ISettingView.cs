using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product_DefectRecord.Views
{
    public interface ISettingView
    {
        List<string> LocationNames { get; set; }
        event EventHandler LoadSettings;
        event EventHandler SelectedIndexChanged;
        void InitializeComboBoxEventHandler();
        void ShowSelectedItem(string item);
        void DisplaySetting(string myData);
        void DataLoaded();
    }
}
