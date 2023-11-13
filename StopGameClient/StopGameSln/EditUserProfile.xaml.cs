using System;
using System.Drawing;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.ServiceModel;

namespace StopGame
{
    /// <summary>
    /// Lógica de interacción para EditUserProfile.xaml
    /// </summary>
    public partial class EditUserProfile : Window
    {

        String imgResource = "";
        StopGameService.UpdateProfileClient updateProfileClient = new StopGameService.UpdateProfileClient();
        
        public EditUserProfile()
        {
            InitializeComponent();
            ShowData();
            ReadResource();
            ImageInit();
        }

        private void ShowData()
        {
            tbUserName.Text = Domain.User.UserClient.UserName;
        }

        private void ReadResource()
        {
            lbxImageSelector.Items.Add("Bigotes");
            lbxImageSelector.Items.Add("Cheems");
            lbxImageSelector.Items.Add("Kawaii");
            lbxImageSelector.Items.Add("Mariposa");
        }

        private void ImageInit()
        {
            Bitmap bmp = (Bitmap)Properties.ResourceImage.ResourceManager.GetObject(Domain.User.UserClient.ProfileImage);

            BitmapSource bmpImage = Imaging.CreateBitmapSourceFromHBitmap(
                bmp.GetHbitmap(),
                IntPtr.Zero,
                Int32Rect.Empty,
                BitmapSizeOptions.FromEmptyOptions()
                );

            imgProfile.Source = bmpImage;
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Domain.User.UserClient.ProfileImage = imgResource;
                updateProfileClient.SaveImage(imgResource, Domain.User.UserClient.IdUser);
                if (!String.IsNullOrWhiteSpace(tbUserName.Text))
                {
                    if (!ExistsInvalidFields())
                    {
                        updateProfileClient.UpdateNewUserName(tbUserName.Text, Domain.User.UserClient.UserName);
                        Domain.User.UserClient.UserName = tbUserName.Text;
                    }
                }
            }
            catch (EndpointNotFoundException ex)
            {

            }
            finally
            {
                updateProfileClient.Abort();
            }

            Profile profile = new Profile()
            {
                WindowState = this.WindowState,
                Left = this.Left
            };
            profile.Show();
            this.Close();
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            Profile profile = new Profile()
            {
                WindowState = this.WindowState,
                Left = this.Left
            };
            profile.Show();
            this.Close();
        }

        private void ImageSelector(object sender, SelectionChangedEventArgs e)
        {
            if(lbxImageSelector.SelectedItem != null)
            {
                Bitmap bmp = (Bitmap)Properties.ResourceImage.ResourceManager.GetObject(lbxImageSelector.SelectedItem.ToString());

                BitmapSource bmpImages = Imaging.CreateBitmapSourceFromHBitmap(
                    bmp.GetHbitmap(),
                    IntPtr.Zero,
                    Int32Rect.Empty,
                    BitmapSizeOptions.FromEmptyOptions()
                    );

                imgProfile.Source = bmpImages;
                imgResource = lbxImageSelector.SelectedItem.ToString();
            }
        }

        #region Validation
        private Boolean ExistsInvalidFields()
        {
            Boolean invalidFields = false;
            if(ExistsEmptyFields() || ExistsExcessLength())
            {
                invalidFields = true;
            }
            return invalidFields;
        }

        private Boolean ExistsEmptyFields()
        {
            Boolean emptyFields = false;
            if (String.IsNullOrWhiteSpace(tbUserName.Text))
            {
                emptyFields = true;
                MessageBox.Show("No se pudo ta vacio", "xd");
            }
            return emptyFields;
        }

        private Boolean ExistsExcessLength()
        {
            Boolean excessLength = false;
            if(tbUserName.Text.Length > 45)
            {
                excessLength = true;
                MessageBox.Show("No se pudo ta largo", "xd");
            }
            return excessLength;
        }
        #endregion
    }
}
