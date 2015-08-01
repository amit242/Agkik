using agkik.businesslogic.models;
using agkik.businesslogic.Common;
using agkik.desktopclient.Command;
using agkik.businesslogic.businessapi;
using log4net;
using System.Reflection;

namespace agkik.desktopclient.viewmodels
{
    internal class LoginViewModel : ViewModelBase
    {
        #region Private Fields
        private bool _IsAuthenticated;
        private User _CurrentUser;
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        #endregion

        #region Public Properties
        public bool IsAuthenticated
        {
            get { return _IsAuthenticated; }
            set
            {
                if (value != _IsAuthenticated)
                {
                    _IsAuthenticated = value;
                    RaisePropertyChangedEvent("IsAuthenticated");
                }
            }
        }
        public bool IsAdmin
        {
            get { return CurrentUser.UserRole == Role.Admin; }
        }
        public User CurrentUser
        {
            get { return _CurrentUser; }
            set
            {
                if (value != _CurrentUser)
                {
                    _CurrentUser = value;
                    RaisePropertyChangedEvent("CurrentUser");
                }
            }
        }
        #endregion

        #region Constructor
        public LoginViewModel()
        {
            CurrentUser = new User { UserName = "", Password = "" };
        }
        #endregion

        #region Public Method
        public void getUser(string password)
        {
            IsAuthenticated = false;
            IsMessageVisible = true;
            if (!string.IsNullOrWhiteSpace(CurrentUser.UserName) && !string.IsNullOrWhiteSpace(password))
            {
                User usr = UserManager.getUserByUserName(CurrentUser.UserName);
                if (usr.HasError)
                {
                    DisplayMessage = usr.ErrorMessage;
                }
                else if (usr != null && usr.Password == password) // TODO: implement public key encryption for password verification
                {
                    IsAuthenticated = true;
                    CurrentUser = usr;
                    log.Debug(string.Format("[{0}] has successfully logged in!", usr.UserName));
                    IsMessageVisible = false;
                }
                else
                {
                    DisplayMessage = "Invalid username/password!";
                }
            }
            else
            {
                DisplayMessage = "Please enter username/password!";
            }
        }
        public void LogOff()
        {
            IsAuthenticated = false;
        }
        #endregion

        #region Private Method
       
        #endregion
    }
}
