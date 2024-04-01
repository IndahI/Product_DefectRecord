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
    public class EditDefectPresenter
    {
        private readonly IEditDefectView view;
        private readonly IDefectRepository repository;

        public EditDefectPresenter(IEditDefectView view, IDefectRepository repository, DefectModel defect)
        {
            this.view = view;
            this.repository = repository;
            this.view.EditEvent += EditEvent;
            SetData(defect);
            this.view.Show();
        }

        private void SetData(DefectModel defect)
        {
            view.DefectId = defect.Id1.ToString();
            view.PartName = defect.PartId1;
            view.DefectName = defect.DefectName1;
        }

        private void EditEvent(object sender, EventArgs e)
        {
            var model = new DefectModel
            {
                Id1 = Convert.ToInt32(view.DefectId),
                PartId1 = view.PartName,
                DefectName1 = view.DefectName
            };

            try
            {
                new Common.ModelDataValidation().Validate(model);
                repository.Edit(model);
                view.Message = "Defect telah terubah";
            }
            catch (Exception ex)
            {
                view.Message = ex.Message;
            }

            MessageBox.Show(view.Message);
        }
    }
}
