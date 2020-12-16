using System;
using System.Collections.Generic;

namespace Network
{
    class PowerStationNode : Node
    {
        public bool flexibility;
        public bool isWeatherDependent;
        public int maxEnergyProduction;
        public int utilizationPercentage; 
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
            this.utilizationPercentage = 100;
            this.fuelType = fuelType;
            //this.weatherIntensity = 0;
            this.isProviding = true;
            this.isConnectedToLine = false;
            this.connexionLine = new List<Line>();
            setUpdate();

        }
        public float getCurrentProduction()
        {
            return currentProduction;
        }
        public override string ToString(){
            return "Power Station N" + id.ToString();
        }
        public void setUtilizationPercentage(int newPercentage)
        {
            if(this.flexibility ==true)
            {
                if ( newPercentage>=0 && newPercentage<=100)
                {
                    this.utilizationPercentage = newPercentage;
                    if(newPercentage==0)
                    {
                        this.isProviding = false;
                    }
                }
                else
                {
                    this.utilizationPercentage = -2; //ERROR
                }
            }
            else if(this.flexibility ==false)
            {
                
                if(this.isWeatherDependent==true)
                {
                    this.utilizationPercentage = 100;
                    
                }
                else
                {
                    if(newPercentage==0 || newPercentage==100)
                    {
                        this.utilizationPercentage = newPercentage;
                        if(newPercentage==0)
                        {
                            this.isProviding = false;
                        }
                    }
                    else
                    {
                        this.utilizationPercentage =-1; //ERROR
                    }
                }
                
            }
            
            else
            {
                this.isProviding = true;
            }
            
            setUpdate();
        }

        public void setCurrentPollution()
        {
            currentPollution = currentProduction * fuelType.getPollution() / fuelType.getEnergy();
        }

        public virtual void setCurrentCost()
        {
            
            CurrentCost = this.fuelType.getCost() * currentProduction / fuelType.getEnergy();
 
        }
        public void setCurrentPower()
        {
            if(this.isWeatherDependent ==false)
            {
                //for ex : gas power station
                // Console.WriteLine("\n\nis weather dependent : FALSE FFS \n\n");
                currentProduction = this.maxEnergyProduction * this.utilizationPercentage /100;
            }
  
            else if (this.isWeatherDependent==true)
            {
                // Console.WriteLine("\n\nis weather dependent : TRUE FFS \n\n");
                //for ex : wind power stations (!!! there is a factor windintensity!!!)
                currentProduction = this.maxEnergyProduction * this.utilizationPercentage * this.weatherIntensity/10000;
            }

            else
            {
                currentProduction = 0;
            }

            
           
        }
        public void setUpdate()
        {
            setCurrentPower();
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
    }
}

