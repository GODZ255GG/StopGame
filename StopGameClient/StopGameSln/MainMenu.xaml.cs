using StopGame.StopGameService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
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
    /// Lógica de interacción para MainMenu.xaml
    /// </summary>
    public partial class MainMenu : Window
    {
        private List<String> strings = new List<String>();

        public MainMenu()
        {
            InitializeComponent(); 
            CargeAllUsers();
        }

        public void CargeAllUsers()
        {
            StopGameService.UpdateProfileClient updateProfileClient = new StopGameService.UpdateProfileClient();
            try
            {
                strings = updateProfileClient.GetGlobalUser().ToList();
                lbxUsers.ItemsSource = strings;
            }
            catch (Exception ex)
            {

            }
        }

        private void imgConfiguration_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Configuration configuration = new Configuration();
            configuration.Show();
        }
    }
}
