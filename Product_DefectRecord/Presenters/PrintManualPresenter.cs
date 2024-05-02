using Product_DefectRecord.Models;
using Product_DefectRecord.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Product_DefectRecord.Presenters
{
    public class PrintManualPresenter
    {
        private IDefectListView view;
        private string latestReceivedData = "";
        public PrintManualPresenter(IDefectListView view) 
        {
            this.view = view;
            view.KeyDownEvent += KeyDownEvent;
        }

        public void KeyDownEvent(object sender, KeyEventArgs e)
        {
            if(view.IsKeyboardEnabled)
            {
                if(e.KeyCode == Keys.Enter)
                {
                    string latestReceivedData = view.SerialNumber;
                    Console.WriteLine(latestReceivedData);
                    view.IsKeyboardEnabled = false;
                    string trim = latestReceivedData.Substring(0, 2).Trim();
                    string trim2 = latestReceivedData.Substring(2).Trim();
                    Console.WriteLine(trim);
                    view.SerialNumber = trim2;
                    view.ModelCode = trim;
                }
            }
            else
            {
                e.SuppressKeyPress = true;
            }
        }
    }
}
