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
using ProjectApp.Model;
using ProjectApp.ViewModel;
using ProjectApp.View;

namespace ProjectApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(string currentUserAvg)
        {
            InitializeComponent();
            currentUser.login = currentUserAvg;
        }

        private void Button_ClickOpenWindow(object sender, RoutedEventArgs e)
        {
            
            AddLotView addWindow = new AddLotView(currentUser.login);
            addWindow.Show();
            addWindow.Top = this.Top;
            addWindow.Left = this.Left;
            addWindow.Width = this.Width;
            addWindow.Height = this.Height;
            this.Close();
        }

        private void ClientInfo_Click(object sender, RoutedEventArgs e)
        {
            ClientInfoView clientWindow = new ClientInfoView(currentUser.login);
            clientWindow.Show();
            clientWindow.Top = this.Top;
            clientWindow.Left = this.Left;
            clientWindow.Width = this.Width;
            clientWindow.Height = this.Height;
            this.Close();
        }
    }
}
