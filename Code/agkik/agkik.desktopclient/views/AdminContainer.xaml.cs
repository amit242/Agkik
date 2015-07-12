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
using agkik.desktopclient.views.pages;

namespace agkik.desktopclient.views
{
    /// <summary>
    /// Interaction logic for AdminContainer.xaml
    /// </summary>
    public partial class AdminContainer : Window
    {
        VendorPage _vendorPage;
        InventoryPage _inventoryPage;
        public AdminContainer()
        {
            InitializeComponent();
        }

        private void btnVendor_Click(object sender, RoutedEventArgs e)
        {
            if (_vendorPage == null)
            {
                _vendorPage = new VendorPage();
            }
            frmContent.NavigationService.RemoveBackEntry();
            frmContent.NavigationService.Navigate(_vendorPage);
        }

        private void btnInventory_Click(object sender, RoutedEventArgs e)
        {
            if (_inventoryPage == null)
            {
                _inventoryPage = new InventoryPage();
            }
            frmContent.NavigationService.RemoveBackEntry();
            frmContent.NavigationService.Navigate(_inventoryPage);
            
        }
    }
}
