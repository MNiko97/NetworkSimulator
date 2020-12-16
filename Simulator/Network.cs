using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
namespace Network{
    class Network{
        public Dictionary<int, Node> nodeArray;
        public Dictionary<int, Line> lineArray;
        public Weather weather;
        public int newLineID;
        public int newNodeID;
        public Network(){
            this.nodeArray = new Dictionary<int, Node>();
            this.lineArray = new Dictionary<int, Line>();
            this.weather = new Weather(100, 50);        
            this.newLineID = 0;
            this.newNodeID = 0;
        }
        public void addPowerStationNode(PowerStationNode node){
            node.setId(newNodeID);
            nodeArray.Add(newNodeID++, node);
        }
        public void addConsumerNode(ConsumerNode node){
            node.setId(newNodeID);
            nodeArray.Add(newNodeID++, node);
        }
        public void addConcentrationNode(){
            ConcentrationNode node = new ConcentrationNode();
            node.setId(newNodeID);
            nodeArray.Add(newNodeID++, node);
        }
        public void addDistributionNode(){
            DistributionNode node = new DistributionNode();
            node.setId(newNodeID);
            nodeArray.Add(newNodeID++, node);
        }
        public void addLine(int maxPower){
            lineArray.Add(newLineID, new Line(newLineID++, maxPower));
        }
        public void connect(int node1ID, int node2ID, int lineID){
            nodeArray[node1ID].connect(lineArray[lineID]);
            nodeArray[node2ID].connect(lineArray[lineID]);
        }
        public void updateNetwork(){
            foreach(var node in nodeArray){
                node.Value.update();
            }
            foreach(var line in lineArray){
                line.Value.update();
            }
        }
        public void show(){
            foreach (var line in lineArray){
                Console.WriteLine("{0}    Status: {1}    Current Power: {2}MW    Connected: {3}", 
                line.Value, line.Value.getLineState(), line.Value.getLinePower(), line.Value.isConnected);
            }
            foreach (var node in nodeArray){
                Console.WriteLine("{0}    Status: {1}    Current Power: {2}MW",
                node.Value, node.Value.getNodeState(), node.Value.getNodePower());
            }
        }
        /*public void connectTwoNodes(string node1ID, string node2ID, string lineID){
            string node1str = Regex.Replace(node1ID, "[^0-9.]", "");
            string node2str = Regex.Replace(node2ID, "[^0-9.]", "");
            string linestr = Regex.Replace(lineID, "[^0-9.]", "");
            int node1;
            int node2;
            int line;
            if(Int32.TryParse(node1str, out node1) && Int32.TryParse(node2str, out node2) && Int32.TryParse(linestr, out line)){
                Console.WriteLine(nodeArray[node1] is PowerStationNode);
                Console.WriteLine(nodeArray[node1].GetType().Name);
                try{
                    lineArray[line].connect(nodeArray[node1], nodeArray[node2]);
                }
                catch{
                    Console.WriteLine("One of the node or line does not exist");
                }
            }
        }*/
    }
}