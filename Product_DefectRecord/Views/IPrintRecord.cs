using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Product_DefectRecord.Presenters.DefectListPresenter;
using static Product_DefectRecord.Presenters.PrintRecordPresenter;

namespace Product_DefectRecord.Views
{
    public interface IPrintRecord
    {
        //properties - fields
        string SerialNumber { get; set; }
        string ModelCode { get; set; }
        string ModelNumber { get; set; }
        string InspectorId { get; set; }
        string Inspector { get; set; }
        string StatusText { get; set; }
        bool IsKeyboardEnabled { get; set; }
        Color BackColorStatus { get; set; }
        Color ForeColorStatus { get; set; }
        DateTime SelectedDate { get; }

        //event
        event EventHandler<ModelEventArgs> SearchModelNumber;
        event EventHandler ClearEvent;
        event TopDefectEventHandler DefectFilterEvent;
        event EventHandler EditButtonClicked;
        event EventHandler CellClicked;
        event KeyEventHandler KeyDownEvent;
        event EventHandler SearchFilter;

        void SelectTabPageByIndex(int data);
        void AddNoData();
        void RemoveNoData(BindingSource defectList);
        void SetDefectListBindingSource(BindingSource defectList);
        void SetDefectListBindingSource2(BindingSource resultList);
        void ShowPopupForm();
        void Show();
    }
}
