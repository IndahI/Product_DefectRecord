using Product_DefectRecord._Repositories;
using Product_DefectRecord.Models;
using Product_DefectRecord.Presenters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Product_DefectRecord.Views
{
    public partial class LoginView : Form, ILoginView
    {
        public LoginView()
        {
            InitializeComponent();
            AssociateAndRaiseViewEvents();
        }

        private void AssociateAndRaiseViewEvents()
        {
            btnLogin.Click += delegate
            {
                string sqlConnectionString = ConfigurationManager.ConnectionStrings["LSBUDBConnection"].ConnectionString;
                IDefectListView view = new DefectListView();
                IDefectRepository defectRepository = new DefectRepository(sqlConnectionString);
                IModelNumberRepository modelNumberRepository = new ModelNumberRepository(sqlConnectionString);
                DefectListPresenter defectListPresenter = new DefectListPresenter(view, defectRepository, modelNumberRepository);
                (view as DefectListView).Show();
            };
        }

        public string Nik => throw new NotImplementedException(); 

        public string Password => throw new NotImplementedException();

        public bool IsLoginSuccessful { get; private set; }

        public event EventHandler Login;

        public void ShowMessage(string message)
        {
            throw new NotImplementedException();
        }
    }
}
