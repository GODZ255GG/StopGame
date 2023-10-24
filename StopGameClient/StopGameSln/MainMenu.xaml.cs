using Domain;
using StopGame.StopGameService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Contexts;
using System.ServiceModel;
using System.ServiceModel.Security;
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
    public partial class MainMenu : Window, StopGameService.IGameServicesCallback
    {
        private List<String> strings = new List<String>();
        private InstanceContext context;
        private StopGameService.GameServicesClient users;
        public MainMenu()
        {
            InitializeComponent();
            context = new InstanceContext(this);
            users = new GameServicesClient(context);
            AddPlayerToList();
        }

        public void AddPlayerToList()
        {
            users.Connect(Domain.User.UserClient.UserName);
            lbUserName.Content = Domain.User.UserClient.UserName;
        }

        public void UpdateUsersList(string[] users)
        {
            lbxUsers.ItemsSource = users;
        }

        private void imgConfiguration_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Configuration configuration = new Configuration();
            configuration.Show();
        }
    }
}
