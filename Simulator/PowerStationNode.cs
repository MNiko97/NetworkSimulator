using System;
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


        public PowerStationNode(int id, int maxEnergyProduction, Fuel fuelType): base(id)
        {
            this.maxEnergyProduction = maxEnergyProduction;
            this.flexibility = true;
            this.isWeatherDependent = false;
            this.utilizationPercentage = 100;
            this.fuelType = fuelType;
            //this.weatherIntensity = 100;
            this.isProviding = true;
            setUpdate();

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
                currentProduction = this.maxEnergyProduction * this.utilizationPercentage /100;
            }
  
            else if (this.isWeatherDependent==true)
            {
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

    }
}

