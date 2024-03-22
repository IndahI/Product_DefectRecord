using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product_DefectRecord.Models
{
    public class ModelCode
    {
        private string modelCode;

        //properties
        [DisplayName("modelCode")]
        public string modelCode1
        {
            get => modelCode;
            set => modelCode = value;
        }
    }
}
