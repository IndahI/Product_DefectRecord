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

        public SettingModel()
        {
            _repository = new SettingRepository();
        }

        public List<string> GetLocationNames()
        {
            return _repository.GetData();
        }

        public int GetLocationId(string selectedLocationName)
        {
            return _repository.GetID(selectedLocationName);

        }
    }
}
