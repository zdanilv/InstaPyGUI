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

        private void like_by_feed_checkBox_Checked(object sender, RoutedEventArgs e)
        {
            if (like_by_feed_amount_textBox.IsEnabled != true)
                like_by_feed_amount_textBox.IsEnabled = true;
            if (like_by_feed_amount_label.IsEnabled != true)
                like_by_feed_amount_label.IsEnabled = true;
        }

        private void like_by_feed_checkBox_Unchecked(object sender, RoutedEventArgs e)
        {
            if (like_by_feed_amount_textBox.IsEnabled != false)
                like_by_feed_amount_textBox.IsEnabled = false;
            if (like_by_feed_amount_label.IsEnabled != false)
                like_by_feed_amount_label.IsEnabled = false;
        }

        private void like_by_hashtags_checkBox_Checked(object sender, RoutedEventArgs e)
        {
            if(like_by_hashtags_amount_textBox.IsEnabled != true)
            {
                like_by_hashtags_amount_textBox.IsEnabled = true;
                hashtags_like_textBox.IsEnabled = true;
            }
            if (set_smart_hashtags_checkBox.IsEnabled != true)
                set_smart_hashtags_checkBox.IsEnabled = true;
            if(like_by_hashtags_amount_label.IsEnabled != true)
                like_by_hashtags_amount_label.IsEnabled = true;
        }

        private void like_by_hashtags_checkBox_Unchecked(object sender, RoutedEventArgs e)
        {
            if(like_by_hashtags_amount_textBox.IsEnabled != false)
            {
                like_by_hashtags_amount_textBox.IsEnabled = false;
                hashtags_like_textBox.IsEnabled = false;
            }
            if (set_smart_hashtags_checkBox.IsEnabled != false)
                set_smart_hashtags_checkBox.IsEnabled = false;
            if (like_by_hashtags_amount_label.IsEnabled != false)
                like_by_hashtags_amount_label.IsEnabled = false;
        }

        private void set_smart_hashtags_checkBox_Checked(object sender, RoutedEventArgs e)
        {
            if (smart_hashtags_limit_textox.IsEnabled != true)
                smart_hashtags_limit_textox.IsEnabled = true;
            if (limit_label.IsEnabled != true)
                limit_label.IsEnabled = true;
        }

        private void set_smart_hashtags_checkBox_Unchecked(object sender, RoutedEventArgs e)
        {
            if (smart_hashtags_limit_textox.IsEnabled != false)
                smart_hashtags_limit_textox.IsEnabled = false;
            if (limit_label.IsEnabled != false)
                limit_label.IsEnabled = false;
        }

        private void like_by_location_checkBox_Checked(object sender, RoutedEventArgs e)
        {
            if (like_by_location_amount_textBox.IsEnabled != true)
                like_by_location_amount_textBox.IsEnabled = true;

            if (location_like_textBox.IsEnabled != true)
                location_like_textBox.IsEnabled = true;
            if (like_by_location_amount_label.IsEnabled != true)
                like_by_location_amount_label.IsEnabled = true;
        }

        private void like_by_location_checkBox_Unchecked(object sender, RoutedEventArgs e)
        {
            if (like_by_location_amount_textBox.IsEnabled != false)
                like_by_location_amount_textBox.IsEnabled = false;

            if (location_like_textBox.IsEnabled != false)
                location_like_textBox.IsEnabled = false;
            if (like_by_location_amount_label.IsEnabled != false)
                like_by_location_amount_label.IsEnabled = false;
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
