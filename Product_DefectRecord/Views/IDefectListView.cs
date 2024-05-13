using System;
using System.Windows.Forms;
using static Product_DefectRecord.Presenters.DefectListPresenter;

namespace Product_DefectRecord.Views
{
    public interface IDefectListView
    {

        //properties - fields
        string SerialNumber { get; set; }
        string ModelCode { get; set; }
        string ModelNumber { get; set; }
        string InspectorId { get; set; }
        string Inspector { get; set; }
        string StatusText { get; set; }
        bool IsKeyboardEnabled { get; set; }

        //event
        event EventHandler<ModelEventArgs> SearchModelNumber;
        event EventHandler ClearEvent;
        event TopDefectEventHandler DefectFilterEvent;
        event EventHandler EditButtonClicked;
        event EventHandler CellClicked;
        event KeyEventHandler KeyDownEvent;

        void AddNoData();
        void RemoveNoData();
        void SetDefectListBindingSource(BindingSource defectList);
        void FilterByPartId(int partId);
        void ShowPopupForm();
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
