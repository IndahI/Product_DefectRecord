﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product_DefectRecord.Models
{
    public interface IDefectRepository
    {
        void Add(dynamic model);

        IEnumerable<DefectModel> GetFilter(int id);
        IEnumerable<DefectModel> GetAll();
        IEnumerable<DefectModel> GetByValue(string value);
        IEnumerable<DefectResultModel> GetAllResult();
        IEnumerable<DefectResultModel> GetFilterResult(DateTime selectedDate);
    }
}
