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

namespace ESoftCall.Calls
{
    /// <summary>
    /// Логика взаимодействия для CallsInfo.xaml
    /// </summary>
    public partial class CallsInfo : Page
    {
        Call Calls;

        public CallsInfo(Call call)
        {
            this.Calls = call;
            InitializeComponent();
            TimeMask.Mask = "00:00";
            TimeMask.Text = Calls.ДатаВремяЗвонкаПоЛиду.ToLongTimeString();
            Date.SelectedDate = this.Calls.ДатаВремяЗвонкаПоЛиду;
            LenghtCall.Text = Calls.ДлительностьЗвонка.ToString();
            LeadInfo.Text = Calls.Lead.НомерТелефонаКлиента.ToString();
            UserCall.Text = Calls.User.Фамилия;
            Comment.Text = Calls.Коментарий;
        }
    }
}
