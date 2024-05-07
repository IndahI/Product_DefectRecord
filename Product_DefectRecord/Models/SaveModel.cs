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
        public event EventHandler<string> SettingsSavedMode;
        public event EventHandler<string> SaveSettingsIP;
        public event EventHandler<int> SaveSettingsPort;

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

        public string LoadIP()
        {
            string ipaddress = Properties.Settings.Default.ServerIP;
            OnSettingsLoaded(ipaddress);
            return ipaddress;
        }

        public int LoadPort()
        {
            int port = Properties.Settings.Default.Port;
            OnSettingsLoaded(port.ToString());
            return port;
        }

        public void SaveData(string data)
        {
            Properties.Settings.Default.Mode = data;
            Properties.Settings.Default.Save();
            OnSettingsSavedMode(data);
        }

        public void SaveSettingIP(string serverIP)
        {
            Properties.Settings.Default.ServerIP = serverIP;
            Properties.Settings.Default.Save();
            OnSettingsSaved(serverIP);
        }

        public void SaveSettingPort(int port)
        {
            Properties.Settings.Default.Port = port;
            Properties.Settings.Default.Save();
            OnSaveSettingsPort(port);
        }

        public string GetMode()
        {
            return Properties.Settings.Default.Mode;
        }

        protected virtual void OnSettingsSaved(string myData)
        {
            SettingsSaved?.Invoke(this, myData);
        }

        protected virtual void OnSettingsSavedId(int id)
        {
            SettingsSavedId?.Invoke(this, id);
        }

        protected virtual void OnSettingsSavedMode(string data)
        {
            SettingsSavedMode?.Invoke(this, data);
        }

        protected virtual void OnSettingsLoaded(string myData)
        {
            SettingsLoaded?.Invoke(this, myData);
        }

        protected virtual void OnSettingsLoadedId(int id)
        {
            SettingsLoadedId?.Invoke(this, id);
        }

        protected virtual void OnSaveSettingsPort(int port)
        {
            SaveSettingsPort?.Invoke(this, port);
        }
    }
}