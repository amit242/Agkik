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

namespace agkik.desktopclient.views.usercontrols
{
    /// <summary>
    /// Interaction logic for BankAccountUserControl.xaml
    /// </summary>
    public partial class BankAccountUserControl : UserControl
    {
        public BankAccountUserControl()
        {
            InitializeComponent();
        }

        private void UserControl_Initialized(object sender, EventArgs e)
        {

            List<string> list = new List<string>();
            list.Add("Asset - Cash");
            list.Add("Asset - Bank Account");
            list.Add("Liability");
            cbAccountType.ItemsSource = list;

            

        }

        private void cbAccountType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbAccountType.SelectedIndex == 0)
            {
                Style style = Application.Current.FindResource("rowDefinition-hidden") as Style;
                accountGrid.RowDefinitions[3].Style = style;
                accountGrid.RowDefinitions[4].Style = style;
                accountGrid.RowDefinitions[5].Style = style;
            }
            else
            {
                Style style = Application.Current.FindResource("rowDefinition-normal") as Style;
                accountGrid.RowDefinitions[3].Style = style;
                accountGrid.RowDefinitions[4].Style = style;
                accountGrid.RowDefinitions[5].Style = style;
            }
        }

        private void validateTextboxLostFocus(object sender, RoutedEventArgs e)
        {
            if (sender is TextBox)
            {
                TextBox tb = (TextBox)sender;
                if (string.IsNullOrWhiteSpace(tb.Text))
                {
                    tb.Text = "abc";
                    tb.Text = string.Empty;
                }
            }
        }
    }
}
