using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product_DefectRecord.Views
{
    public interface IPopUp
    {
        string SerialNumber { get; set; }
        string ModelNumber { get; set; }
        string DefectName { get; set; }
        string Inspector { get; set; }

        event EventHandler SaveDefect;
    }
}
