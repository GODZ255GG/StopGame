using System;
using System.Drawing;
using System.Windows;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media.Imaging;

namespace StopGame
{
    /// <summary>
    /// Lógica de interacción para MainMenu.xaml
    /// </summary>
    public partial class MainMenu : Window
    {
        public MainMenu()
        {
            InitializeComponent();
            ShowInformationUser();
        }

        //En este meetodo l utilizo para poder mostrar la información del usuario que en este caso seria su nombre y su imagen de perfil
        //no  se vi violaria el estandar ya que tengo que un metodo solo debe de hacer una cosa y al llamar a otro metodo dentro de este no se si 
        //inflijiria el estandar.
        private void ShowInformationUser()
        {
            lbUserName.Content = Domain.User.UserClient.UserName;
            ShowImage();
        }

        private void ShowImage()
        {
            if(!Domain.User.UserClient.IsGuest)
            {
                var userImage = Domain.User.UserClient.ProfileImage;
                if (userImage == "" || userImage == null)
                {
                    Domain.User.UserClient.ProfileImage = "Bigotes";
                }
                Bitmap getImage = (Bitmap)Properties.ResourceImage.ResourceManager.GetObject(Domain.User.UserClient.ProfileImage);

                BitmapSource loadImage = Imaging.CreateBitmapSourceFromHBitmap(
                        getImage.GetHbitmap(),
                        IntPtr.Zero,
                        Int32Rect.Empty,
                        BitmapSizeOptions.FromEmptyOptions()
                        );

                imgProfilePicture.Source = loadImage;
            }
        }

        private void ImgConfiguration_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Configuration configuration = new Configuration();
            configuration.Show();
            this.Close();
        }

        private void ImgProfilePicture_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (!Domain.User.UserClient.IsGuest)
            {
                Profile profile = new Profile();
                profile.Show();
                this.Close();
            }
        }
    }
}
