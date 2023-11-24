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

        private String imgResource = "";
        readonly StopGameService.UpdateProfileClient updateProfileClient = new StopGameService.UpdateProfileClient();
        
        public EditUserProfile()
        {
            InitializeComponent();
            ShowInformationUser();
            ReadResource();
        }

        //En este meetodo l utilizo para poder mostrar la información del usuario que en este caso seria su nombre y su imagen de perfil
        //no  se vi violaria el estandar ya que tengo que un metodo solo debe de hacer una cosa y al llamar a otro metodo dentro de este no se si 
        //inflijiria el estandar.
        private void ShowInformationUser()
        {
            tbUserName.Text = Domain.User.UserClient.UserName;
            ShowImage();
        }

        private void ReadResource()
        {
            lbxImageSelector.Items.Add("Bigotes");
            lbxImageSelector.Items.Add("Cheems");
            lbxImageSelector.Items.Add("Kawaii");
            lbxImageSelector.Items.Add("Mariposa");
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

            imgProfile.Source = loadImage;
        }

        private void BtnSaveChanges_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Domain.User.UserClient.ProfileImage = imgResource;
                updateProfileClient.SaveImage(imgResource, Domain.User.UserClient.IdUser);
                if (!String.IsNullOrWhiteSpace(tbUserName.Text) && !ExistsInvalidFields())
                {
                    updateProfileClient.UpdateNewUserName(tbUserName.Text, Domain.User.UserClient.UserName);
                    Domain.User.UserClient.UserName = tbUserName.Text;
                }
            }
            catch (EndpointNotFoundException ex)
            {
                MessageBox.Show(Properties.Resources.noConnectionMessage, Properties.Resources.errorTile, MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch(CommunicationObjectFaultedException ex)
            {
                MessageBox.Show(Properties.Resources.noConnectionMessage, Properties.Resources.errorTile, MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (TimeoutException ex)
            {
                MessageBox.Show(Properties.Resources.noConnectionMessage, Properties.Resources.errorTile, MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                updateProfileClient.Abort();
            }

            Profile profile = new Profile();
            profile.Show();
            this.Close();
        }

        private void BtnCancelChanges_Click(object sender, RoutedEventArgs e)
        {
            Profile profile = new Profile();
            profile.Show();
            this.Close();
        }

        private void ImageSelector(object sender, SelectionChangedEventArgs e)
        {
            if(lbxImageSelector.SelectedItem != null)
            {
                Bitmap getImage = (Bitmap)Properties.ResourceImage.ResourceManager.GetObject(lbxImageSelector.SelectedItem.ToString());

                BitmapSource loadImage = Imaging.CreateBitmapSourceFromHBitmap(
                    getImage.GetHbitmap(),
                    IntPtr.Zero,
                    Int32Rect.Empty,
                    BitmapSizeOptions.FromEmptyOptions()
                    );

                imgProfile.Source = loadImage;
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
                MessageBox.Show($"{Properties.Resources.emptyFieldsMessage}", $"{Properties.Resources.emptyFieldsTile}", MessageBoxButton.OK);
            }
            return emptyFields;
        }

        private Boolean ExistsExcessLength()
        {
            Boolean excessLength = false;
            if(tbUserName.Text.Length > 45)
            {
                excessLength = true;
                MessageBox.Show($"{Properties.Resources.excessLengthMessage}", $"{Properties.Resources.excessLengthTile}", MessageBoxButton.OK);
            }
            return excessLength;
        }
        #endregion
    }
}
