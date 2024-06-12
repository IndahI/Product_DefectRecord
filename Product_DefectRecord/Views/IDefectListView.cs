using System;
using System.Drawing;
using System.Windows.Forms;
using static Product_DefectRecord.Presenters.DefectListPresenter;

namespace Product_DefectRecord.Views
{
    public interface IDefectListView
    {
        //void AddNoData();
        //void RemoveNoData(BindingSource defectList);
        //void SetDefectListBindingSource(BindingSource defectList);
        //void ShowPopupForm();
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
