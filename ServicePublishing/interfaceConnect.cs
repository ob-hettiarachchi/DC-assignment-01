using Authenticator;
using System.ServiceModel;

namespace ServicePublishing
{
    internal class interfaceConnect
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
