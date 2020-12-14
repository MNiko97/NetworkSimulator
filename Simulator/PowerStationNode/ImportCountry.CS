namespace Network
{
    class ImportCountry : PowerStationNode
    {
        public ImportCountry(int maxEnergyProduction,Fuel fuelType): base(maxEnergyProduction,fuelType)
        {
            this.fuelType = fuelType;

        }
    }
}