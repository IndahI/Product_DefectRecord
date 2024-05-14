using Product_DefectRecord.Models;
using Product_DefectRecord.Views;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Product_DefectRecord.Presenters
{
    public class DefectListPresenter
    {
        //fields
        private IDefectListView view;
        private IDefectRepository defectRepository;
        private IModelNumberRepository modelNumberRepository;
        private BindingSource defectsBindingSource;
        private IEnumerable<DefectModel> defectList;
        private SaveModel _smodel;
        private bool showNoData = false;

        public DefectListPresenter(DefectListDataPresenter data)
        {
            this.view = data.View;
            this.defectRepository = data.DefectRepository;
            this.modelNumberRepository = data.ModelNumberRepository;
            this.view.InspectorId = data.User.Nik;
            this.view.Inspector = data.User.Name;
            this.view.SearchModelNumber += SearchModelNumber;
            this.view.ClearEvent += ClearAction;
            this.view.DefectFilterEvent += LoadFilterDefect;
            this.view.EditButtonClicked += EditButtonClicked;
            this.view.CellClicked += CellClicked;

            _smodel = new SaveModel();
            defectsBindingSource = new BindingSource();
            this.view.SetDefectListBindingSource(defectsBindingSource);
            LoadAllDefectList();
            this.view.Show();
        }

        private void CellClicked(object sender, EventArgs e)
        {
            int Location = _smodel.LoadId();
            var defect = (DefectModel)defectsBindingSource.Current;
            var detailDefect = new
            {
                SerialNumber = "12345678",
                ModelNumber = "NA-W123JJI34",
                ModelCode = "3D",
                //SerialNumber = view.SerialNumber,
                //ModelNumber = view.ModelNumber,
                //ModelCode = view.ModelCode,
                DefectId = defect.Id1,
                DefectName = defect.DefectName1,
                InspectorId = view.InspectorId,
                Inspector = view.Inspector,
                Location = Location
            };

            new DetailDefectPresenter(DetailDefectView.GetInstance(), defectRepository, detailDefect);
        }

        private void EditButtonClicked(object sender, EventArgs e)
        {
            new EditDefectPresenter(new EditDefectView(), defectRepository, (DefectModel)defectsBindingSource.Current);
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
            //string message = e.Message;
            //var searchModel = repository2.GetModelNumber(ModelCode);

            var model = new ModelCode
            {
                modelCode1 = view.ModelCode
            };

            var searchModel = modelNumberRepository.GetModelNumber(model);

            if (searchModel != null)
            {
                view.ModelNumber = searchModel.ModelNumber;
                Console.WriteLine("Value of modelnumber: " + view.ModelNumber);
            }
        }

    }
}
