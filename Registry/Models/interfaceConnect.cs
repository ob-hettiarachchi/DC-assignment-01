using Authenticator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web;

namespace Registry.Models
{
    public class interfaceConnect
    {
            private ServerInterface serverInterface;

            public ServerInterface createchannel()
            {
                ChannelFactory<ServerInterface> channelFactory;
                NetTcpBinding tcp = new NetTcpBinding();
                string URL = "net.tcp://localhost:8100/ImplementService";
                channelFactory = new ChannelFactory<ServerInterface>(tcp, URL);
                serverInterface = channelFactory.CreateChannel();
                return serverInterface;
            }
    }
}