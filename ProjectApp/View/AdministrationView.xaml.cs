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
    /// Логика взаимодействия для AdministrationView.xaml
    /// </summary>
    public partial class AdministrationView : Window
    {
        public AdministrationView()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            RegistrationView registrationWindow = new RegistrationView();
            registrationWindow.DataContext = new RegistrationViewModel();
            registrationWindow.Show();
            registrationWindow.Top = this.Top;
            registrationWindow.Left = this.Left;
            registrationWindow.Width = this.Width;
            registrationWindow.Height = this.Height;
        }
    }
}
