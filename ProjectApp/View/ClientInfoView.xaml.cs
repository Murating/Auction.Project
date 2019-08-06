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

namespace ProjectApp.View
{
    /// <summary>
    /// Логика взаимодействия для ClientInfoView.xaml
    /// </summary>
    public partial class ClientInfoView : Window
    {
        public ClientInfoView(string loginAgv)
        {
            InitializeComponent();
            currentUser.login = loginAgv;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow(currentUser.login);
            mainWindow.Show();
            mainWindow.Top = this.Top;
            mainWindow.Left = this.Left;
            mainWindow.Width = this.Width;
            mainWindow.Height = this.Height;
            this.Close();
        }
    }
}
