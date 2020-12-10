namespace Network
{
    class PowerStationNode : Node
    {
        public int productionCost ;
        public int pollutionProduction;
        public string flexibility;
        public Fuel fuelType;

        public PowerStationNode(int id, Fuel fuelType, int productionCost, int pollutionProduction, string flexibility): base(id){
            this.fuelType = fuelType;
            this.productionCost = productionCost;
            this.pollutionProduction = pollutionProduction;
            this.flexibility = flexibility;
        }
        public void setEnergyProduction(int energyProduction)
        {

        }
        public void setState(bool state)
        {

        }
        public string getFlexibility()
        {
            return this.flexibility;
        }
        public Fuel getFuel()
        {
            return this.fuelType;
        }

    }
}

