using Product_DefectRecord._Repositories;
using Product_DefectRecord.Models;
using Product_DefectRecord.Views;
using System;
using System.Configuration;

namespace Product_DefectRecord.Presenters
{
    public class LoginPresenter
    {
        private readonly ILoginView _view;
        private readonly ILoginRepository _userRepository;

        public LoginPresenter(ILoginView view, ILoginRepository userRepository)
        {
            _view = view;
            _userRepository = userRepository;
            _view.Login += Login;
        }

        private void Login(object sender, EventArgs e)
        {
            string nik = _view.Nik;
            string password = _view.Password;

            LoginModel user = _userRepository.GetUserByUsername(nik);

            if (user?.Nik != null && user?.Password == password)
            {
                string sqlConnectionString = ConfigurationManager.ConnectionStrings["LSBUDBConnection"].ConnectionString;
                IDefectListView defectListView = new DefectListView();
                IDefectRepository defectRepository = new DefectRepository(sqlConnectionString);
                IModelNumberRepository modelNumberRepository = new ModelNumberRepository(sqlConnectionString);
                // Membuat instance dari DefectListPresenterData
                DefectListDataPresenter presenterData = new DefectListDataPresenter(defectListView, defectRepository, modelNumberRepository, user);

                // Membuat instance dari DefectListPresenter menggunakan DefectListPresenterData
                DefectListPresenter presenter = new DefectListPresenter(presenterData);
                _view.HideView();
            }
            else
            {
                _view.ShowMessage("Invalid username or password");
            }
        }
    }
}
