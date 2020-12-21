using System;
using System.Collections.Generic;

namespace Network
{
    class PowerStationNode : Node 
    {
        public Dictionary <string, bool> sourceType;
        public int maxEnergyProduction;
        public float currentCost ;
        public float currentPollution;      
        public Fuel fuelType;
        public int weatherIntensity;
        public List<Line> connexionLine;


        public PowerStationNode(int maxEnergyProduction, Fuel fuelType): base()
        {
            this.maxEnergyProduction = maxEnergyProduction;
            this.sourceType = new Dictionary<string, bool>();
            this.sourceType.Add("isFlexible",false);
            this.sourceType.Add("isWeatherDependant",false);
            this.sourceType.Add("isInfinite",false);
            
            this.fuelType = fuelType;
            
            this.nodeState = true;
            this.connexionLine = new List<Line>();

            if(maxEnergyProduction>=0)
            {
                this.nodePower = maxEnergyProduction;
            }
            else
            {
                this.nodePower = 0;
            }
        
        }

        
        public override string ToString(){
            return "Power Station N" + id.ToString();
            
        }
        public virtual void setEnergyProduction(float newEnergyQuantity)
        {

            if(newEnergyQuantity <=0) //asking to turn off
            {
                this.nodePower = 0;
                this.nodeState = false;
            }
            else    //asking to set a new value or turn on
            {
                if(this.sourceType["isFlexible"]) //if flexible
                {
                    if (newEnergyQuantity>=this.maxEnergyProduction)
                    {
                        this.nodePower = this.maxEnergyProduction;
                    }
                    else
                    {
                        this.nodePower = newEnergyQuantity;
                    }
                    this.nodeState = true;
                }
                else //if not flexible
                {
                    this.nodePower = this.maxEnergyProduction;
                    this.nodeState = true;
                }
            }

        }
        

        public void setCurrentPollution()
        {
            currentPollution = this.nodePower * fuelType.getPollution() / fuelType.getEnergy();
        }

        public virtual void setCurrentCost()
        {        
            currentCost = this.fuelType.getCost() * this.nodePower / fuelType.getEnergy();
        }
        

        public override void update()
        {
            //Console.WriteLine("Node N" + id.ToString() + " is updating");
            if(nodeState){
                if(isConnected){
                    connexionLine[0].setPowerLine(nodePower, id);
                    connexionLine[0].update();
                }
            }
            setCurrentPollution();
            setCurrentCost();
            
            
            
        }

        public override List<string> getAlert()
        {
            throw new NotImplementedException();
        }

        public override void connect(Line line)
        {
            if(!isConnected){
                connexionLine.Add(line);
                isConnected = true;
                line.addNode(this);
            }else{
                Console.WriteLine("Node N", id, " is already connected");
            }
        }
        public string getCurrentState()
        {
            //update();
            return ("\n"+this.GetType().Name+" Production : "+this.nodePower+"MW. Cost : "+this.currentCost+ "Euros. Pollution : "+this.currentPollution +"g of CO2." );
        }
    }
}

