namespace Network
{
    class SolarPS : PowerStationNode
    

    {

        public SolarPS(int id, int maxEnergyProduction, Fuel fuelType) : base(id,maxEnergyProduction, fuelType)
        {
            this.fuelType = fuelType;
            this.flexibility = false;
            this.isWeatherDependent = true;
            this.weatherIntensity= Weather.solarIntensity;
        }


    }
}