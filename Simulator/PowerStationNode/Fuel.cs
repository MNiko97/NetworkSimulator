namespace Network
{
    class Fuel
    {
        public int costPerUnit;
        public int pollutionPerUnit;
        public int energyPerUnit;
        public Fuel(int costPerUnit, int pollutionPerUnit,int energyPerUnit)
        {
            this.costPerUnit = (costPerUnit>0)? costPerUnit:0;
            this.pollutionPerUnit = (pollutionPerUnit>0)? pollutionPerUnit:0;
            this.energyPerUnit = (energyPerUnit>0)? energyPerUnit:0;
        }
        public int getCost()
        {
            return this.costPerUnit;
        }
        public int getPollution()
        {
            return this.pollutionPerUnit;
        }
        public int getEnergy()
        {
            return this.energyPerUnit;
        }
        public void setCost(int newCost)
        {
            this.costPerUnit = (newCost>0)? newCost:0;
        }    
    }
}
