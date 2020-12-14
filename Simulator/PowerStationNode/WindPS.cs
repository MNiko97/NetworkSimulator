namespace Network
{
    class WindPS : PowerStationNode
    

    {

        public WindPS(int maxEnergyProduction, Fuel fuelType) : base(maxEnergyProduction, fuelType)
        {
            this.fuelType = fuelType;
            this.flexibility = true;
            this.isWeatherDependent = true;
            //this.weatherIntensity= 100;
        }
        public void setWind(int windIntensity)
        {
            this.weatherIntensity= windIntensity;
        }


    }
}