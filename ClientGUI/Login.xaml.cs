using Authenticator;
using System.ServiceModel;
using System.Windows;
using System.Windows.Controls;

namespace ClientGUI
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class login : Window
    {
        private ServerInterface foob;
        ImplementService imp = new ImplementService();
        public login()
        {
            InitializeComponent();
            // This is a factory that generates remote connections to our remote class. This 
            // is what hides the RPC stuff!
            ChannelFactory<Authenticator.ServerInterface> chanFactory;
            var tcp = new NetTcpBinding();
            //Set the URL and create the connection!
            var URL = "net.tcp://localhost:8100/ImplementService";
            chanFactory = new ChannelFactory<ServerInterface>(tcp, URL);
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
                MessageBox.Show("Login Successful");
                imp.Login(name, pass);
                var search = new Search();
                search.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Login Unsuccesful");
            }
        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }
    }
}
