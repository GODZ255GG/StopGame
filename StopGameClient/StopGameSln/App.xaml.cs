using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace StopGame
{
    /// <summary>
    /// Lógica de interacción para App.xaml
    /// </summary>
    public partial class App : Application
    {
        private List<string> languages = new List<string>() { "en", "en-US" };
        App()
        {
            CurrentLanguage = languages[0];
        }

        private string _CurrentLanguage;
        public string CurrentLanguage
        {
            get
            {
                return _CurrentLanguage;
            }
            private set
            {
                System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(value);
                _CurrentLanguage = value;
            }
        }

        public static new App Current
        {
            get
            {
                return (App)Application.Current;
            }
        }

        public void SwitchLanguage(string newLanguage)
        {
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(newLanguage);
            CurrentLanguage = newLanguage;
        }
    }
}
