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
using System.Windows.Navigation;
using System.Windows.Shapes;
using agkik.businesslogic;
using agkik.businesslogic.businessapi;

namespace agkik.desktopclient.views.pages
{
    /// <summary>
    /// Interaction logic for BankAccPage.xaml
    /// </summary>
    public partial class BankAccPage : Page
    {
        public BankAccPage()
        {
            InitializeComponent();
        }
        private List<account> AccountList;
        private void Page_Initialized(object sender, EventArgs e)
        {
            AccountList = AccountManager.GetAccounts();
            dgAccounts.ItemsSource = AccountList;
            newBankAccount.DataContext = new account();
            cboFromAccountNo.ItemsSource = AccountList;
            cboToAccountNo.ItemsSource = AccountList;
        }

        private void dgAccounts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            account ac = (account)dgAccounts.SelectedItem;
            
            selectedBankAccount.DataContext = ac;
            selectedDelBankAccount.DataContext = ac;
        }

        private void btnAddAccount_Click(object sender, RoutedEventArgs e)
        {
            account ac = (account)newBankAccount.DataContext;
            AccountManager.AddUpdateAccount(ac);
            
        }

        private void btnUpdateAccount_Click(object sender, RoutedEventArgs e)
        {
            AccountManager.AddUpdateAccount((account)selectedBankAccount.DataContext);
        }

        private void tiTransferFunds_Initialized(object sender, EventArgs e)
        {
            
        }

        private void btnTransfer_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
