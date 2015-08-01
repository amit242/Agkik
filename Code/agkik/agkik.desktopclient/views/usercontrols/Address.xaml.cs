using System.Windows.Controls;
using agkik.desktopclient.Utils;

namespace agkik.desktopclient.views.usercontrols
{
    /// <summary>
    /// Interaction logic for Address.xaml
    /// </summary>
    public partial class Address : UserControl
    {
        //private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        //private AddressViewModel _addressVM;
        public Address()
        {
            InitializeComponent();
        }

        private void txtZip_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            BasicUtils.DisableNonNumericValue(e);
        }
    }
}
