using System.Windows;
using System.Windows.Input;
using System.Windows.Controls.Primitives;
using System.Collections.Generic;
using agkik.desktopclient.viewmodels.demo;
using System.Windows.Data;
using System.Collections;

namespace agkik.desktopclient.views.popups
{
    /// <summary>
    /// Interaction logic for SubCategoryPopop.xaml
    /// </summary>
    public partial class SubCategoryPopop : Window
    {
        public SubCategoryPopop()
        {
            InitializeComponent();
        }
        public SubCategoryPopop(string categoryName, string categoryDescription, IEnumerable mainCategoryList)
            : this()
        {
            if (string.IsNullOrWhiteSpace(categoryName))
            {
                txtCategoryName.Text = string.Empty;
                txtCategoryDescription.Text = string.Empty;
            }
            else
            {
                lblHeader.Content = "Edit Sub Category";
                txtCategoryName.Text = categoryName;
                txtCategoryDescription.Text = categoryDescription;
            }
            cboMainCategory.ItemsSource = mainCategoryList;
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
    }
}
