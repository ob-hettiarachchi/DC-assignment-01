using System;
using System.ServiceModel;
using System.Threading;

//OB Hettiarachchi - 20908883 - Assignment 01

namespace Authenticator
{
    class Server
    {
        static void Main(string[] args)
        {
            //start server
            Console.WriteLine("Welcome - Assignment 01 - OB Hettiarachchi - 20908883");

            //Bind the interface
            var tcp = new NetTcpBinding();
            
            //Create the host
            var host = new ServiceHost(typeof(ImplementService));
            //tcp hook
            host.AddServiceEndpoint(typeof(ServerInterface), tcp, "net.tcp://localhost:8100/ImplementService");
            host.Open();

            //Hold server
            Console.WriteLine("System Online");

            ImplementService imp = new ImplementService();
            Thread time = new Thread(imp.cleartoken);

            Console.WriteLine("Enter number of seconds to clear tokens: ");
            string tokentime = Console.ReadLine();
            int intTokenTime = Convert.ToInt32(tokentime);
            imp.setTime(intTokenTime);

            Console.WriteLine("Toke timeout limit is : " + intTokenTime);
            time.IsBackground = true;
            time.Start();

            Console.ReadLine();
                  
            //Close the host
            host.Close();
        }
    }
}
