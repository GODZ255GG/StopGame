using StopGame.StopGameService;
using System;
using System.ServiceModel;
using System.Windows;

namespace StopGame
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private String userName = "";
        private String email = "";
        private String password = "";
        public MainWindow()
        {
            InitializeComponent();
        }

        private void RegisterAction()
        {
            userName = tbUserName.Text;
            email = tbEmail.Text;
            password = pbPassword.Password;
            StopGameService.UserManagerClient client = new StopGameService.UserManagerClient();


            string passwordHash = Security.PasswordEncryptor.ComputeSHA512Hash(password);
            User newUser = new User()
            {
                UserName = userName,
                Email = email,
                Password = passwordHash,
                ProfileImage = ""
            };
            
            Random randomNumber = new Random();
            var validationCode = randomNumber.Next(100000, 1000000);

            var result = false;

            if (!client.ExistsEmailOrUserName(userName, email))
            {
                result = client.SendValidationEmail(email, "Validation Code", validationCode);
            }

            if(result)
            {
                VerifyEmail verifyEmail = new VerifyEmail
                {
                    ValidationCode = validationCode
                };
                var resultCode = (bool)verifyEmail.ShowDialog();
                var aux = client.Register(newUser);
                if(aux && resultCode)
                {
                    MessageBox.Show("Usuario registrado correctamente", "Registro exitoso");
                    client.Abort();
                    Login login = new Login();
                    login.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("No se pudo registrar al usuario", "Registro fallido");
                }
            }
            else
            {
                MessageBox.Show("No se puede registrar al usuario", "Registro fallido");
            }
            
        }

        private void BtnRegister_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                RegisterAction();
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
            tbUserName.Clear();
            tbEmail.Clear();
            pbPassword.Clear();
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            Login signIn = new Login();
            signIn.Show();
            this.Close();
        }

        private void BtnPlayAsGuest_Click(object sender, RoutedEventArgs e)
        {
            Domain.User.UserClient = new Domain.User()
            {
                UserName = $"Guest{new Random().Next()}",
                IsGuest = true
            };
            MainMenu menu = new MainMenu();
            menu.Show();
            this.Close();
        }
    }
}
