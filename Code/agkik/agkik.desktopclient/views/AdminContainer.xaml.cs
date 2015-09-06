using System.Windows;
using agkik.desktopclient.views.pages;
using System.Windows.Navigation;

namespace agkik.desktopclient.views
{
    /// <summary>
    /// Interaction logic for AdminContainer.xaml
    /// </summary>
    public partial class AdminContainer : Window
    {
        private BankAccPage _bankAccPage;
        private ExpenseCategoryPage _expenseCategoryPage;
        private IncomeCategoryPage _incomeCategoryPage;
        private VendorPage _vendorPage;
        private ClientPage _clientPage;
        private UserPage _userPage;

        public AdminContainer()
        {
            InitializeComponent();
            frmContent.NavigationUIVisibility = NavigationUIVisibility.Hidden;
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
                _userPage = new UserPage(true);
            }
            //frmContent.NavigationService.RemoveBackEntry();
            frmContent.NavigationService.Navigate(_userPage);
        }
    }
}
