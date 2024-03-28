using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product_DefectRecord.Views
{
    public interface IEditDefect
    {
        //properties
        string DefectId { get; set; }
        string PartId { get; set; }
        string DefectName { get; set; }
        bool IsEdit { get; set; }
        bool IsSuccessful { get; set; }
        string Message { get; set; }

        //Event
        event EventHandler AddEvent;
        event EventHandler EditEvent;
        event EventHandler SaveDefectEvent;
        event EventHandler DeleteEvent;
        event EventHandler CancleEvent;
    }
}
