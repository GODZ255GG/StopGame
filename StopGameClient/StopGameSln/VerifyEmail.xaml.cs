using System;
using System.Windows;
using System.Windows.Input;

namespace StopGame
{
    /// <summary>
    /// Lógica de interacción para VerifyEmail.xaml
    /// </summary>
    public partial class VerifyEmail : Window
    {
        private int _validationCode;

        public int ValidationCode { get { return _validationCode; } set { _validationCode = value; } }

        public VerifyEmail()
        {
            InitializeComponent();
        }

        private void ImgReturn_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DialogResult = false;
            this.Close();
        }

        private void BtnVerifyEmail_Click(object sender, RoutedEventArgs e)
        {
            var code = tbCode.Text;
            if(!String.IsNullOrWhiteSpace(code))
            {
                if(Convert.ToInt32(code) == _validationCode)
                {
                    MessageBox.Show($"{Properties.Resources.confirmedEmailMessage}", $"{Properties.Resources.confirmedEmailTile}", MessageBoxButton.OK);
                    DialogResult = true;
                    this.Close();
                }
                else 
                { 
                    DialogResult = false;
                    MessageBox.Show($"{Properties.Resources.errorConfirmedMessage}", $"{Properties.Resources.errorConfirmedTile}", MessageBoxButton.OK);
                }
            }
        }
    }
}
