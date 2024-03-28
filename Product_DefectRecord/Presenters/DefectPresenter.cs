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
        private EditDefectPresenter editDefectPresenter;

        public DefectPresenter(IDefectView view, IDefectRepository repository, IModelNumberRepository repository2)
        {
            this.defectsBindingSource = new BindingSource();
            this.view = view;
            this.editDefectPresenter = editDefectPresenter;
            this.repository = repository;
            this.repository2 = repository2;
            this.view.SearchModelNumber += SearchModelNumber;
            this.view.ClearEvent += ClearAction;
            this.view.DefectFilterEvent += LoadFilterDefect;
            this.view.EditButtonClicked += EditAction;
            this.view.CellClicked += CellClicked;
            //set defect binding source
            this.view.SetDefectListBindingSource(defectsBindingSource);
            //load all defect to list
            loadAllDefectList();
            //show
            this.view.Show();
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

        private void EditAction(object sender, EventArgs e)
        {
            //editDefectPresenter.HandleEditDefect();
            if (defectsBindingSource.Current != null)
            {
                var defect = (DefectModel)defectsBindingSource.Current;
                EditDefectName editDefect = new EditDefectName();
                editDefect.DefectId = defect.Id1.ToString();
                editDefect.PartId = defect.PartId1;
                editDefect.DefectName = defect.DefectName1;
                editDefect.IsEdit = true;
                editDefect.Show();
            }
            else
            {
                MessageBox.Show("gagal");
            }
        }

        private void LoadFilterDefect(object sender, EventArgs e, int id)
        {
            if (id != 0)
            {
                defectList = repository.GetFilter(id);
            }
            else
            {
                defectList = repository.GetAll();
            }
            defectsBindingSource.DataSource = defectList; //set data source
        }

        private void ClearAction(object sender, EventArgs e)
        {
            view.StatusText = "No Data";
        }

        //Methods
        private void loadAllDefectList()
        {
            defectList = repository.GetAll();
            defectsBindingSource.DataSource = defectList; //set data source
        }

        public delegate void TopDefectEventHandler(object sender, EventArgs e, int id);
        private void SearchModelNumber(object sender, ModelEventArgs e)
        {
            //string message = e.Message;
            //var searchModel = repository2.GetModelNumber(ModelCode);

            var model = new ModelCode();
            model.modelCode1 = view.ModelCode;

            var searchModel = repository2.GetModelNumber(model);

            if (searchModel != null)
            {
                view.ModelNumber = searchModel.ModelNumber;
                Console.WriteLine("Value of modelnumber: " + view.ModelNumber);
            }


        }

    }
}
