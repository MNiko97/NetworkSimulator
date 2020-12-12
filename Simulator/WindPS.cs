namespace Network
{
    class WindPS : PowerStationNode
    

    {

        public WindPS(int id, int maxEnergyProduction, Fuel fuelType) : base(id,maxEnergyProduction, fuelType)
        {
            this.fuelType = fuelType;
            this.flexibility = true;
            this.isWeatherDependent = true;
            this.weatherIntensity= Weather.windIntensity;
        }


    }
}