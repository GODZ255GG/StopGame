using System.Windows;
using System.Windows.Input;

namespace StopGame
{
    /// <summary>
    /// Lógica de interacción para Configuration.xaml
    /// </summary>
    public partial class Configuration : Window
    {
        public Configuration()
        {
            InitializeComponent();
        }

        private void BtnSpanish_Click(object sender, RoutedEventArgs e)
        {
            App.Current.SwitchLanguage("en");
            Configuration configuration = new Configuration();
            configuration.Activate();
            configuration.Show();
            this.Close();
        }

        private void BtnEnglish_Click(object sender, RoutedEventArgs e)
        {
            App.Current.SwitchLanguage("en-US");
            Configuration configuration = new Configuration();
            configuration.Activate();
            configuration.Show();
            this.Close();

        }

        private void BtnExitGame_Click(object sender, RoutedEventArgs e)
        {
            App.Current.Shutdown();
        }

        private void ImgProfilePicture_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MainMenu menu = new MainMenu();
            menu.Show();
            this.Close();
        }
    }
}
