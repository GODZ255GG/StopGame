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
    /// Lógica de interacción para VerifyEmail.xaml
    /// </summary>
    public partial class VerifyEmail : Window
    {
        private int validationCode;

        public int ValidationCode { get { return validationCode; } set { validationCode = value; } }
        public VerifyEmail()
        {
            InitializeComponent();
        }

        private void BtnVerifyEmail_Click(object sender, RoutedEventArgs e)
        {
            var code = tbCode.Text;
            if(!String.IsNullOrWhiteSpace(code))
            {
                if(Convert.ToInt32(code) == validationCode)
                {
                    MessageBox.Show("Bien", "Validacion exitosa");
                    DialogResult = true;
                    this.Close();
                }
                else 
                { 
                    DialogResult = false;
                    MessageBox.Show("Mal", "Validacion fallida");
                }
            }
        }

        private void ImgReturn_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DialogResult = false;
            this.Close();
        }
    }
}
