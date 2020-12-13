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
        public void addNodeToNetwork(){
            nodeArray.Add(newNodeID, new Node(newNodeID++));
        }
        public void addLineToNetwork(int maxPower){
            lineArray.Add(newLineID, new Line(newLineID++, maxPower));
        }
        public void connectTwoNodes(int node1ID, int node2ID, int lineID){
               lineArray[lineID].connect(nodeArray[node1ID], nodeArray[node2ID]);
        }
        public bool searchLineByID(int id){
            if (lineArray.ContainsKey(id)){
                return true;
            }
            else{
                return false;
            }
        }
        public bool searchNodeByID(int id){
            if(nodeArray.ContainsKey(id)){
                return true;
            }
            else{
                return false;
            }
        }
        public void updateNewtork(){
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