using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace InstaPyGUI
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static List<CultureInfo> m_Language = new List<CultureInfo>();
        public static List<CultureInfo> Languages
        {
            get
            {
                return m_Language;
            }
        }

        public App()
        {
            InitializeComponent();
            App.LanguageChanged += App_LanguageChanged;

            m_Language.Clear();
            m_Language.Add(new CultureInfo("en-US"));
            m_Language.Add(new CultureInfo("ru-RU"));

            Language = InstaPyGUI.Properties.Settings.Default.DefaultLanguage;
        }

        public static event EventHandler LanguageChanged;
        public static CultureInfo Language
        {
            get
            {
                return System.Threading.Thread.CurrentThread.CurrentUICulture;
            }
            set
            {
                if (value == null) throw new ArgumentNullException("value");
                if (value == System.Threading.Thread.CurrentThread.CurrentUICulture) return;

                System.Threading.Thread.CurrentThread.CurrentUICulture = value; // 1. Меняем язык приложения

                ResourceDictionary dictionary = new ResourceDictionary(); // 2. Создаём ResourceDictionary для новой культуры
                switch (value.Name)
                {
                    case "ru-RU":
                        dictionary.Source = new Uri(String.Format("Resource/Language/lang.{0}.xaml", value.Name), UriKind.Relative);
                        break;
                    default:
                        dictionary.Source = new Uri("Resource/Language/lang.xaml", UriKind.Relative);
                        break;
                }

                // 3. Находим старую ResourceDictionary и удаляем его и добавляем новую ResourceDictionary
                ResourceDictionary old_dictionary = (from d in Application.Current.Resources.MergedDictionaries 
                                                     where d.Source != null 
                                                     && d.Source.OriginalString.StartsWith("Resource/Language/lang.") 
                                                     select d).First();
                if(old_dictionary != null)
                {
                    int ind = Application.Current.Resources.MergedDictionaries.IndexOf(old_dictionary);
                    Application.Current.Resources.MergedDictionaries.Remove(old_dictionary);
                    Application.Current.Resources.MergedDictionaries.Insert(ind, dictionary);
                }
                else
                {
                    Application.Current.Resources.MergedDictionaries.Add(dictionary);
                }

                // 4. Вызываем евент для оповещения всех окон.
                LanguageChanged(Application.Current, new EventArgs());
            }
        }

        private void App_LanguageChanged(Object sender, EventArgs e)
        {
            InstaPyGUI.Properties.Settings.Default.DefaultLanguage = Language;
            InstaPyGUI.Properties.Settings.Default.Save();
        }
    }
}
