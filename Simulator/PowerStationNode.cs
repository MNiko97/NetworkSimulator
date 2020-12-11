using System;
namespace Network
{
    class PowerStationNode : Node
    {

        public string flexibility;
        public int maxEnergyProduction;
        public int utilizationPercentage = 100; 
        public float CurrentCost ;
        public float currentPollution;      
        public float currentProduction; 
        public Fuel fuelType;
        //public bool nodeState;


        public PowerStationNode(int id, int maxEnergyProduction, Fuel fuelType): base(id)
        {
            this.maxEnergyProduction = maxEnergyProduction;

            this.fuelType = fuelType;
            setUpdate();

        }
        public void setUtilizationPercentage(int newPercentage)
        {
            utilizationPercentage = newPercentage;
            setUpdate();
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
        public void setUpdate()
        {
            setCurrentPower();
            setCurrentPollution();
            setCurrentCost();
   

        }

    }
}

