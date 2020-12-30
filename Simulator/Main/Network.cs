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
        public Network()
        {
            this.nodeArray = new Dictionary<int, Node>();
            this.sourceArray = new Dictionary<int, PowerStationNode>();
            this.consumerArray = new Dictionary<int, ConsumerNode>();
            this.lineArray = new Dictionary<int, Line>();
            this.weather = new Weather(80, 50);        
            this.newLineID = 0;
            this.newNodeID = 0;
        }  
        public void addPowerStationNode(PowerStationNode node)
        {
            node.setId(newNodeID);
            sourceArray.Add(newNodeID, node);
            nodeArray.Add(newNodeID++, node);
        }
        public void addConsumerNode(ConsumerNode node)
        {
            node.setId(newNodeID);
            consumerArray.Add(newNodeID, node);
            nodeArray.Add(newNodeID++, node);
        }
        public void addConcentrationNode()
        {
            ConcentrationNode node = new ConcentrationNode();
            node.setId(newNodeID);
            nodeArray.Add(newNodeID++, node);
        }
        public void addDistributionNode()
        {
            DistributionNode node = new DistributionNode();
            node.setId(newNodeID);
            nodeArray.Add(newNodeID++, node);
        }
        public void addLine(int maxPower)
        {
            lineArray.Add(newLineID, new Line(newLineID++, maxPower));
        }
        public void connect(int node1ID, int node2ID, int lineID)
        {
            nodeArray[node1ID].connect(lineArray[lineID]);
            nodeArray[node2ID].connect(lineArray[lineID]);
        }
        public void updateNetwork()
        {
            List<int> updatedNode = new List<int>();
            List<int> updatedLine = new List<int>();
            foreach(var powerNode in sourceArray)
            {
                powerNode.Value.update();
                updatedNode.Add(powerNode.Value.id);
            }
            foreach (var line in lineArray){
                while(!updatedLine.Contains(line.Value.id))
                {
                    if(updatedNode.Contains(line.Value.connexionNode[0].id))
                    {
                        line.Value.connexionNode[1].update();
                        updatedNode.Add(line.Value.connexionNode[1].id);
                        updatedLine.Add(line.Value.id);
                    }
                }
            }
        }
        public float diff()
        {
            float powerRequired = 0;
            float powerSent = 0;
            foreach (var powerStation in sourceArray)
            {
                powerSent += powerStation.Value.nodePower;
            }
            foreach (var consumer in consumerArray)
            {
                powerRequired += consumer.Value.energyRequire;
            }
            return powerRequired - powerSent; //demand - supply
        }
        
        public void setConsumerPower(bool isPrioritized)
        {
            foreach(var consumer in consumerArray)
            {
                if (consumer.Value.isPrioritized ==isPrioritized)
                {
                    // MINUS diff() because we want to reduce when diff()>0 and augment when <0
                     
                    Console.WriteLine(consumer.Value+"     Current Power {0} MW     Power Require {1} - {2} MW",
                    consumer.Value.nodePower, consumer.Value.energyRequire,diff());

                    consumer.Value.setNewRequirement(consumer.Value.nodePower- diff());
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
                    
                    Console.WriteLine(source.Value+"     Max Power : {0}MW     Current Power : {1} + {2} MW",
                    source.Value.maxEnergyProduction, source.Value.nodePower,diff());

                    source.Value.setEnergyProduction(source.Value.nodePower + diff());
                }

            }
        }
        public void run(){
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine("\nADJUSTMENTS");
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine("\nThe Adjustments we have to make in the Power Stations : {0}",diff()+
            "\nIf the value is >0 : need to produce more. Else if value is<0 : need to produce less. Else : no modification required.\n");


            string mess= "demand = supply";
            int status = 0;
            while(diff()!=0)
            {
                
                if(diff()>0){
                    status+=1;
                    mess= "demand > supply";
                }else
                {
                    status-=1;
                    mess= "demand < supply";
                }
                switch (status)
                {
                    case 1: // need to reduce DISSIPATOR
                        setConsumerPower(false);
                        break;
                    case 2: // need to augment WIND
                        setSourcePower(true, true,false);
                        break;
                    case 3: // need to to augment GAS
                        setSourcePower(true, false ,false);
                        break;
                    case 4: // need to need to to augment IMPORT
                        setSourcePower(true, false ,true);
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
                        setConsumerPower(false);
                        break;
                    default: 
                        if(diff()>0){
                            mess= "ERROR, could not provide requested supply";
                        }else{
                            status-=1;
                            mess= "ERROR, could not reduce the supply";
                        }
                        break;
                    
                }
            }   
            Console.WriteLine("\nThe adjustment we needed to make were : {0} and the difference is now : {1}",mess,diff());
            update();
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine("AFTER ADJUSTMENTS");
            show();
            foreach(var consumer in consumerArray) //change a little the requirements of the consummers
            {
                if(consumer.Value.nodeState && consumer.Value.isPrioritized)
                {
                    consumer.Value.changeRequirement();  
                }
            }
            
        }
        public void show(){
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine("\nPOWER STATIONS");
            foreach(var source in sourceArray)
            {
                Console.WriteLine(source.Value+"     Max Power : {2}MW     Current Power : {1} MW     Current Cost : {3} Euros     Current Pollution : {4} g of CO2     State : {5}     Type : {0}",
                source.Value.GetType().Name, source.Value.nodePower, source.Value.maxEnergyProduction,source.Value.currentCost,source.Value.currentPollution,source.Value.getNodeState());
            }
            Console.WriteLine("\nCONSUMERS");
            foreach(var consummer in consumerArray)
            {
                Console.WriteLine(consummer.Value+"     Current Power : {1} MW     Power Require {2} MW     State : {3}     Type : {0}",
                consummer.Value.GetType().Name, consummer.Value.nodePower, consummer.Value.energyRequire,consummer.Value.getNodeState());
            }
            Console.WriteLine("\nLINES");
            foreach (var line in lineArray)
            {
                Console.WriteLine("{0}    Status: {1}    Current Power: {2} MW    Connected: {3}    Link: {4}", 
                line.Value, line.Value.getLineState(), line.Value.getLinePower(), line.Value.isConnected, line.Value.showConnexionNode());
            }
        }
    }
}