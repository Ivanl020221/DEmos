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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using System.Data.Entity;

namespace ESoftCall.Calls
{
    /// <summary>
    /// Логика взаимодействия для CallList.xaml
    /// </summary>
    public partial class CallList : Page
    {
        ObservableCollection<User> users;

        User user;

        UserXEntities context = new UserXEntities();

        List<Call> calls;

        public CallList()
        {
            InitializeComponent();
            user = Main.MainWindow.User;
            this.Loaded += this.LoadData;
        }

        private void LoadData(object sender, RoutedEventArgs e)
        {
            context.User.Load();
            this.users = context.User.Local;
            this.users.Add(new User { Фамилия = "Все пользователи" });
            this.Users.ItemsSource = this.users.OrderBy(i => i.ID);
            var index = users.IndexOf(context.User.Where(i => i.ID == user.ID).FirstOrDefault());
            this.Users.SelectedIndex = ++index;
            LoadList();
        }

        private void LoadList()
        {
            this.calls = context.Call.Where(i => !i.Удален).OrderBy(i => i.ДатаВремяЗвонкаПоЛиду).ToList();
            if (this.Users.SelectedIndex > 0)
                if (this.Users.SelectedItem is User user)
                    this.calls = context.Call.Where(i => i.Пользователь == user.ID && !i.Удален).
                        OrderBy(i => i.ДатаВремяЗвонкаПоЛиду).ToList();
            this.Calls.ItemsSource = this.calls;
        }

        private void Selected(object sender, EventArgs e)
        {
            LoadList();
        }

        private void RemoveCall(object sender, RoutedEventArgs e)
        {
            using (var saving = new UserXEntities())
            {
                var question = MessageBox.Show("Вы уверены, что хотите удалить звонок?", "удалить", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (question == MessageBoxResult.Yes)
                {
                    if (this.Calls.SelectedItem is Call call)
                    {
                        if (call.Lead.Статус != 2)
                        {
                            var SelectCall = saving.Call.Where(i => i.ID == call.ID).FirstOrDefault();
                            SelectCall.Удален = true;
                            saving.SaveChanges();
                        }
                        LoadList();
                    }
                }
            }
        }

        private void GoTo(object sender, RoutedEventArgs e)
        {
            if (this.Calls.SelectedItem is Call call)
            {
                CallsInfo callsInfo = new CallsInfo();
                callsInfo.Calls = call;
                callsInfo.InfoTest.Content = call.Lead.НомерТелефонаКлиента.ToString();
                NavigationService.Navigate(callsInfo);
            }
        }
    }
}
