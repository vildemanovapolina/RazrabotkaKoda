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

namespace Todo
{
    /// <summary>
    /// Логика взаимодействия для MainEmpty1.xaml
    /// </summary>
    public partial class MainEmpty1 : Page
    {
        public MainEmpty1()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var createPage = new Создание_задачи1();
            NavigationService?.Navigate(createPage);
            bool taskCreated = false;
            createPage.Unloaded += (s, args) =>
            {
                if (createPage.NewTask != null)
                {
                    TaskManager.AllTasks.Add(createPage.NewTask);
                    taskCreated = true;
                }
            };
            if (taskCreated)
            {
                NavigationService?.Navigate(new Main1());
            }
        }
        private void Photo_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Photo.ContextMenu.IsOpen = true;
        }
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            var window = Window.GetWindow(this) as LogIn;
            if (window != null)
            {
                window.MainFrame.Visibility = Visibility.Collapsed;
                window.LoginFormGrid.Visibility = Visibility.Visible;
                window.MainFrame.Navigate(null);
            }

        }

        private void ChangeProfilePhoto_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

