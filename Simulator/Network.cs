using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
namespace Network{
    class Network{
        public Dictionary<int, Node> nodeArray;
        public Dictionary<int, PowerStationNode> sourceArray;
        public Dictionary<int, ConsumerNode> consumerArray;
        public Dictionary<int, Line> lineArray;

        public Weather weather;

        public int newLineID;
        public int newNodeID;

        public Network(){
            this.nodeArray = new Dictionary<int, Node>();
            this.sourceArray = new Dictionary<int, PowerStationNode>();
            this.consumerArray = new Dictionary<int, ConsumerNode>();
            this.lineArray = new Dictionary<int, Line>();
            this.weather = new Weather(80, 70);        
            this.newLineID = 0;
            this.newNodeID = 0;
        }  
        public void addPowerStationNode(PowerStationNode node){
            node.setId(newNodeID);
            sourceArray.Add(newNodeID, node);
            nodeArray.Add(newNodeID++, node);
        }
        public void addConsumerNode(ConsumerNode node){
            node.setId(newNodeID);
            consumerArray.Add(newNodeID, node);
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
            List<int> updatedNode = new List<int>();
            List<int> updatedLine = new List<int>();
            foreach(var powerNode in sourceArray){
                powerNode.Value.update();
                updatedNode.Add(powerNode.Value.id);
            }
            foreach (var line in lineArray){
                Console.WriteLine("");
                while(!updatedLine.Contains(line.Value.id)){
                    if(updatedNode.Contains(line.Value.connexionNode[0].id)){
                        line.Value.connexionNode[1].update();
                        updatedNode.Add(line.Value.connexionNode[1].id);
                        updatedLine.Add(line.Value.id);
                    }
                }
            }
        }
        public float diff(){
            float powerRequired = 0;
            float powerSent = 0;
            foreach (var powerStation in sourceArray){
                powerSent += powerStation.Value.nodePower;
            }
            foreach (var consumer in consumerArray)
            {
                powerRequired += consumer.Value.energyRequire;
            }
            return powerRequired - powerSent;
        }
        public void run(){
            int priority = 1;
            bool running = true;
            while (running){
                switch (priority){
                    case 1:// Priority 1 : Use flexible sources to regulate power production
                        foreach (var source in sourceArray){ 
                            if(source.Value.isFlexible){
                                float currentPower = source.Value.nodePower;
                                source.Value.setEnergyProduction(currentPower + diff());
                            }
                        }
                        if(diff() > 0){ // need more power production
                            priority = 2;
                        }
                        if(diff() == 0){ // power requirement reached successfully !
                            priority = 0;
                        }
                        if(diff() < 0){ // need to reduce power production
                        priority = -2; 
                        } 
                        break;
                    case 2: // Priority 2 : buy from outside if possible
                        Console.WriteLine("Need to buy " + diff() + " MW");
                        priority = 0;
                        break;
                    case -2:
                        // Priority -2 : try to sell energy if possible
                        if (diff() < 0){ // need to reduce power production
                            priority = -3;
                        }
                        if(diff() == 0){ // power requirement reached successfully !
                            priority = 0;
                        }
                        break;
                    case -3: // Priority -3 : Reduce weather dependant power production
                        foreach (var source in sourceArray){ 
                            if(source.Value.isWeatherDependent){
                                float currentPower = source.Value.nodePower;
                                source.Value.setEnergyProduction(currentPower + diff());
                            }
                            if (diff() < 0){ // need to reduce power production
                            priority = -4;
                            }
                            if(diff() == 0){ // power requirement reached successfully !
                                priority = 0;
                            }
                        }
                        break;
                    case -4: // Priority 4 : use dissipator if possible
                        // implement dissipator 
                        if (diff() < 0){ // need to reduce power production
                            priority = -5;
                        }
                        if(diff() == 0){ // power requirement reached successfully !
                            priority = 0;
                        }
                        break;
                    case -5: // Priotrity 5 : last resolution, shut down constant sources
                        //turn on dependant power production
                        priority = 0;
                        break;
                    case 0: //stop
                        running = false;
                        break;
                }
            }
            updateNetwork();
        }
        public void show(){
            foreach (var line in lineArray){
                Console.WriteLine("{0}    Status: {1}    Current Power: {2}MW    Connected: {3}    Link: {4}", 
                line.Value, line.Value.getLineState(), line.Value.getLinePower(), line.Value.isConnected, line.Value.showConnexionNode());
            }
            foreach (var node in nodeArray){
                Console.WriteLine("{0}    Status: {1}    Current Power: {2}MW    Connected: {3}",
                node.Value, node.Value.getNodeState(), node.Value.getNodePower(), node.Value.isConnected);
            }
        }
    }
}