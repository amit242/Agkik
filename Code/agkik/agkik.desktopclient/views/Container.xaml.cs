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
using agkik.desktopclient.viewmodels;
using agkik.desktopclient.views.pages;
using System.Windows.Navigation;

namespace agkik.desktopclient.views
{
    /// <summary>
    /// Interaction logic for Container.xaml
    /// </summary>
    public partial class Container : Window
    {
        APInvoicePage _apInvoicePage;
        ARInvoicePage _arInvoicePage;
        LoginViewModel _loginViewModel;
        bool _IsAdminWindowOpened = false;
        private BankAccPage _bankAccPage;
        private VendorPage _vendorPage;
        private ClientPage _clientPage;
        private ExpenseCategoryPage _expenseCategoryPage;
        private IncomeCategoryPage _incomeCategoryPage;
        private NonInvoicedIncomeCategoryPage _nonInvoicedIncomeCategoryPage;
        private UserPage _userPage;

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

        private void buttonShowExpense_Checked(object sender, RoutedEventArgs e)
        {
            if (_apInvoicePage == null)
            {
                _apInvoicePage = new APInvoicePage();
            }
            //frmContent.NavigationService.RemoveBackEntry(
            frmContent.NavigationService.Navigate(_apInvoicePage);
        }

        private void buttonShowARInvoice_Checked(object sender, RoutedEventArgs e)
        {
            if (_arInvoicePage == null)
            {
                _arInvoicePage = new ARInvoicePage();
            }
            //frmContent.NavigationService.RemoveBackEntry(
            frmContent.NavigationService.Navigate(_arInvoicePage);
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

        private void menuExpenseCategory_Click(object sender, RoutedEventArgs e)
        {
            //if (_expenseCategoryPage == null)
            //{
                _expenseCategoryPage = new ExpenseCategoryPage();
            //}

            frmContent.NavigationService.Navigate(_expenseCategoryPage);
        }

        private void menuIncomeCategory_Click(object sender, RoutedEventArgs e)
        {
            //if (_incomeCategoryPage == null)
            //{
                _incomeCategoryPage = new IncomeCategoryPage();
            //}

            frmContent.NavigationService.Navigate(_incomeCategoryPage);
        }
        private void menuNonInvoiceIncomeCategory_Click(object sender, RoutedEventArgs e)
        {
            //if (_nonInvoicedIncomeCategoryPage == null)
            //{
                _nonInvoicedIncomeCategoryPage = new NonInvoicedIncomeCategoryPage();
            //}
            
            frmContent.NavigationService.Navigate(_nonInvoicedIncomeCategoryPage);
        }

        private void btnManageVendors_Checked(object sender, RoutedEventArgs e)
        {
            if (_vendorPage == null)
            {
                _vendorPage = new VendorPage();
            }
            //frmContent.NavigationService.RemoveBackEntry();
            frmContent.NavigationService.Navigate(_vendorPage);
        }

        private void btnManageClients_Checked(object sender, RoutedEventArgs e)
        {
            if (_clientPage == null)
            {
                _clientPage = new ClientPage();
            }
            //frmContent.NavigationService.RemoveBackEntry();
            frmContent.NavigationService.Navigate(_clientPage);
        }

        private void btnManageUsers_Checked(object sender, RoutedEventArgs e)
        {
            if (_userPage == null)
            {
                _userPage = new UserPage(false);
            }
            //frmContent.NavigationService.RemoveBackEntry();
            frmContent.NavigationService.Navigate(_userPage);
        }
    }
}
