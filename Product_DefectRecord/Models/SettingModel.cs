using Product_DefectRecord._Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product_DefectRecord.Models
{
    public class SettingModel
    {
        private SettingRepository _repository;

        public SettingModel(SettingRepository repository)
        {
            _repository = repository;
        }

        public List<string> GetLocationNames()
        {
            return _repository.GetData();
        }
    }
}
