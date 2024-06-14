using System;
using System.Drawing;
using System.Windows.Forms;
using static Product_DefectRecord.Presenters.MainFormPresenter;

namespace Product_DefectRecord.Views
{
    public interface IMainFormView
    {
        void Show();
    }

    public class ModelEventArgs : EventArgs
    {
        public string Message { get; set; }

        public ModelEventArgs(string message)
        {
            Message = message;
        }
    }
}
