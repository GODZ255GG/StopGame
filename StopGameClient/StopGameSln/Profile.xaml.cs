using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
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
            ShowData();
            ImagenInit();
        }

        private void ShowData()
        {
            tbUserName.Text = Domain.User.UserClient.UserName;
            tbEmail.Text = Domain.User.UserClient.Email;
        }

        private void ImagenInit()
        {
            Bitmap bmp = (Bitmap)Properties.ResourceImage.ResourceManager.GetObject(Domain.User.UserClient.ProfileImage);

            BitmapSource bmpImage = Imaging.CreateBitmapSourceFromHBitmap(
                    bmp.GetHbitmap(),
                    IntPtr.Zero,
                    Int32Rect.Empty,
                    BitmapSizeOptions.FromEmptyOptions()
                    );

            imgProfilePicture.Source = bmpImage;
        }

        private void ImgReturn_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MainMenu menu = new MainMenu()
            {
                WindowState = this.WindowState,
                Left = this.Left
            };
            menu.Show();
            this.Close();
        }

        private void ImgProfileEdit(object sender, MouseButtonEventArgs e)
        {
            EditUserProfile edit = new EditUserProfile()
            {
                WindowState = this.WindowState,
                Left = this.Left
            };
            edit.Show();
            this.Close();
        }
    }
}
