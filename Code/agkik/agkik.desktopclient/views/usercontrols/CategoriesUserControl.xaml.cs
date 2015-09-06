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
using agkik.desktopclient.views.popups;
using agkik.desktopclient.viewmodels.demo;

namespace agkik.desktopclient.views.usercontrols
{
    /// <summary>
    /// Interaction logic for CategoriesUserControl.xaml
    /// </summary>
    public partial class CategoriesUserControl : UserControl
    {
        //public static readonly DependencyProperty _headerName = DependencyProperty.Register("HeaderName", typeof(string), typeof(CategoriesUserControl));
        public static readonly DependencyProperty _isExpense =
       DependencyProperty.Register("IsExpense", typeof(bool), typeof(CategoriesUserControl));
        private string _headerName;
        //private bool _isExpense;

        public bool IsExpense
        {
            get { return (bool)GetValue(_isExpense); }
            set { SetValue(_isExpense, value); }
        }

        public string HeaderName
        {
            get { return this._headerName; }
            set { _headerName = value; }
        }
        public CategoriesUserControl()
        {
            InitializeComponent();
        }

        private void UserControl_Initialized(object sender, EventArgs e)
        {
            
        }
        private void btnAddMainCategory_Click(object sender, RoutedEventArgs e)
        {
            MainCategoryPopup addPopup = new MainCategoryPopup();
            addPopup.ShowDialog();
        }

        private void btnEditMainCategory_Click(object sender, RoutedEventArgs e)
        {
            DemoMainCategory selectedCategory = (DemoMainCategory)lvMainCategories.SelectedItem;
            if (selectedCategory != null)
            {
                MainCategoryPopup addPopup = new MainCategoryPopup(selectedCategory.Name, selectedCategory.Description);
                addPopup.ShowDialog();
            }
        }

        private void btnAddSubCategory_Click(object sender, RoutedEventArgs e)
        {
            SubCategoryPopup addPopup;
            if (IsExpense)
            {
                DemoExpsenseCategoryVM vm = (DemoExpsenseCategoryVM)this.DataContext;
                addPopup = new SubCategoryPopup(lvMainCategories.ItemsSource, IsExpense, vm.ExpenseTypes);
            }
            else
            {
                addPopup = new SubCategoryPopup(lvMainCategories.ItemsSource);
            }
            addPopup.ShowDialog();
        }

        private void btnEditSubCategory_Click(object sender, RoutedEventArgs e)
        {
            DemoSubCategory selectedCategory = (DemoSubCategory)lvSubCategories.SelectedItem;
            if (selectedCategory != null)
            {
                SubCategoryPopup editPopup;
                if (IsExpense)
                {
                    DemoExpsenseCategoryVM vm = (DemoExpsenseCategoryVM)this.DataContext;
                    editPopup = new SubCategoryPopup(lvMainCategories.ItemsSource, selectedCategory, IsExpense, vm.ExpenseTypes);
                }
                else
                {
                    editPopup = new SubCategoryPopup(lvMainCategories.ItemsSource, selectedCategory);
                }
                editPopup.ShowDialog();
            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            lblHeader.Content = this._headerName;
            
            // main category
            /*
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(lvMainCategories.ItemsSource);
            PropertyGroupDescription groupDescription = new PropertyGroupDescription("CategoryType");
            view.GroupDescriptions.Add(groupDescription);
            
            // sub category
            CollectionView subView = (CollectionView)CollectionViewSource.GetDefaultView(lvSubCategories.ItemsSource);
            PropertyGroupDescription usbGroupDescription = new PropertyGroupDescription("ParentCategory");
            subView.GroupDescriptions.Add(usbGroupDescription);
            */
        }
    }

    
}