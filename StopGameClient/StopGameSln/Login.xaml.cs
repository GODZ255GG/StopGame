using StopGame.StopGameService;
using System;
using System.ServiceModel;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;

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

        private void ImgReturn_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MainWindow main = new MainWindow();
            this.Close();
            main.Show();
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
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
                    }
                    catch (EndpointNotFoundException ex)
                    {
                        MessageBox.Show(Properties.Resources.noConnectionMessage, Properties.Resources.errorTile, MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    catch (CommunicationObjectFaultedException ex)
                    {
                        MessageBox.Show(Properties.Resources.noConnectionMessage, Properties.Resources.errorTile, MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    catch (TimeoutException ex)
                    {
                        MessageBox.Show(Properties.Resources.noConnectionMessage, Properties.Resources.errorTile, MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    finally
                    {
                        client.Abort();
                    }
                }
                else
                {
                    MessageBox.Show(Properties.Resources.invalidFormatMessage, Properties.Resources.warningTile, MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            else
            {
                MessageBox.Show(Properties.Resources.noUserOrPassword, Properties.Resources.warningTile, MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void LoginAction(string userName, string password)
        {
            var userLogin = client.Login(userName, password);
            if(userLogin != null)
            {
                if (userLogin.Status)
                {
                    Domain.User.UserClient = new Domain.User()
                    {
                        IdUser = userLogin.IdUser,
                        UserName = userLogin.UserName,
                        Email = userLogin.Email,
                        ProfileImage = userLogin.ProfileImage
                    };

                    MainMenu mainMenu = new MainMenu();
                    mainMenu.Show();
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show(Properties.Resources.cantLoginMessage, Properties.Resources.errorTile, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        #region Validation
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
            if (userName.Length <= 65 || password.Length <= 20)
            {
                isntTooLong = true;
            }
            return isntTooLong;
        }
        #endregion
    }
}
