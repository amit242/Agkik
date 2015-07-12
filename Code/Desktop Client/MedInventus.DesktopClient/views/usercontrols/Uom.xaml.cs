using System.Windows;
using System.Windows.Controls;
using agkik.desktopclient.Utils;

namespace agkik.desktopclient.views.usercontrols
{
    /// <summary>
    /// Interaction logic for Uom.xaml
    /// </summary>
    public partial class Uom : UserControl
    {
        bool _isEditable = false;

        public bool IsEditable
        {
            get { return _isEditable; }
            set 
            {
                _isEditable = value;
                tbMedDetails.Visibility = _isEditable ? Visibility.Visible : Visibility.Collapsed;
                cboUOM.IsEditable = _isEditable;
                tbSelectOrType.Text = _isEditable ? "-- Select or Type --" : "----- Select -----";
                txtPieces.IsEnabled = _isEditable;
                btnUpdateUOM.Visibility = _isEditable ? Visibility.Visible : Visibility.Collapsed;
                btnAddOM.Visibility = _isEditable ? Visibility.Visible : Visibility.Collapsed;
            }
        }
        public Uom()
        {
            InitializeComponent();
        }

        private void DisableNonNumericValue(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            BasicUtils.DisableNonNumericValue(e);
        }
    }
}
