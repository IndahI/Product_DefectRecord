using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Product_DefectRecord.Models
{
    public class SaveModel
    {
        public event EventHandler<string> SettingsSaved;
        public event EventHandler<int> SettingsSavedId;
        public event EventHandler<string> SettingsLoaded;
        public event EventHandler<int> SettingsLoadedId;
        public event EventHandler<string> SettingsSavedMode; // Event untuk mode disimpan

        public void SaveSetting(string myData)
        {
            Properties.Settings.Default.MySetting = myData;
            Properties.Settings.Default.Save();
            OnSettingsSaved(myData);
        }

        public void SaveId(int Id)
        {
            Properties.Settings.Default.MyId = Id;
            Properties.Settings.Default.Save();
            OnSettingsSavedId(Id);
        }

        public string LoadSetting()
        {
            string myData = Properties.Settings.Default.MySetting;
            OnSettingsLoaded(myData);
            return myData;
        }

        public int LoadId()
        {
            int id = Properties.Settings.Default.MyId;
            OnSettingsLoadedId(id);
            return id;
        }

        public void SaveData(string data)
        {
            Properties.Settings.Default.Mode = data;
            Properties.Settings.Default.Save();
            OnSettingsSavedMode(data);
            Console.WriteLine(data);
        }

        protected virtual void OnSettingsSaved(string myData)
        {
            SettingsSaved?.Invoke(this, myData);
        }

        protected virtual void OnSettingsSavedId(int id)
        {
            SettingsSavedId?.Invoke(this, id);
        }

        protected virtual void OnSettingsSavedMode(string data) // Mengubah tipe parameter menjadi string
        {
            SettingsSavedMode?.Invoke(this, data); // Menggunakan parameter yang sesuai
        }

        protected virtual void OnSettingsLoaded(string myData)
        {
            SettingsLoaded?.Invoke(this, myData);
        }

        protected virtual void OnSettingsLoadedId(int id)
        {
            SettingsLoadedId?.Invoke(this, id);
        }
    }
}
