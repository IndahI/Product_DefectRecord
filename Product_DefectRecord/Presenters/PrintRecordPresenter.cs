using Product_DefectRecord.Models;
using Product_DefectRecord.Views;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Product_DefectRecord.Presenters
{
    public class PrintRecordPresenter
    {
        private IPrintRecord view;
        private IDefectRepository defectRepository;
        private IModelNumberRepository modelNumberRepository;
        private BindingSource defectsBindingSource;
        private BindingSource defectsBindingSource2;
        private IEnumerable<DefectModel> defectList;
        private IEnumerable<DefectResultModel> resultList;
        private SaveModel _smodel;
        private bool showNoData = false;
        public PrintRecordPresenter(MainFormDataPresenter data) 
        {
            this.view = data.View;
            this.defectRepository = data.DefectRepository;
            this.modelNumberRepository = data.ModelNumberRepository;
            this.view.InspectorId = data.User.Nik;
            this.view.Inspector = data.User.Name;

            _smodel = new SaveModel();
            defectsBindingSource = new BindingSource();
            defectsBindingSource2 = new BindingSource();

            this.view.SearchModelNumber += SearchModelNumber;
            this.view.ClearEvent += ClearAction;
            this.view.DefectFilterEvent += LoadFilterDefect;
            //this.view.CellClicked += CellClicked;
            this.view.SearchFilter += SearchFilter;
            this.view.CheckProperties += CheckProperties;

            this.view.SetDefectListBindingSource(defectsBindingSource);
            this.view.SetDefectListBindingSource2(defectsBindingSource2);

            LoadAllDefectList();
            LoadAllResultDefect();

            this.view.Show();
        }

        private void CheckProperties(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(view.ModelNumber))
            {
                view.StatusText = "Model Number dan Mode Code Harus terisi";
                view.BackColorStatus = Color.Orange;
                view.ForeColorStatus = Color.Black;
                return;
            }

            view.StatusText = "Simpan dan Print";
            view.BackColorStatus = Color.Green;
            view.ForeColorStatus = Color.White;
            CellClicked();
        }

        public void SearchFilter(object sender, EventArgs e)
        {
            resultList = defectRepository.GetFilterResult(view.SelectedDate);
            defectsBindingSource2.DataSource = resultList;
            view.SetDefectListBindingSource2(defectsBindingSource2);
        }

        public void LoadAllResultDefect()
        {
            resultList = defectRepository.GetAllResult();
            defectsBindingSource2.DataSource = resultList;
            view.SetDefectListBindingSource2(defectsBindingSource2);
        }

        public void ChangeTabPage(int index)    
        {
            view.SelectTabPageByIndex(index);
        }

        private void CellClicked()
        {
            int Location = _smodel.LoadId();
            var defect = (DefectModel)defectsBindingSource.Current;
            var detailDefect = new
            {
                SerialNumber = view.SerialNumber,
                ModelNumber = view.ModelNumber,
                ModelCode = view.ModelCode,
                DefectId = defect.Id1,
                DefectName = defect.DefectName1,
                InspectorId = view.InspectorId,
                Inspector = view.Inspector,
                Location = Location
            };
            var detailDefectView = DetailDefectView.GetInstance();
            new DetailDefectPresenter(DetailDefectView.GetInstance(), defectRepository, detailDefect);
            detailDefectView.DataSaved += (s, e) => LoadAllResultDefect();
        }

        private void LoadFilterDefect(object sender, EventArgs e, int id)
        {
            if (id != 0)
            {
                view.RemoveNoData(defectsBindingSource); // Hapus baris "No Data" 
                defectList = defectRepository.GetFilter(id);
                // Periksa apakah defectList kosong
                if (defectList.Count() == 0)
                {
                    showNoData = true;
                    view.AddNoData();
                }
                else
                {
                    showNoData = false;
                    view.RemoveNoData(defectsBindingSource);
                }
            }
            else
            {
                defectList = defectRepository.GetAll();
            }

            // Atur sumber data untuk defectsBindingSource
            defectsBindingSource.DataSource = defectList;

        }

        private void ClearAction(object sender, EventArgs e)
        {
            view.BackColorStatus = Color.Orange;
            view.StatusText = "No Data";
            view.SerialNumber = "";
            view.ModelNumber = "";
            view.ModelCode = "";
        }

        private void LoadAllDefectList()
        {
            defectList = defectRepository.GetAll();
            defectsBindingSource.DataSource = defectList;
        }

        public delegate void TopDefectEventHandler(object sender, EventArgs e, int id);
        private void SearchModelNumber(object sender, ModelEventArgs e)
        {
            var model = new ModelCode
            {
                modelCode1 = view.ModelCode
            };

            var searchModel = modelNumberRepository.GetModelNumber(model);

            if (searchModel != null)
            {
                view.ModelNumber = searchModel.ModelNumber;
            }
            else
            {
                view.ModelNumber = "";
            }
        }

        public void UnassociateViewEvents()
        {
            view.SearchModelNumber -= SearchModelNumber;
            view.CheckProperties -= CheckProperties;
            view.SearchFilter -= SearchFilter;
        }

        public void ResetDataBinding()
        {
            //defectsBindingSource.DataSource = null;
            defectsBindingSource2.DataSource = null;
            view.SetDefectListBindingSource2(null);

            ClearViewFields();
            LoadAllResultDefect();
        }

        public void ClearViewFields()
        {
            view.SerialNumber = "";
            view.ModelCode = "";
            view.ModelNumber = "";
            view.StatusText = "";
        }
    }
}
