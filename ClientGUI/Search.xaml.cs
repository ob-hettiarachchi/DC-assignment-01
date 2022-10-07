using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace ClientGUI
{
    /// <summary>
    /// Interaction logic for Search.xaml
    /// </summary>
    public partial class Search : Window
    {
        public Search()
        {
            InitializeComponent();
        }

       private void GetAll_Services(object sender, RoutedEventArgs e)
        {
            service services;
            ProgressBar1.Dispatcher.Invoke(() => ProgressBar1.Value = 0, DispatcherPriority.Background);
            customer user = customer.Instance;
            string url = @"http://localhost:59849/api/AllServices/?token=" + user.getToken(); ;
            var clnt = new RestClient(url);
            var req = new RestRequest();
            var resp = clnt.Get(req);

            List<string> data = new List<string>();
            data = JsonConvert.DeserializeObject<List<string>>(resp.Content.ToString());
            if(data.Count != 0)
            {
                List<service> gridData = new List<service>();
                foreach (string value in data)
                {
                    services = JsonConvert.DeserializeObject<service>(value);
                    // Checks if the user has a valid token
                    if (services.Status.Equals("Denied"))
                    {
                        this.Close();
                        break;
                    }
                    gridData.Add(services);
                }
                // To show the progress bar
                for (int i = 1; i < 100; i++)
                {
                    ProgressBar1.Dispatcher.Invoke(() => ProgressBar1.Value = i, DispatcherPriority.Background);
                    Thread.Sleep(100);
                }
                // Placing the services in the GUI Table
                serviceInfo.ItemsSource = gridData;
            }
            else
            {
                MessageBox.Show("No Available Services!!");
            }
        }

        private void opentest(object sender, RoutedEventArgs e)
        {
            var test = new Testing();
            test.ShowDialog();
        }
    }
}
