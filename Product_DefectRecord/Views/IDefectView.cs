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
        string StatusText { get; set; }

        //event
        event EventHandler SearchModelNumber;
        event EventHandler ClearEvent;
        event TopDefectEventHandler DefectFilterEvent;
        event EventHandler EditButtonClicked;
        event EventHandler<DataGridViewCellEventArgs> CellClicked;

        void FilterByPartId(int partId);
        void ShowPopupForm(IEditDefect selectDefect);

        void SetDefectListBindingSource(BindingSource defectList);
        void Show();
    }
}
