namespace Network
{
    class GasPS : PowerStationNode
    

    {

        public GasPS(int id, int maxEnergyProduction, Fuel fuelType) : base(id,maxEnergyProduction, fuelType)
        {
            this.fuelType = fuelType;
        }

    }
}