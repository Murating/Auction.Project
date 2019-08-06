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
using ProjectApp.ViewModel;

namespace ProjectApp.View
{
    /// <summary>
    /// Логика взаимодействия для AuthorizationView.xaml
    /// </summary>
    public partial class AuthorizationView : Window
    {
        public AuthorizationView()
        {
            InitializeComponent();
        }

        private void OpenRegistration_Click(object sender, RoutedEventArgs e)
        {
            RegistrationView registrationWindow = new RegistrationView();
            registrationWindow.DataContext = new RegistrationViewModel();
            registrationWindow.Show();
            registrationWindow.Top = this.Top;
            registrationWindow.Left = this.Left;
            registrationWindow.Width = this.Width;
            registrationWindow.Height = this.Height;
            this.Close();
        }

        private void Open_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Login.Text == "admin" && Password.Password == "admin")
                {
                    AdministrationView administrationWindow = new AdministrationView();
                    administrationWindow.DataContext = new AdministrationViewModel();
                    administrationWindow.Show();
                    administrationWindow.Top = this.Top;
                    administrationWindow.Left = this.Left;
                    administrationWindow.Width = this.Width;
                    administrationWindow.Height = this.Height;
                    this.Close();
                }
                else if (DataBaseService.IsUserTrue(Login.Text, Password.Password))
                {
                    currentUser.login = Login.Text;
                    MainWindow mainWindow = new MainWindow(currentUser.login);
                    mainWindow.DataContext = new LotInfoViewModel();
                    mainWindow.Show();
                    mainWindow.Top = this.Top;
                    mainWindow.Left = this.Left;
                    mainWindow.Width = this.Width;
                    mainWindow.Height = this.Height;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Пользователь с данным логином и паролем не найден!");
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
        }
    }
}
