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
        //fields
        IDefectView view;
        IEditDefect Edit;
        IDefectRepository Repository;
        private IEnumerable<DefectModel> defectList;
        private BindingSource defectsBindingSource;

        public EditDefectPresenter(IDefectView view,IEditDefect edit, IDefectRepository repository)
        {
            Edit = edit;
            this.view = view;
            this.Repository = repository;
            this.Edit.AddEvent += AddNewDefect;
            this.Edit.EditEvent += LoadSelectedDefectToEdit;
            this.Edit.DeleteEvent += DeleteSelectedDefect;
            this.Edit.SaveDefectEvent += SaveDefectEvent;
            this.Edit.CancleEvent += CancleAction;
            this.view.CellClicked += CellClicked;
            this.view.SetDefectListBindingSource(defectsBindingSource);
            loadAllDefectList();
        }

        public void HandleEditDefect()
        {
            if (defectsBindingSource.Current != null)
            {
                var defect = (DefectModel)defectsBindingSource.Current;
                Edit.DefectId = defect.Id1.ToString();
                Edit.PartId = defect.PartId1;
                Edit.DefectName = defect.DefectName1;
                Edit.IsEdit = true;
                //Edit.Show();
            }
            else
            {
                MessageBox.Show("gagal");
            }
        }

        private void CellClicked(object sender, EventArgs e)
        {
            var defect = (DefectModel)defectsBindingSource.Current;
            PopUp popUp = new PopUp();
            popUp.SerialNumber = view.SerialNumber;
            popUp.ModelNumber = view.ModelNumber;
            popUp.DefectName = defect.DefectName1;
            popUp.Show();
        }

        private void loadAllDefectList()
        {
            defectList = Repository.GetAll();
            defectsBindingSource.DataSource = defectList; //set data source
        }


        //methods
        private void CancleAction(object sender, EventArgs e)
        {
            CleanviewFields();
        }

        private void SaveDefectEvent(object sender, EventArgs e)
        {
            var model = new DefectModel();
            model.Id1 = Convert.ToInt32(Edit.DefectId);
            model.PartId1 = Edit.PartId;
            model.DefectName1 = Edit.DefectName;

            try
            {
                new Common.ModelDataValidation().Validate(model);
                if (Edit.IsEdit)//edit model
                {
                    Repository.Edit(model);
                    Edit.Message = "Defect terlah terubah";
                }
                Edit.IsSuccessful = true;
                loadAllDefectList();
                CleanviewFields();
            }
            catch (Exception ex)
            {
                Edit.IsSuccessful = false;
                Edit.Message = ex.Message;
            }
        }

        private void CleanviewFields()
        {
            //Edit.DefectId = "0";
            //Edit.PartId = "0";
            //Edit.DefectName = "";
        }

        private void DeleteSelectedDefect(object sender, EventArgs e)
        {
            try
            {
                var defect = (DefectModel)defectsBindingSource.Current;
                Repository.Delete(defect.Id1);
                Edit.IsSuccessful = true;
                Edit.Message = "defect berhasil ditambahkan";
                loadAllDefectList();
            }
            catch (Exception ex)
            {
                Edit.IsSuccessful = false;
                Edit.Message = ex.Message + "error saat menghapus";
            }
        }

        private void LoadSelectedDefectToEdit(object sender, EventArgs e)
        {
            var defect = (DefectModel)defectsBindingSource.Current;
            Edit.DefectId = defect.Id1.ToString();
            Edit.PartId = defect.PartId1;
            Edit.DefectName = defect.DefectName1;

            // Memperbarui defect yang ada di repositori
            Repository.Edit(defect);
        }

        private void AddNewDefect(object sender, EventArgs e)
        {
            Edit.IsEdit = false;
        }
    }
}
