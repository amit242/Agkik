using System.Windows.Controls;
using System.Windows.Input;
using agkik.desktopclient.Utils;

namespace agkik.desktopclient.views.pages
{
    /// <summary>
    /// Interaction logic for VendorPage.xaml
    /// </summary>
    public partial class VendorPage : Page
    {
        public VendorPage()
        {
            InitializeComponent();
        }

        private void tiAddVendor_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter && !BasicUtils.IsParentComboBox(Keyboard.FocusedElement))
            {
                //btnAddVendor.Focus();
            }
        }

        private void btnAddNewMedicine_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            
        }
    }
}
