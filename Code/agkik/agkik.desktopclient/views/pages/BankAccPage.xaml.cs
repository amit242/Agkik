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

        private void Page_Initialized(object sender, EventArgs e)
        {
            dgAccounts.ItemsSource = AccountManager.getAccounts();
        }

        private void dgAccounts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //dgAccounts.SelectedItem
        }
    }
}
