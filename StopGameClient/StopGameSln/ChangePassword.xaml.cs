using System.Windows;

namespace StopGame
{
    /// <summary>
    /// Lógica de interacción para ChangePassword.xaml
    /// </summary>
    public partial class ChangePassword : Window
    {
        private int validationCode;
        private StopGameService.UserManagerClient client = new StopGameService.UserManagerClient();
        public ChangePassword()
        {
            InitializeComponent();
            tbToken.Visibility = Visibility.Hidden;
            lbToken.Visibility = Visibility.Hidden;
            btnConfirm.Visibility = Visibility.Hidden;
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            Profile profile = new Profile();
            profile.Show();
            this.Close();
        }
    }
}
