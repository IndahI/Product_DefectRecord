using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product_DefectRecord.Views
{
    public interface ISettingView
    {
        int Id { get; set; }
        string LocationName { get; set; }

        event EventHandler SelectedIndexChanged;
        event EventHandler LoadSettings;
        void ShowSelectedItem(string item);
        void DisplaySetting(string myData);
    }
}
