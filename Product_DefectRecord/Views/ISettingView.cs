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

        string ipaddress { get; set; }

        int portaddress { get; set; }

        // Events
        event EventHandler SelectedIndexChanged;
        event EventHandler LoadSettings;
        event EventHandler HandleRadioButton;
        event EventHandler SaveIPSettings;
        event EventHandler SavePortSettings;
        event EventHandler LoadIP;
        event EventHandler LoadPort;
        event EventHandler SaveConnect;

        // Methods
        void DisplayIP(string IPaddress);
        void DisplayPort(int Port);
        void DisplaySetting(string myData);
        void ShowSelectedItem(string item);
        void DataLoaded();
    }
}
