using System;
namespace Network
{
    class PowerStationNode : Node
    {

        public string flexibility;
        public int maxEnergyProduction;
        public int utilizationPercentage; 
        public float CurrentCost ;
        public float currentPollution;      
        public float currentProduction; 
        public Fuel fuelType;


        public PowerStationNode(int id, int maxEnergyProduction, int utilizationPercentage, Fuel fuelType): base(id)
        {
            this.maxEnergyProduction = maxEnergyProduction;
            this.utilizationPercentage = utilizationPercentage;
            this.fuelType = fuelType;
            setCurrentPower();
            setCurrentPollution();
            setCurrentCost();

        }
        public void setCurrentPollution()
        {
            currentPollution = currentProduction * fuelType.getPollution();
        }

        public void setCurrentCost()
        {
            
            CurrentCost = this.fuelType.getCost() * currentProduction;
 
        }
        public void setCurrentPower()
        {

            currentProduction = this.maxEnergyProduction * this.utilizationPercentage /100;
           
        }

    }
}

