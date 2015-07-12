using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using agkik.desktopclient.ViewModels;
using agkik.desktopclient.views.pages;
using System.Windows.Navigation;

namespace agkik.desktopclient.views
{
    /// <summary>
    /// Interaction logic for Container.xaml
    /// </summary>
    public partial class Container : Window
    {
        InvoicePage _invoicePage;
        LoginViewModel _loginViewModel;
        bool _IsAdminWindowOpened = false;
        private BankAccPage _bankAccPage;
        public Container()
        {
            InitializeComponent();
            _loginViewModel = (LoginViewModel)Application.Current.Resources["loginVM"];
            frmContent.NavigationUIVisibility = NavigationUIVisibility.Hidden;
        }

        private void btnManage_Click(object sender, RoutedEventArgs e)
        {
            AdminContainer _AdminWindow;
            if (!_IsAdminWindowOpened)
            {
                _AdminWindow = new AdminContainer();
                _AdminWindow.Owner = this;
                _AdminWindow.Show();
                
                _AdminWindow.Focus();
                _AdminWindow.Closed += new EventHandler(AdminWindow_Closed);
                _IsAdminWindowOpened = true;
            }
            
        }

        private void AdminWindow_Closed(object sender, EventArgs e)
        {
            _IsAdminWindowOpened = false;
        }
          

        private void buttonLogout_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBoxResult = MessageBox.Show("Are you sure to logout?", "Confirmation!", MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                _loginViewModel.IsAuthenticated = false;
                Login login = new Login();
                login.Show();
                this.Close();
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
           // TODO: handle unsaved data
        }

        private void buttonShowInvoice_Checked(object sender, RoutedEventArgs e)
        {
            if (_invoicePage == null)
            {
                _invoicePage = new InvoicePage();
            }
            //frmContent.NavigationService.RemoveBackEntry(
            frmContent.NavigationService.Navigate(_invoicePage);
        }

        private void btnManageBankAccount_Checked(object sender, RoutedEventArgs e)
        {
            if (_bankAccPage == null)
            {
                _bankAccPage = new BankAccPage();
            }
            //frmContent.NavigationService.RemoveBackEntry();
            frmContent.NavigationService.Navigate(_bankAccPage);
        }
    }
}
