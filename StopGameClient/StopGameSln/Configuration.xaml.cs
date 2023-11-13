using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
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
    /// Lógica de interacción para Configuration.xaml
    /// </summary>
    public partial class Configuration : Window
    {
        public Configuration()
        {
            InitializeComponent();
        }

        private void btnSpain_Click(object sender, RoutedEventArgs e)
        {
            App.Current.SwitchLanguage("en");
            Configuration configuration = new Configuration()
            {
                WindowState = this.WindowState,
                Left = this.Left
            };
            configuration.Activate();
            configuration.Show();
            this.Close();
        }

        private void btnEnglish_Click(object sender, RoutedEventArgs e)
        {
            App.Current.SwitchLanguage("en-US");
            Configuration configuration = new Configuration()
            {
                WindowState = this.WindowState,
                Left = this.Left
            };
            configuration.Activate();
            configuration.Show();
            this.Close();

        }

        private void btnExitGame_Click(object sender, RoutedEventArgs e)
        {
            App.Current.Shutdown();
        }

        private void ImgProfilePicture_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MainMenu menu = new MainMenu()
            {
                WindowState = this.WindowState,
                Left = this.Left
            };
            menu.Show();
            this.Close();
        }
    }
}
