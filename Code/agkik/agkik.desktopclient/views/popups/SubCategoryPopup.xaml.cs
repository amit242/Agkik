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
    public partial class SubCategoryPopup : Window
    {
        private bool _isExpense;
        private List<ExpenseType> _expenselist;
        private IEnumerable _mainCategoryList;
        private DemoSubCategory _selectedCategory;
        public SubCategoryPopup()
        {
            InitializeComponent();
        }

        //public SubCategoryPopup(bool isExpense)
        //    : this()
        //{
        //    this._isExpense = isExpense;
        //}

        //public SubCategoryPopup(bool _isExpense, List<ExpenseType> list)
        //    : this(_isExpense)
        //{
        //    this._expenselist = list;
        //}
        public SubCategoryPopup(IEnumerable mainCategoryList) : this()
        {
            cboMainCategory.ItemsSource = mainCategoryList;
            cboMainCategory.SelectedIndex = -1;
        }

        public SubCategoryPopup(IEnumerable mainCategoryList, bool isExpense, List<ExpenseType> list): this(mainCategoryList)
        {
            this._isExpense = isExpense;
            this._expenselist = list;
        }


        public SubCategoryPopup(IEnumerable mainCategoryList, DemoSubCategory selectedCategory)
            : this(mainCategoryList)
        {
            if (string.IsNullOrWhiteSpace(selectedCategory.Name))
            {
                txtCategoryName.Text = string.Empty;
                txtCategoryDescription.Text = string.Empty;
            }
            else
            {
                lblHeader.Content = "Edit Sub Category";
                txtCategoryName.Text = selectedCategory.Name;
                txtCategoryDescription.Text = selectedCategory.Description;
            }
            cboMainCategory.SelectedItem = selectedCategory.ParentCategory;
            this._selectedCategory = selectedCategory;
        }
        public SubCategoryPopup(IEnumerable mainCategoryList, DemoSubCategory selectedCategory, bool _isExpense, List<ExpenseType> list)
            : this(mainCategoryList, selectedCategory)
        {
            this._isExpense = _isExpense;
            this._expenselist = list;
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

        private void Canvas_Loaded(object sender, RoutedEventArgs e)
        {
            if (_isExpense)
            {
                lblExpenseType.Visibility = Visibility.Visible;
                cboExpenseType.Visibility = Visibility.Visible;
                cboExpenseType.ItemsSource = _expenselist;
                cboExpenseType.SelectedItem = ((DemoSubCategoryExpense)_selectedCategory).ExpenseType;
            }
        }
    }
}
