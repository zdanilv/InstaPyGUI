using System;
using System.Collections.Generic;
using System.Globalization;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace InstaPyGUI
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new ViewModel.ViewModel();

            App.LanguageChanged += LanguageChanged;

            CultureInfo currentLanguage = App.Language;
            menuLanguage.Items.Clear();
            foreach (var lang in App.Languages)
            {
                MenuItem menuLang = new MenuItem();
                menuLang.Header = lang.DisplayName;
                menuLang.Tag = lang;
                menuLang.IsChecked = lang.Equals(currentLanguage);
                menuLang.Click += MenuItem_Language_Click;
                menuLanguage.Items.Add(menuLang);
            }
        }

        private void LanguageChanged(Object sender, EventArgs e)
        {
            CultureInfo currLang = App.Language;
            foreach (MenuItem i in menuLanguage.Items)
            {
                CultureInfo ci = i.Tag as CultureInfo;
                i.IsChecked = ci != null && ci.Equals(currLang);
            }
        }

        private void MenuItem_Language_Click(object sender, RoutedEventArgs e)
        {
            MenuItem mi = sender as MenuItem;
            if (mi != null)
            {
                CultureInfo lang = mi.Tag as CultureInfo;
                if (lang != null)
                {
                    App.Language = lang;
                }
            }
        }

        // Like
        private void expander_like_checkBox_Checked(object sender, RoutedEventArgs e)
        {
            if(expander_like.IsEnabled != true)
            {
                expander_like.IsEnabled = true;
                if (expander_like.IsExpanded != true)
                    expander_like.IsExpanded = true;
            }
        }

        private void expander_like_checkBox_Unchecked(object sender, RoutedEventArgs e)
        {
            if (expander_like.IsEnabled != false)
            {
                expander_like.IsEnabled = false;
                if (expander_like.IsExpanded != false)
                    expander_like.IsExpanded = false;
            }
        }

        // Follow
        private void expander_follow_checkBox_Checked(object sender, RoutedEventArgs e)
        {
            if (expander_follow.IsEnabled != true)
            {
                expander_follow.IsEnabled = true;
                if (expander_follow.IsExpanded != true)
                    expander_follow.IsExpanded = true;
            }
        }

        private void expander_follow_checkBox_Unchecked(object sender, RoutedEventArgs e)
        {
            if (expander_follow.IsEnabled != false)
            {
                expander_follow.IsEnabled = false;
                if (expander_follow.IsExpanded != false)
                    expander_follow.IsExpanded = false;
            }
        }

        // Unfollow
        private void expander_unfollow_checkBox_Checked(object sender, RoutedEventArgs e)
        {
            if (expander_unfollow.IsEnabled != true)
            {
                expander_unfollow.IsEnabled = true;
                if (expander_unfollow.IsExpanded != true)
                    expander_unfollow.IsExpanded = true;
            }
        }

        private void expander_unfollow_checkBox_Unchecked(object sender, RoutedEventArgs e)
        {
            if (expander_unfollow.IsEnabled != false)
            {
                expander_unfollow.IsEnabled = false;
                if (expander_unfollow.IsExpanded != false)
                    expander_unfollow.IsExpanded = false;
            }
        }
    }
}
