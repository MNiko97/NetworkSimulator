namespace Network
{
    class GasPS : PowerStationNode
    

    {

        public GasPS(int maxEnergyProduction, Fuel fuelType) : base(maxEnergyProduction, fuelType)
        {
            this.fuelType = fuelType;
            nodePower = maxEnergyProduction;
        }

    }
}