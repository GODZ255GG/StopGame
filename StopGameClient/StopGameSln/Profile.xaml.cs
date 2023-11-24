using System;
using System.Drawing;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Windows.Interop;

namespace StopGame
{
    /// <summary>
    /// Lógica de interacción para Profile.xaml
    /// </summary>
    public partial class Profile : Window
    {
        public Profile()
        {
            InitializeComponent();
            ShowInformationUser();
        }

        private void ShowInformationUser()
        {
            tbUserName.Text = Domain.User.UserClient.UserName;
            tbEmail.Text = Domain.User.UserClient.Email;
            ShowImage();
        }

        private void ShowImage()
        {
            Bitmap getImage = (Bitmap)Properties.ResourceImage.ResourceManager.GetObject(Domain.User.UserClient.ProfileImage);

            BitmapSource loadImage = Imaging.CreateBitmapSourceFromHBitmap(
                    getImage.GetHbitmap(),
                    IntPtr.Zero,
                    Int32Rect.Empty,
                    BitmapSizeOptions.FromEmptyOptions()
                    );

            imgProfilePicture.Source = loadImage;
        }

        private void ImgReturn_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MainMenu menu = new MainMenu();
            menu.Show();
            this.Close();
        }

        private void ImgProfileEdit(object sender, MouseButtonEventArgs e)
        {
            EditUserProfile edit = new EditUserProfile();
            edit.Show();
            this.Close();
        }
    }
}
