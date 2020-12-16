using System;
using System.Collections.Generic;

namespace Network
{
    class PowerStationNode : Node
    {
        public bool flexibility;
        public bool isWeatherDependent;
        public int maxEnergyProduction;
        public float CurrentCost ;
        public float currentPollution;      
        public float currentProduction; 
        public Fuel fuelType;
        public bool isProviding;
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
            this.isProviding = true;
            this.isConnectedToLine = false;
            this.connexionLine = new List<Line>();
            
            //setUpdate();

        }
        public float getCurrentProduction()
        {
            return currentProduction;
        }
        public override string ToString(){
            return "Power Station N" + id.ToString();
        }
        public virtual void setEnergyProduction(int newEnergyQuantity)
        {
            
            if (newEnergyQuantity>=this.maxEnergyProduction)
            {
                this.currentProduction = this.maxEnergyProduction;
                this.isProviding = true;
            }
            else if (newEnergyQuantity <= 0)
            {
                this.currentProduction =0;
                this.isProviding = false;
            }
            else
            {
                if (this.flexibility==true)
                {
                    this.currentProduction = newEnergyQuantity;
                }
                else
                {
                    this.currentProduction = this.maxEnergyProduction;
                }                   
                this.isProviding = true;
            }
            
            
            update();
        }

        public void setCurrentPollution()
        {
            currentPollution = this.currentProduction * fuelType.getPollution() / fuelType.getEnergy();
        }

        public virtual void setCurrentCost()
        {
            
            CurrentCost = this.fuelType.getCost() * this.currentProduction / fuelType.getEnergy();
 
        }
        
        public virtual void setUpdate()
        {
            setCurrentPollution();
            setCurrentCost();

        }
        public override void update()
        {
            if(isProviding){
                if(isConnectedToLine){
                    connexionLine[0].setPowerLine(1500, id);
                }
            }
            setUpdate(); // may modify it later
            
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
            +"\ncurrent prod : "+this.currentProduction+"\ncurrent cost : "+this.CurrentCost+ "\ncurrent pollution : "+this.currentPollution
            +"\nfuel energy per unit : "+this.fuelType.energyPerUnit+"\nis providing : "+this.isProviding + "\nweather intensity : "
            +this.weatherIntensity);
        }
    }
}

