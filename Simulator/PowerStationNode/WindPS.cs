namespace Network
{
    class WindPS : PowerStationNode
    

    {

        public WindPS(int maxEnergyProduction, Fuel fuelType, Weather weather) : base(maxEnergyProduction, fuelType)
        {
            this.fuelType = fuelType;
            this.isWeatherDependent = true;
            this.weatherIntensity= weather.solarIntensity;
            this.currentProduction = this.maxEnergyProduction * this.weatherIntensity/100;

            
            
        }
        
        public void setUpdateWeather(Weather weather) //If we want to test with another weather intensity
        {
            this.weatherIntensity = weather.windIntensity;
            this.currentProduction = this.maxEnergyProduction * this.weatherIntensity/100;
            update();
        }

        public override void setEnergyProduction(int newEnergyQuantity)
        {
            // base.setEnergyProduction(newEnergyQuantity);
            if (newEnergyQuantity>= (this.maxEnergyProduction* this.weatherIntensity/100))
            {
                this.currentProduction = this.maxEnergyProduction* this.weatherIntensity/100;
                this.isProviding = true;
            }
            else if (newEnergyQuantity <= 0)
            {
                this.currentProduction =0;
                this.isProviding = false;
            }
            else
            {
                this.currentProduction = newEnergyQuantity;
                this.isProviding = true;
            }  
            update();          
        }



    }
}