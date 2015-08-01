using System.Windows.Controls;
using System.Windows.Input;
using agkik.desktopclient.Utils;


namespace agkik.desktopclient.views.pages
{
    /// <summary>
    /// Interaction logic for ClientPage.xaml
    /// </summary>
    public partial class ClientPage : Page
    {
        public ClientPage()
        {
            InitializeComponent();
        }

        private void tiAddClient_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter && !BasicUtils.IsParentComboBox(Keyboard.FocusedElement))
            {
                //btnAddVendor.Focus();
            }
        }
    }
}
