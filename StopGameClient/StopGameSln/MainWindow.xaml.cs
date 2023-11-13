using StopGame.StopGameService;
using System;
using System.Windows;
using System.Windows.Input;

namespace StopGame
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        String userName = "";
        String email = "";
        String password = "";
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            RegisterAction();
            tbUserName.Clear();
            tbEmail.Clear();
            pbPassword.Clear();        
        }

        private void RegisterAction()
        {
            userName = tbUserName.Text;
            email = tbEmail.Text;
            password = pbPassword.Password;
            StopGameService.UserManagerClient client = new StopGameService.UserManagerClient();

            User user = new User()
            {
                UserName = userName,
                Email = email,
                Password = password,
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
                VerifyEmail verifyEmail = new VerifyEmail()
                {
                    Left = this.Left
                };
                verifyEmail.ValidationCode = validationCode;
                var resultCode = (bool)verifyEmail.ShowDialog();
                var aux = client.Register(user);
                if(aux && resultCode)
                {
                    MessageBox.Show("Usuario registrado correctamente", "Registro exitoso");
                    client.Abort();
                    Login login = new Login()
                    {
                        WindowState = this.WindowState,
                        Left = this.Left
                    };
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

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            Login signIn = new Login();
            this.Close();
            signIn.Show();
        }

        private void btnPlayAsGuest_Click(object sender, RoutedEventArgs e)
        {
            PlayAsGuest guest = new PlayAsGuest();
            this.Close();
            guest.Show();
        }
    }
}
