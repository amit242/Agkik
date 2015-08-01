using System.Windows;
using System.Windows.Input;
using System.Windows.Controls.Primitives;

namespace agkik.desktopclient.views.popups
{
    /// <summary>
    /// Interaction logic for AddUpdateMainCategory.xaml
    /// </summary>
    public partial class MainCategoryPopup : Window
    {
        public MainCategoryPopup()
        {
            InitializeComponent();
        }
        public MainCategoryPopup(string categoryName, string categoryDescription) : this()
        {
            if (string.IsNullOrWhiteSpace(categoryName))
            {
                txtCategoryName.Text = string.Empty;
                txtCategoryDescription.Text = string.Empty;
            }
            else
            {
                lblHeader.Content = "Edit Main Category";
                txtCategoryName.Text = categoryName;
                txtCategoryDescription.Text = categoryDescription;
            }
        }

        private void btnDialogOk_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Canvas_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                DragMove();
        }
        /*
        private void Window_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                btnDialogOk.RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
            }
        }*/
    }
}
