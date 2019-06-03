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

namespace ESoftCall.Main
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static User User { get; set; }

        public MainWindow()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.HelpLink, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void SetTitle(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {
            try
            {
                if (MainFrame.Content is Page page)
                    this.Title = page.Title;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.HelpLink, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void GoBack(object sender, RoutedEventArgs e)
        {
            try
            {
                if (MainFrame.CanGoBack)
                    MainFrame.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.HelpLink, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Exit(object sender, RoutedEventArgs e)
        {
            try
            {
                var Message = MessageBox.Show("Вы уверены, что хотите выйти", "Выход", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (Message == MessageBoxResult.Yes)
                {
                    Auth.LoginPage login = new Auth.LoginPage();
                    login.Show();
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.HelpLink, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
