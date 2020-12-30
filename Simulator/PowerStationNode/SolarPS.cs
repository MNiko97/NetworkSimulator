using System;
namespace Network
{
    class SolarPS : PowerStationNode
    {
        public SolarPS(int maxEnergyProduction, Fuel fuelType, Weather weather) : base(maxEnergyProduction, fuelType)
        {
            this.fuelType = fuelType;
            this.sourceType["isFlexible"]= false;
            this.sourceType["isWeatherDependant"]= true;
            this.sourceType["isInfinite"]= false;
            if(weather.solarIntensity>=100)
            {
                this.weatherIntensity= 100;
            }
            else if(weather.solarIntensity<=0)
            {
                this.weatherIntensity= 0;
            }
            else
            {
                this.weatherIntensity= weather.solarIntensity;
            }
            if(maxEnergyProduction>=0)
            {
                this.nodePower = maxEnergyProduction * this.weatherIntensity/100;
            }
            else
            {
                this.nodePower = 0;
            }  
        }
        public void setUpdateWeather(Weather weather) //If we want to test with another weather intensity
        {
            this.weatherIntensity = weather.solarIntensity;
            this.nodePower = this.maxEnergyProduction * this.weatherIntensity/100;
        }
        public override void setEnergyProduction(float newEnergyQuantity)
        {
            if (newEnergyQuantity>0)
            {
                this.nodePower = this.maxEnergyProduction* this.weatherIntensity/100;
                this.nodeState = true;
            }
            else 
            {
                this.nodePower =0;
                this.nodeState = false;
            }        
        }
    }
}