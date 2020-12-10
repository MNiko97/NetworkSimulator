using System;
using System.Collections.Generic;
namespace Network{
    class Network{
        public List<Node> nodeArray;
        public List<Line> lineArray;
        public Weather weather;
        public int componentID;
        public Network(){
            this.nodeArray = new List<Node>();
            this.lineArray = new List<Line>();
            this.weather = new Weather(100, 50);        
            this.componentID = 0;
        }
        public void addNodeToNetwork(Node node){
            nodeArray.Add(new Node(componentID));
            componentID++;
        }
        public void addLineToNetwork(int maxPower){
            lineArray.Add(new Line(componentID, maxPower));
            componentID++;
        }
        public void updateNewtork(){
            foreach(Node node in nodeArray){
                node.updateNode();
            }
            foreach(Line line in lineArray){
                line.updateLine();
            }
        }
    }
}