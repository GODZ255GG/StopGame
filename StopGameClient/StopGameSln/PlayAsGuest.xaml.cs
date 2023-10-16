using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    /// Lógica de interacción para PlayAsGuest.xaml
    /// </summary>
    public partial class PlayAsGuest : Window
    {
        public PlayAsGuest()
        {
            InitializeComponent();
        }

        private void imgReturn_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MainWindow main = new MainWindow();
            this.Close();
            main.Show();
        }

        private void imgConfiguration_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Configuration configuration = new Configuration();
            configuration.Show();
        }
    }
}
