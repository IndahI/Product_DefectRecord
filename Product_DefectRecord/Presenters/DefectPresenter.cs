using Product_DefectRecord.Models;
using Product_DefectRecord.Views;
using Product_DefectRecord.Presenters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Product_DefectRecord.Presenters
{
    public class DefectPresenter
    {
        //fields
        private IDefectView view;
        private IDefectRepository repository;
        private IModelNumberRepository repository2;
        private BindingSource defectsBindingSource;
        private IEnumerable<DefectModel> defectList;

        public DefectPresenter(IDefectView view, IDefectRepository repository, IModelNumberRepository repository2)
        {
            this.defectsBindingSource = new BindingSource();
            this.view = view;
            this.repository = repository;
            this.repository2 = repository2;
            this.view.SearchEvent += SearchDefect;
            this.view.AddEvent += AddNewDefect;
            this.view.EditEvent += LoadSelectedDefectToEdit;
            this.view.DeleteEvent += DeleteSelectedDefect;
            this.view.SaveEvent += SaveDefect;
            this.view.CancleEvent += CancleAction;
            this.view.SearchModelNumber += SearchModelNumber;
            //set defect binding source
            this.view.SetDefectListBindingSource(defectsBindingSource);
            //load all defect to list
            loadAllDefectList();
            //show
            this.view.Show();
        }


        //Methods
        private void loadAllDefectList()
        {
            defectList = repository.GetAll();
            defectsBindingSource.DataSource = defectList; //set data source
        }

        private void SearchModelNumber(object sender, EventArgs e)
        {
            bool emptyValue = string.IsNullOrWhiteSpace(this.view.SerialNumber);
            if (!emptyValue)
            {
                ModelCode modelCode = repository2.GetModelNumber(this.view.SerialNumber);
                view.ModelCode = modelCode.ToString(); // Convert ModelCode to string
            }
        }
        private void SearchDefect(object sender, EventArgs e)
        {
            bool emptyValue = string.IsNullOrWhiteSpace(this.view.SearchValue);
            if (emptyValue == false)
                defectList = repository.GetByValue(this.view.SearchValue);
            else defectList = repository.GetAll();
            defectsBindingSource.DataSource = defectList;
        }

        private void CancleAction(object sender, EventArgs e)
        {
            CleanviewFields();
        }

        private void CleanviewFields()
        {
            view.DefectId = "0";
            view.PartId = "0";
            view.DefectName = "";
        }

        private void SaveDefect(object sender, EventArgs e)
        {
            var model = new DefectModel();
            model.Id1 = Convert.ToInt32(view.DefectId);
            model.PartId1 = view.PartId;
            model.DefectName1 = view.DefectName;

            try
            {
                new Common.ModelDataValidation().Validate(model);
                if (view.IsEdit)//edit model
                {
                    repository.Edit(model);
                    view.Message = "Defect terlah terubah";
                }
                else//add model
                {
                    repository.Add(model);
                    view.Message = "defect berhasil ditambahkan";
                }
                view.IsSuccessful = true;
                loadAllDefectList();
                CleanviewFields();
            }
            catch (Exception ex)
            {
                view.IsSuccessful = false;
                view.Message = ex.Message;
            }
        }

        private void DeleteSelectedDefect(object sender, EventArgs e)
        {
            try
            {
                var defect = (DefectModel)defectsBindingSource.Current;
                repository.Delete(defect.Id1);
                view.IsSuccessful = true;
                view.Message = "defect berhasil ditambahkan";
                loadAllDefectList();
            }
            catch (Exception ex)
            {
                view.IsSuccessful = false;
                view.Message = "error saat menghapus";
            }
        }

        private void LoadSelectedDefectToEdit(object sender, EventArgs e)
        {
            var defect = (DefectModel)defectsBindingSource.Current;
            view.DefectId = defect.Id1.ToString();
            view.PartId = defect.PartId1;
            view.DefectName = defect.DefectName1;
            view.IsEdit = true;
        }

        private void AddNewDefect(object sender, EventArgs e)
        {
            view.IsEdit = false;
        }
    }
}
