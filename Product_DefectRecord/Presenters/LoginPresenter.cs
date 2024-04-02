using Product_DefectRecord.Models;
using Product_DefectRecord.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            _view.Login += PerformLogin;
        }

        private void PerformLogin(object sender, EventArgs e)
        {
            string nik = _view.Nik;
            string password = _view.Password;

            LoginModel user = _userRepository.GetUserByUsername(nik);

            if (user.Nik != null && user.Password == password)
            {
                _view.ShowMessage("Login successful");
            }
            else
            {
                _view.ShowMessage("Invalid username or password");
            }
        }
    }
}
