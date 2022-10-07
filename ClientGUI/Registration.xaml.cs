using Authenticator;
using System;
using System.ServiceModel;
using System.Windows;
using System.Windows.Controls;
using Authenticator;

namespace ClientGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Registration : Window
    {
        private ServerInterface foob;

        ImplementService imp = new ImplementService();
        public void RegistrationL()
        {
            InitializeComponent();
            var tcp = new NetTcpBinding();
            //Set the URL and create the connection!
            var URL = "net.tcp://localhost:8100/ImplementService";
            var chanFactory = new ChannelFactory<ServerInterface>(tcp, URL);
            foob = chanFactory.CreateChannel();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string name = username.Text;
            string pass = password.Password;

            if (name != string.Empty || pass != string.Empty)
            {
                MessageBox.Show("Registration Successful");
                imp.Register(name, pass);
            }
            else
            {
                MessageBox.Show("Registration Unsuccessful");
            }
        }

        private void Button_Click_Go_Login(object sender, RoutedEventArgs e)
        {
            var login = new login();
            login.ShowDialog();
            this.Close();
        }

        private void password_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }
    }
}
