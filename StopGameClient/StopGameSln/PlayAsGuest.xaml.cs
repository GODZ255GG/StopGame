using System.Windows;
using System.Windows.Input;

namespace StopGame
{
    /// <summary>
    /// Lógica de interacción para PlayAsGuest.xaml
    /// </summary>
    public partial class PlayAsGuest : Window
    {
        public PlayAsGuest()
        {
            InitializeComponent();
        }

        private void ImgReturn_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MainWindow menu = new MainWindow();
            menu.Show();
            this.Close();
        }
    }
}
