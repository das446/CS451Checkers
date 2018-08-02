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
using CS451Checkers.Networking;

namespace CS451Checkers
{
    /// <summary>
    /// Interaction logic for Lobby.xaml
    /// </summary>
    public partial class Lobby : Window
    {


        public Lobby()
        {
            InitializeComponent();
            GameManager.Instance = new GameManager();
        }

        private void Host_Click(object sender, RoutedEventArgs e)
        {
            Connect.Visibility = Visibility.Hidden;
            IP.Content = "Waiting for another player...\n You're IP is " + GameManager.Instance.LocalIPAddress();
            GameManager.Instance.HostButton();
        }

        private void Connect_Click(object sender, RoutedEventArgs e)
        {
            GameManager.Instance.ConnectToServerButton(ConnectIP.Text);
        }


    }
}
