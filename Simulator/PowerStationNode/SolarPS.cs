using System;
namespace Network
{
    class SolarPS : PowerStationNode
    

    {

        public SolarPS(int maxEnergyProduction, Fuel fuelType, Weather weather) : base(maxEnergyProduction, fuelType)
        {
            this.fuelType = fuelType;
            this.flexibility = false;
            this.isWeatherDependent = true;
            this.weatherIntensity= weather.solarIntensity;
            this.currentProduction = this.maxEnergyProduction * this.weatherIntensity/100;
        }

        public void setUpdateWeather(Weather weather) //If we want to test with another weather intensity
        {
            this.weatherIntensity = weather.solarIntensity;
            this.currentProduction = this.maxEnergyProduction * this.weatherIntensity/100;
            update();
        }


        public override void setEnergyProduction(int newEnergyQuantity)
        {
            // base.setEnergyProduction(newEnergyQuantity);
            if (newEnergyQuantity>0)
            {
                this.currentProduction = this.maxEnergyProduction* this.weatherIntensity/100;
                this.nodeState = true;
            }
            else 
            {
                // Console.WriteLine("New energy quantity ="+newEnergyQuantity);
                this.currentProduction =0;
                this.nodeState = false;
            }
            
            update();          
        }


    }
}