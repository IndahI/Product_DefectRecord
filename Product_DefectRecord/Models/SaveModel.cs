using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product_DefectRecord.Models
{
    public class SaveModel
    {
        public event EventHandler<string> SettingsSaved;
        public event EventHandler<string> SettingsLoaded;

        public void SaveSetting(string myData)
        {
            Properties.Settings.Default.MySetting = myData;
            Properties.Settings.Default.Save();
            OnSettingsSaved(myData);
        }

        public string LoadSetting()
        {
            string myData = Properties.Settings.Default.MySetting;
            OnSettingsLoaded(myData);
            return myData;
        }

        protected virtual void OnSettingsSaved(string myData)
        {
            SettingsSaved?.Invoke(this, myData);
        }

        protected virtual void OnSettingsLoaded(string myData)
        {
            SettingsLoaded?.Invoke(this, myData);
        }
    }
}
