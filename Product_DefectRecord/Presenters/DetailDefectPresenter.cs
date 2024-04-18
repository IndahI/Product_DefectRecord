using Product_DefectRecord.Models;
using Product_DefectRecord.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Product_DefectRecord.Presenters
{
    public class DetailDefectPresenter
    {
        private readonly IDetailDefectView view;
        private readonly IDefectRepository repository;
        private SaveModel _smodel;

        public DetailDefectPresenter(IDetailDefectView view, IDefectRepository repository, dynamic detailDefect)
        {
            this.view = view;
            this.repository = repository;
            _smodel = new SaveModel();
            this.view.SaveEvent += SaveEvent;
            SetData(detailDefect);
            this.view.Show();
        }

        private void SetData(dynamic detailDefect)
        {
            view.SerialNumber = detailDefect.SerialNumber;
            view.ModelCode = detailDefect.ModelCode;
            view.ModelNumber = detailDefect.ModelNumber;
            view.DefectId = detailDefect.DefectId;
            view.DefectName = detailDefect.DefectName;
            view.InspectorId = detailDefect.InspectorId;
            view.InspectorName = detailDefect.Inspector;
            view.Location = detailDefect.Location;
        }

        private void SaveEvent(object sender, EventArgs e)
        {
            var model = new
            {
                view.SerialNumber,
                view.ModelNumber,
                view.ModelCode,
                view.DefectId,
                view.DefectName,
                view.InspectorId,
                view.InspectorName,
                view.Location,
            };

            try
            {
                new Common.ModelDataValidation().Validate(model);
                repository.Add(model);
                view.Message = "Defect telah disimpan";
            }
            catch (Exception ex)
            {
                view.Message = ex.Message;
            }

            MessageBox.Show(view.Message);
        }
    }
}
