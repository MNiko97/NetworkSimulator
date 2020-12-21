using System;
namespace Network
{
    class SolarPS : PowerStationNode
    

    {

        public SolarPS(int maxEnergyProduction, Fuel fuelType, Weather weather) : base(maxEnergyProduction, fuelType)
        {
            this.fuelType = fuelType;
            //this.isFlexible = false;
            // this.isWeatherDependent = true;
            this.weatherIntensity= weather.solarIntensity;
            this.nodePower = this.maxEnergyProduction * this.weatherIntensity/100;

            this.sourceType["isFlexible"]= false;
            this.sourceType["isWeatherDependant"]= true;
            this.sourceType["isInfinite"]= false;
        }

        public void setUpdateWeather(Weather weather) //If we want to test with another weather intensity
        {
            this.weatherIntensity = weather.solarIntensity;
            this.nodePower = this.maxEnergyProduction * this.weatherIntensity/100;
            update();
        }


        public override void setEnergyProduction(float newEnergyQuantity)
        {
            // base.setEnergyProduction(newEnergyQuantity);
            if (newEnergyQuantity>0)
            {
                this.nodePower = this.maxEnergyProduction* this.weatherIntensity/100;
                this.nodeState = true;
            }
            else 
            {
                // Console.WriteLine("New energy quantity ="+newEnergyQuantity);
                this.nodePower =0;
                this.nodeState = false;
            }
            
            update();          
        }


    }
}