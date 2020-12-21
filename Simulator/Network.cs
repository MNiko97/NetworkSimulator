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
            this.weather = new Weather(80, 50);        
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
            return powerRequired - powerSent; //demand - supply
        }
        public int getPriority(int actualPriority)
        {
            if(diff() > 0){ // need more power production
                
                if(actualPriority == -1)
                {
                    actualPriority +=2; 
                }
                else
                {
                    actualPriority +=1; 
                }
            }
            else if(diff() == 0){ // power requirement reached successfully !
                actualPriority = 0;
            }
            else if(diff() < 0){ // need to reduce power production
                if(actualPriority ==1)
                {
                    actualPriority -=2; 
                }
                else
                {
                    actualPriority -=1; 
                }
                
            } 
            return actualPriority;
        }
        public void setConsumerPower(string nodeType)
        {
            foreach(var consumer in consumerArray)
            {
                if(consumer.Value.GetType().Name == nodeType)
                {
                    // MINUS diff() because we want to reduce when diff()>0 and augment when <0
                    consumer.Value.setEnergyRequire(consumer.Value.nodePower - diff()); 
                    Console.WriteLine(consumer.Value+"    Current Power {0}    Difference {2}    energy require {1}",
                    consumer.Value.nodePower, consumer.Value.energyRequire, diff());
                }
            }
        }
        public void setSourcePower(bool  isFlexible, bool isWeatherDependent, bool isInfinite)
        {
            foreach(var source in sourceArray)
            {
                if(source.Value.sourceType["isFlexible"] == isFlexible && source.Value.sourceType["isWeatherDependant"] == isWeatherDependent 
                && source.Value.sourceType["isInfinite"] == isInfinite)
                {
                    // PLUS diff() because we want to augment when diff()>0 and reduce when <0
                    source.Value.setEnergyProduction(source.Value.nodePower + diff()); 
                    Console.WriteLine(source.Value+"    Current Power {0}    Difference {2}    max power {1}",
                    source.Value.nodePower, source.Value.maxEnergyProduction, diff());
                }

            }
        }
        public void run(){
            Console.WriteLine("\n ACTIVE POWER STATIONS");
            foreach(var source in sourceArray)
            {
                Console.WriteLine(source.Value+"            Current Power {1}           Max Power {2}           Type {0}",
                source.Value.GetType().Name, source.Value.nodePower, source.Value.maxEnergyProduction);
            }
            Console.WriteLine("\n ACTIVE CONSUMERS");
            foreach(var consummer in consumerArray)
            {
                Console.WriteLine(consummer.Value+"          Current Power {1}           Power Require {2}           Type {0}",
                consummer.Value.GetType().Name, consummer.Value.nodePower, consummer.Value.energyRequire);
            }
            Console.WriteLine("\n");
            
            string mess= "demand = supply";
            int status = 0;
            while(diff()!=0)
            {
                
                if(diff()>0){
                    status+=1;
                    mess= "demand > supply";
                }else{
                    status-=1;
                    mess= "demand < supply";
                }
                switch (status)
                {
                    case 0 :    //check state
                        if(diff()>0) //demand>supply
                        {
                            Console.WriteLine("CASE 0 if diff>0");
                            status=1; 
                        }
                        else //demand<supply
                        {
                            Console.WriteLine("CASE 0 if diff<0");
                            status= -1;
                        }
                        break;
                    case 1: // need to reduce DISSIPATOR
                        setConsumerPower("Dissipator");
                        break;
                    case 2: // need to augment WIND
                        setSourcePower(true, true,false);
                        break;
                    case 3: // need to to augment GAS
                        setSourcePower(true, false ,false);
                        break;
                    case 4: // need to need to to augment IMPORT
                        setSourcePower(true, false ,true);
                        // status = 0;
                        break;
                    case -1: // need to reduce IMPORT 
                        setSourcePower(true, false ,true);
                        break;
                    case -2: // need to reduce GAS
                        setSourcePower(true, false ,false);
                        break;
                    case -3: // need to reduce WIND
                        setSourcePower(true, true ,false);
                        break;
                    case -4: // need to augment DISSIPATOR
                        setConsumerPower("Dissipator");
                        // status = 0;
                        break;
                    default: 
                        Console.WriteLine("ERROR");
                        //status = 0;
                        break;
                    
                }
            }

            
            
            Console.WriteLine("The status of the nodes before modification are : {0} and the difference is : {1}",mess,diff());
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