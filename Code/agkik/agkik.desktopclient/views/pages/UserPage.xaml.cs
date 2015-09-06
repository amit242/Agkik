using System;
using System.Windows;
using System.Windows.Controls;

namespace agkik.desktopclient.views.pages
{
    /// <summary>
    /// Interaction logic for UserPage.xaml
    /// </summary>
    public partial class UserPage : Page
    {
        public UserPage()
        {
            InitializeComponent();
        }

        public UserPage(bool isAdmin) : this()
        {
            this._isAdmin = isAdmin;
        }

        private bool _isAdmin;

        public bool IsAdmin
        {
            get { return _isAdmin; }
        }

        private void Page_Initialized(object sender, EventArgs e)
        {
            
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            if (!IsAdmin)
            {
                dgUsers.Visibility = Visibility.Collapsed;
                lblHeader.Content = "Manage Profile";
                tiAddUser.Visibility = Visibility.Collapsed;
                sp.Visibility = Visibility.Collapsed;
                tiShowUsers.IsSelected = true;
                tiShowUsers.Header = "View/Update Profile";
                btnUpdateUser.Content = "Update Profile";
                brdExistingPassword.Visibility = Visibility.Visible;
            }
        }
    }
}
