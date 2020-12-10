namespace Network
{
    class Gas : PowerStationNode
    

    {
        int maxEnergyProduction;
        int utilizationPercentage;
        float currentEnergyProduction;


        public Gas(int id, int maxEnergyProduction, int utilizationPercentage) : base(id)
        {
            this.maxEnergyProduction = maxEnergyProduction;
            this.utilizationPercentage = utilizationPercentage;
        }
        public float getCurrentPower()
        {
            currentEnergyProduction = this.maxEnergyProduction * this.utilizationPercentage /100;
            return currentEnergyProduction;
        }

    }
}