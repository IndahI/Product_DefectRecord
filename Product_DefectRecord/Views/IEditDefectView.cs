using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product_DefectRecord.Views
{
    public interface IEditDefectView
    {
        //properties
        string DefectId { get; set; }
        string PartName { get; set; }
        string DefectName { get; set; }
        string Message { get; set; }

        event EventHandler EditEvent;

        void Show();
    }
}
