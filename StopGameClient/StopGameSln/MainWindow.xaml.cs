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
        String username = "";
        String email = "";
        String password = "";
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            RegisterAction();
            MessageBox.Show("Usuario registrado correctamente", "Registro exitoso");
            tbUserName.Clear();
            tbEmail.Clear();
            pbPassword.Clear();        
        }

        private void RegisterAction()
        {
            username = tbUserName.Text;
            email = tbEmail.Text;
            password = pbPassword.Password;
            StopGameService.UserManagerClient client = new StopGameService.UserManagerClient();

            User user = new User()
            {
                UserName = username,
                Email = email,
                Password = password
            };
            client.Register(user);
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

        private void imgConfiguration_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Configuration configuration = new Configuration();
            configuration.Show();
        }
    }
}
