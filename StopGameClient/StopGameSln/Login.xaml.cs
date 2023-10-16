using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace StopGame
{
    /// <summary>
    /// Lógica de interacción para Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        StopGameService.UserManagerClient client = new StopGameService.UserManagerClient();
        public Login()
        {
            InitializeComponent();
        }

        private void imgReturn_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MainWindow main = new MainWindow();
            this.Close();
            main.Show();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            var userName = tbUserName.Text;
            var password = pbPassword.Password;
            if (!String.IsNullOrWhiteSpace(userName) && !String.IsNullOrWhiteSpace(password))
            {
                if (AreValidStrings(userName, password) && AreTooLongStrings(userName, password))
                {
                    try
                    {
                        LoginAction(userName, password);
                        MessageBox.Show("Bienvenido "+userName, "Inicio de sesión exitoso");
                    }
                    catch (EndpointNotFoundException ex)
                    {

                    }
                }
                else
                {

                }
            }
        }

        private void LoginAction(string userName, string password)
        {
            var userLogin = client.Login(userName, password);
            if(userLogin != null)
            {
                Domain.User.UserClient = new Domain.User()
                {
                    IdUser = userLogin.IdUser,
                    UserName= userLogin.UserName,
                    Email= userLogin.Email
                };

                MainMenu mainMenu = new MainMenu()
                {
                    WindowState = this.WindowState,
                    Left = this.Left
                };
                mainMenu.Show();
                this.Close();
            }
            else
            {
                //MessageBox.Show(Properties.Resources);
            }
        }

        private bool AreValidStrings(string userName, string password)
        {
            var isValid = false;
            if (Regex.IsMatch(userName, "^[a-zA-Z0-9]*$") && Regex.IsMatch(password, "^[a-zA-Z0-9]*$"))
            {
                isValid = true;
            }
            return isValid;
        }

        private bool AreTooLongStrings(string userName, string password)
        {
            var isntTooLong = false;
            if (userName.Length <= 45 || password.Length <= 16)
            {
                isntTooLong = true;
            }
            return isntTooLong;
        }

        private void imgConfiguration_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Configuration configuration = new Configuration();
            configuration.Show();
        }
    }
}
