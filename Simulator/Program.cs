using System;

namespace Network
{
    class Program
    {
        static void Main(string[] args)
        {
            Network network = new Network();
            network.addLineToNetwork(50);
            network.addNodeToNetwork();
            network.addNodeToNetwork();
            network.connectTwoNodes(0,1,0);
            network.show();
        }
    }
}