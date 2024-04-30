using Product_DefectRecord.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        private void KeyDownEvent(object sender, KeyEventArgs e)
        {
            if(view.IsKeyboardEnabled)
            {
                if(e.KeyCode == Keys.Enter)
                {
                    string latestReceivedData = view.SerialNumber;
                    Console.WriteLine(latestReceivedData);
                    view.IsKeyboardEnabled = false;
                    string jgda = latestReceivedData.Substring(2).Trim();
                }
                else
                {
                    string character = view.ConvertKeyCodeToString(e.KeyCode);
                    latestReceivedData += character;
                }
            }
            else
            {
                e.SuppressKeyPress = true;
            }
        }
    }
}
