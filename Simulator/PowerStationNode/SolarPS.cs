namespace Network
{
    class SolarPS : PowerStationNode
    

    {

        public SolarPS(int id, int maxEnergyProduction, Fuel fuelType) : base(id,maxEnergyProduction, fuelType)
        {
            this.fuelType = fuelType;
            this.flexibility = false;
            this.isWeatherDependent = true;
            //this.weatherIntensity= 0;
            
        }
        public void setSolar(int solarIntensity)
        {
            this.weatherIntensity= solarIntensity;
        }


    }
}