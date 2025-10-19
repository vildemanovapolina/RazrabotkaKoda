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

namespace Todo
{
    /// <summary>
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        UserRepository UR = new UserRepository();
        Class Validate = new Class();
        public Registration()
        {
            InitializeComponent();
        }

        private void Имя_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Имя.Text == "Введите имя пользователя") { Имя.Foreground = this.Foreground; }
            else if (Имя.Text == "Имя не должно быть меньше 3 символов") { Имя.Foreground = Brushes.Red; }
            else Имя.Foreground = Brushes.Black;
        }
        private void EmailValidation(object sender, RoutedEventArgs e)
        {
            TextBox txt = (TextBox)sender;
            if (!Class.ValidateEmail(txt.Text))
            {
                Class.ShowError(txt, "Неверный формат почты");
            }
        }

        private void PasswordValidation(object sender, RoutedEventArgs e)
        {
            TextBox txt = (TextBox)sender;
            if (!Class.ValidatePassword(txt.Text))
            {
                Class.ShowError(txt, "Пароль не должен быть меньше 6 символов");
            }
        }

        private void NameValidation(object sender, RoutedEventArgs e)
        {
            TextBox txt = (TextBox)sender;
            if (!Class.ValidateName(txt.Text))
            {
                Class.ShowError(txt, "Имя не должно быть меньше 3 символов");
            }
        }

        private void BackToLogIn(object sender, RoutedEventArgs e)
        {
            var LogIn = new LogIn();
            LogIn.Show();
            this.Close();

        }

        private void Registation(object sender, RoutedEventArgs e)
        {
            string email = TBemail.Text.Trim().ToLower();
            string password = Пароль.Text.Trim();
            string repeatPassword = Повтор.Text.Trim();
            string login = Имя.Text.Trim();

            if (Имя.Text == "Имя не должно быть меньше 3 символов" || Имя.Text == "Введите имя пользователя") { MessageBox.Show("Неверно введены данные"); }
            else if (Пароль.Text == "Пароль не должен быть меньше 6 символов" || Пароль.Text == "Введите пароль") { MessageBox.Show("Неверно введены данные"); }
            else if (TBemail.Text == "Неверный формат почты" || TBemail.Text == "exam@yandex.ru") { MessageBox.Show("Неверно введены данные"); }
            else if (Повтор.Text == "Повторите пароль") { MessageBox.Show("Неверно введены данные"); }
            else if (UR.UserRegistration(login, password, email))
            {
                MainEmpty main_Empty = new MainEmpty();
                main_Empty.Show();
                this.Close();
            }
            else
            {
                return;
            }

        }

        private void email_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (TBemail.Text == "exam@yandex.ru") { TBemail.Foreground = this.Foreground; }
            else if (TBemail.Text == "Неверный формат почты") { TBemail.Foreground = Brushes.Red; }
            else TBemail.Foreground = Brushes.Black;
        }

        private void Пароль_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Пароль.Text == "Введите пароль") { Пароль.Foreground = this.Foreground; }
            else if (Пароль.Text == "Пароль не должен быть меньше 6 символов") { Пароль.Foreground = Brushes.Red; }
            else Пароль.Foreground = Brushes.Black;
        }

        private void Повтор_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Повтор.Text != Пароль.Text) { }
            if (Повтор.Text == "Повторите пароль") { Повтор.Foreground = this.Foreground; }
            else Повтор.Foreground = Brushes.Black;
        }

        
    }
}
