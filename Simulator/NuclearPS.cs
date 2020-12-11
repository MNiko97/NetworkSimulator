namespace Network
{
    class NuclearPS : PowerStationNode 
    

    {
        public int changeStateDelay = 100;
        public int changeStateCost = 400;
        public NuclearPS(int id, int maxEnergyProduction, Fuel fuelType) : base(id,maxEnergyProduction, fuelType)
        {
            this.fuelType = fuelType;

        }
        
    }
}