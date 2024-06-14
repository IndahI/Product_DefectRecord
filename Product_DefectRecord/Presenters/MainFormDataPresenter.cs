using Product_DefectRecord.Models;
using Product_DefectRecord.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product_DefectRecord.Presenters
{
    public class MainFormDataPresenter
    {
        public IPrintRecord View { get; }
        public IDefectRepository DefectRepository { get; }
        public IModelNumberRepository ModelNumberRepository { get; }
        public LoginModel User { get; }

        public MainFormDataPresenter(IPrintRecord view, IDefectRepository defectRepository, IModelNumberRepository modelNumberRepository, LoginModel user)
        {
            View = view;
            DefectRepository = defectRepository;
            ModelNumberRepository = modelNumberRepository;
            User = user;
        }
    }
}
