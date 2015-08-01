using System.Windows;
using agkik.desktopclient.viewmodels;
using System.Windows.Input;
using System.Windows.Controls.Primitives;

namespace agkik.desktopclient.views
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Login : Window
    {
        LoginViewModel _loginViewModel;
        public Login()
        {
            InitializeComponent();
            _loginViewModel = (LoginViewModel)Application.Current.Resources["loginVM"];
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            _loginViewModel.getUser(txtPassword.Password);
            if (_loginViewModel.IsAuthenticated)
            {
                Container mainWindow = new Container();
                mainWindow.Show();
                this.Close();
            }
        }

        private void tbClose_click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                btnLogin.RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
            }
        }

        private void Canvas_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                DragMove();
        }
    }
}
