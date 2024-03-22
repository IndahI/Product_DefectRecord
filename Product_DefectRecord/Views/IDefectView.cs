using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Product_DefectRecord.Views
{
    public interface IDefectView
    {

        //properties - fields
        string DefectId { get; set; }
        string PartId { get; set; }
        string DefectName { get; set; }

        string SearchValue { get; set; }
        bool IsEdit { get; set; }
        bool IsSuccessful { get; set; }
        string Message { get; set; }
        string SerialNumber { get; set; }
        string ModelCode { get; set; }

        //event
        event EventHandler SearchEvent;
        event EventHandler AddEvent;
        event EventHandler EditEvent;
        event EventHandler SaveEvent;
        event EventHandler DeleteEvent;
        event EventHandler CancleEvent;
        event EventHandler SearchModelNumber;

        void SetDefectListBindingSource(BindingSource defectList);
        void Show();
    }
}
