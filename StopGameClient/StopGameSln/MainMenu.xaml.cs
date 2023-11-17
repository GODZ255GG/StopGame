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
            lbUserName.Content = Domain.User.UserClient.UserName;
            ImageInit();
        }

        private void ImageInit()
        {
            var userImage = Domain.User.UserClient.ProfileImage;
            if(userImage == "" || userImage == null)
            {
                Domain.User.UserClient.ProfileImage = "Bigotes";
            }
            Bitmap bmp = (Bitmap)Properties.ResourceImage.ResourceManager.GetObject(Domain.User.UserClient.ProfileImage);

            BitmapSource bmpImage = Imaging.CreateBitmapSourceFromHBitmap(
                    bmp.GetHbitmap(),
                    IntPtr.Zero,
                    Int32Rect.Empty,
                    BitmapSizeOptions.FromEmptyOptions()
                    );

            imgProfilePicture.Source = bmpImage;
        }

        private void ImgConfiguration_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Configuration configuration = new Configuration();
            configuration.Show();
            this.Close();
        }

        private void ImgProfilePicture_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Profile profile = new Profile();
            profile.Show();
            this.Close();
        }
    }
}
