namespace Network
{
    class ImportCountry : PowerStationNode
    {
        public ImportCountry(int id, int maxEnergyProduction,Fuel fuelType): base(id, maxEnergyProduction,fuelType)
        {
            this.fuelType = fuelType;

        }
    }
}