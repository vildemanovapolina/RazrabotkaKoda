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
using static Todo.Class;

namespace Todo
{
    /// <summary>
    /// Логика взаимодействия для LogIn.xaml
    /// </summary>
    public partial class LogIn : Window
    {
        UserRepository UR = new UserRepository();
        public LogIn()
        {
            InitializeComponent();
        }

        
            private void Log_In(object sender, RoutedEventArgs e)
            {
                string email = Почта.Text.Trim().ToLower();
                string password = Password.Text.Trim();

                //Проверка полей на правильность с последующий входом

                if (!Class.ValidateEmail(email))
                {
                    MessageBox.Show("Некорректный email.", "Ошибка");
                    return;
                }

                if (!Class.ValidatePassword(password))
                {
                    MessageBox.Show("Пароль должен содержать минимум 6 символов.", "Ошибка");
                    return;
                }
                try
                {
                    var user = UR.UserAuthenticate(email, password);
                    MainEmpty main_Empty = new MainEmpty();
                    main_Empty.Show();
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка");
                    return;
                }
            }
        

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Registration Registration = new Registration();
            Registration.Show();
            this.Close();
        }

        private void Почта_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Почта.Text == "pangcheo0210@gmail.com") { Почта.Foreground = this.Foreground; }
            Почта.Foreground = Brushes.Black;
        }

        private void Password_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Password.Text == "Введите пароль") { Password.Foreground = this.Foreground; }
            Password.Foreground = Brushes.Black;
        }
    }
}
