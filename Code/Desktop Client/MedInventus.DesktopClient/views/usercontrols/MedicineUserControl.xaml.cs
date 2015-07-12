using System.Windows.Input;
using System.Windows.Controls;
using agkik.desktopclient.Utils;

namespace agkik.desktopclient.views.usercontrols
{
    /// <summary>
    /// Interaction logic for Medicine.xaml
    /// </summary>
    public partial class MedicineUserControl : UserControl
    {
        public MedicineUserControl()
        {
            InitializeComponent();
        }

        private void DisableNonNumericValue(object sender, TextCompositionEventArgs e)
        {
            BasicUtils.DisableNonNumericValue(e);
        }
    }
}
