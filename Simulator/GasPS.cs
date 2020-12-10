namespace Network
{
    class GasPS : PowerStationNode
    

    {

        public GasPS(int id, int maxEnergyProduction, int utilizationPercentage, Fuel fuelType) : base(id, maxEnergyProduction, utilizationPercentage, fuelType)
        {
            this.fuelType = fuelType;
        }

    }
}