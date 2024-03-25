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
        private string modelNumber;

        //properties
        [DisplayName("modelCode")]
        public string modelCode1
        {
            get => modelCode;
            set => modelCode = value;
        }

        [DisplayName("ModelNumber")]
        public string ModelNumber 
        { 
            get => modelNumber; 
            set => modelNumber = value;
        }
    }
}
