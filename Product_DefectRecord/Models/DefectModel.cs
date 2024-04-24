using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product_DefectRecord.Models
{
    public class DefectModel
    {
        //Fields
        private int Id;
        private string PartId;
        private string DefectName;

        //properties
        [DisplayName("No")]
        [Browsable(false)] // Tambahkan atribut ini
        public int Id1
        {
            get => Id;
            set => Id = value;
        }

        [DisplayName("Part Name")]
        public string PartId1
        {
            get => PartId;
            set => PartId = value;
        }

        [DisplayName("Defect Name")]
        [Required(ErrorMessage = "Name defect perlu diisi")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "nama defect minimal berisi 3 karakter dan maxsimal 50 karakter")]
        public string DefectName1
        {
            get => DefectName;
            set => DefectName = value;
        }
    }
}
