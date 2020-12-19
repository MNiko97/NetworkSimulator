using System;
using System.Collections.Generic;

namespace Network
{
    class PowerStationNode : Node
    {
        public bool flexibility;
        public bool isWeatherDependent;
        public int maxEnergyProduction;
        public float currentCost ;
        public float currentPollution;      
        public float currentProduction; 
        public Fuel fuelType;
        //public bool nodeState;
        //public bool nodeState;
        public int weatherIntensity;
        public bool isConnectedToLine;
        public List<Line> connexionLine;


        public PowerStationNode(int maxEnergyProduction, Fuel fuelType): base()
        {
            this.maxEnergyProduction = maxEnergyProduction;
            this.flexibility = true;
            this.isWeatherDependent = false;
            
            this.fuelType = fuelType;
            this.currentProduction = maxEnergyProduction;
            this.nodeState = true;
            this.isConnectedToLine = false;
            this.connexionLine = new List<Line>();

            
            //update();
            // nodeState = true;
            //setUpdate();

        }

        public override string ToString(){
            return "Power Station N" + id.ToString();
        }
        public virtual void setEnergyProduction(int newEnergyQuantity)
        {

            if(newEnergyQuantity <=0) //asking to turn off
            {
                // nodeState = false;
                // nodePower = 0;
                this.currentProduction = 0;
                this.nodeState = false;
            }
            else    //asking to set a new value or turn on
            {
                if(this.flexibility) //if flexible
                {
                    if (newEnergyQuantity>=this.maxEnergyProduction)
                    {
                        this.currentProduction = this.maxEnergyProduction;
                    }
                    else
                    {
                        this.currentProduction = newEnergyQuantity;
                    }
                    this.nodeState = true;
                }
                else //if not flexible
                {
                    this.currentProduction = this.maxEnergyProduction;
                    this.nodeState = true;
                }
            }


            
            
            update();
        }
        

        public void setCurrentPollution()
        {
            currentPollution = this.currentProduction * fuelType.getPollution() / fuelType.getEnergy();
        }

        public virtual void setCurrentCost()
        {
            
            currentCost = this.fuelType.getCost() * this.currentProduction / fuelType.getEnergy();
 
        }
        

        public override void update()
        {
            //Console.WriteLine("Node N" + id.ToString() + " is updating");
            if(nodeState){
                if(isConnectedToLine){
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
            if(!isConnectedToLine){
                connexionLine.Add(line);
                isConnectedToLine = true;
                line.addNode(this);
            }else{
                Console.WriteLine("Node N", id, " is already connected");
            }
        }
        public string getCurrentStatus()
        {
            update();
            return ("\nflex : "+this.flexibility + "\nis weather dependent : "+this.isWeatherDependent
            +"\nmax production : "+this.maxEnergyProduction
            +"\ncurrent prod : "+this.currentProduction+"\ncurrent cost : "+this.currentCost+ "\ncurrent pollution : "+this.currentPollution
            +"\nfuel energy per unit : "+this.fuelType.energyPerUnit+"\nis providing : "+this.nodeState + "\nweather intensity : "
            +this.weatherIntensity);
        }
    }
}

