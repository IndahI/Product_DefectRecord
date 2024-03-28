using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Product_DefectRecord.Presenters.DefectPresenter;

namespace Product_DefectRecord.Views
{
    public interface IDefectView
    {

        //properties - fields


        string SerialNumber { get; set; }
        string ModelCode { get; set; }
        string ModelNumber { get; set; }
        string StatusText { get; set; }

        //event
        event EventHandler<ModelEventArgs> SearchModelNumber;
        event EventHandler ClearEvent;
        event TopDefectEventHandler DefectFilterEvent;
        event EventHandler EditButtonClicked;
        event EventHandler CellClicked;

        void FilterByPartId(int partId);
        void ShowPopupForm();

        void SetDefectListBindingSource(BindingSource defectList);
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
