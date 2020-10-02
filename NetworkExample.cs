using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace networkExampleFA20
{
    class NetworkNode
    {
        public string router;
        public Connection[] connections = new Connection[4];
    }

    class Connection
    {
        public int weight { get; set; }
        public NetworkNode node { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            NetworkNode node1 = new NetworkNode() {router = "router1"};
            NetworkNode node2 = new NetworkNode() {router = "router2"};
            NetworkNode node3 = new NetworkNode() {router = "router3"};
            NetworkNode node4 = new NetworkNode() {router = "router4"};
            node1.connections[0] = new Connection() {node = node2, weight = 5};
            node1.connections[1] = new Connection() {node = node3, weight = 10};
            node2.connections[0] = new Connection() {node = node4, weight = 100};
            node3.connections[0] = new Connection() {node = node4, weight = 100};

            int lowestWeight = 999;
            Connection lowestNode = null;

            Console.WriteLine($"Starting at {node1.router}");
            foreach (Connection c in node1.connections)
            {
                if (c != null && c.weight < lowestWeight)
                {
                    lowestWeight = c.weight;
                    lowestNode = c;
                }
            }
            Console.WriteLine($"Hop - {lowestNode.node.router}");
            Console.WriteLine($"Hop - {lowestNode.node.connections[0].node.router}");
            Console.WriteLine(lowestNode.node.connections[0].node.router);

        }
    }
}
