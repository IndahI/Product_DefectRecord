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
        private IEditDefect edit;
        private IDefectRepository repository;
        private IModelNumberRepository repository2;
        private BindingSource defectsBindingSource;
        private IEnumerable<DefectModel> defectList;
        private List<IEditDefect> _selectEdit;

        public DefectPresenter(IDefectView view, IDefectRepository repository, IModelNumberRepository repository2, IEditDefect edit, List<IEditDefect> selectEdit)
        {
            this.defectsBindingSource = new BindingSource();
            this.view = view;
            _selectEdit = selectEdit;
            this.repository = repository;
            this.repository2 = repository2;
            this.view.SearchModelNumber += SearchModelNumber;
            this.view.ClearEvent += ClearAction;
            this.view.DefectFilterEvent += LoadFilterDefect;
            this.view.EditButtonClicked += EditAction;
            this.view.CellClicked += viewCellClicked;
            //set defect binding source
            this.view.SetDefectListBindingSource(defectsBindingSource);
            //load all defect to list
            loadAllDefectList();
            //show
            this.view.Show();

            this.edit = edit;
            this._selectEdit = selectEdit;
        }

        private void viewCellClicked(object sender, DataGridViewCellEventArgs e)
        {
            int selectedIndex = e.RowIndex;
            if (selectedIndex >= 0 && selectedIndex < _selectEdit.Count)
            {
                IEditDefect selectedPerson = _selectEdit[selectedIndex];
                view.ShowPopupForm(selectedPerson);
            }
        }

        private void EditAction(object sender, EventArgs e)
        {
            if (defectsBindingSource.Current != null)
            {
                var defect = (DefectModel)defectsBindingSource.Current;
                //edit.DefectId = defect.Id1.ToString();
                //edit.PartId = defect.PartId1;
                //edit.DefectName = defect.DefectName1;
                //edit.IsEdit = true;
                EditDefectName editDefect = new EditDefectName();
                editDefect.DefectId = defect.Id1.ToString();
                editDefect.PartId = defect.PartId1;
                editDefect.DefectName = defect.DefectName1;
                editDefect.Show();
            }
            else
            {
                MessageBox.Show("gagal");
            }
        }

        private void LoadFilterDefect(object sender, EventArgs e, int id)
        {
            defectList = repository.GetFilter(id);
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
        private void SearchModelNumber(object sender, EventArgs e)
        {
            bool emptyValue = string.IsNullOrWhiteSpace(this.view.SerialNumber);
            if (!emptyValue)
            {
                ModelCode modelCode = repository2.GetModelNumber(this.view.SerialNumber);
                view.ModelCode = modelCode.ToString(); // Convert ModelCode to string
                view.SerialNumber = modelCode.ToString();
            }
        }
    }
}
