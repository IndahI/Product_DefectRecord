﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product_DefectRecord.Views
{
    public interface IDetailDefectView
    {
        string SerialNumber { get; set; }
        string ModelCode { get; set; }
        string ModelNumber { get; set; }
        int DefectId { get; set; }
        string DefectName { get; set; }
        string InspectorId { get; set; }
        string InspectorName { get; set; }
        int Location { get; set; }
        string Message { get; set; }

        event EventHandler SaveEvent;
        void Show();
    }
}
