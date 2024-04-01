using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product_DefectRecord.Models
{
    public interface IDefectRepository
    {
        void Add(dynamic model);
        void Edit(DefectModel defectmodel);
        void Delete(int Id);

        IEnumerable<DefectModel> GetFilter(int id);
        IEnumerable<DefectModel> GetAll();
        IEnumerable<DefectModel> GetByValue(string value);
    }
}
