using System;
using System.Collections.Generic;
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
        public void addContentrationNode(){
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
        public void connectTwoNodes(int node1ID, int node2ID, int lineID){
            try{
                lineArray[lineID].connect(nodeArray[node1ID], nodeArray[node2ID]);
            }
            catch{
                Console.WriteLine("One of the node or line does not exist");
            }
        }
        public void updateNetwork(){
            foreach(var node in nodeArray){
                node.Value.updateNode();
            }
            foreach(var line in lineArray){
                line.Value.updateLine();
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
    }
}