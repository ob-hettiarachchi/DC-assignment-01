using Authenticator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web;

namespace Registry.Models
{
    public class authentication
    {
        public authentication(string status, string reason)
        {
            Status = status;
            Reason = reason;
        }
        private authentication() { }
        private static authentication instance = null;
        public static authentication Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new authentication();
                }
                return instance;
            }
        }
        public string Status { get; set; }
        public string Reason { get; set; }



        public ServerInterface initServerConnection()
        {
            ServerInterface foob;
            var tcp = new NetTcpBinding();
            var URL = "net.tcp://0.0.0.0:8100/authenticationService";
            var chanFactory = new ChannelFactory<ServerInterface>(tcp, URL);
            foob = chanFactory.CreateChannel();
            return foob;
        }
    }
}