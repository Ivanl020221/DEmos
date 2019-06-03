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

namespace ESoftCall.Auth
{
    /// <summary>
    /// Логика взаимодействия для LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Window
    {
        UserXEntities context = new UserXEntities();

        public LoginPage()
        {
            try
            {
                InitializeComponent();
                Application.Current.ShutdownMode = ShutdownMode.OnLastWindowClose;
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
                Application.Current.Shutdown();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.HelpLink, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Auth(object sender, RoutedEventArgs e)
        {
            try
            {
                var User = context.User.Where(i => i.Логин == Login.Text && i.Пароль == Password.Password);
                if (User.Count() > 0)
                {
                    Main.MainWindow main = new Main.MainWindow();
                    Main.MainWindow.User = User.FirstOrDefault();
                    main.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Такого пользователя не существует", "Предупрежедние", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.HelpLink, MessageBoxButton.OK, MessageBoxImage.Error);
            }
          
        }
    }
}
