namespace Network
{
    class WindPS : PowerStationNode
    

    {

        public WindPS(int maxEnergyProduction, Fuel fuelType, Weather weather) : base(maxEnergyProduction, fuelType)
        {
            this.fuelType = fuelType;
            this.weatherIntensity= weather.windIntensity;

            this.sourceType["isFlexible"]= false;
            this.sourceType["isWeatherDependant"]= true;
            this.sourceType["isInfinite"]= false;
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
            this.weatherIntensity = weather.windIntensity;
            this.nodePower = this.maxEnergyProduction * this.weatherIntensity/100;
            //update();
        }

        public override void setEnergyProduction(float newEnergyQuantity)
        {
            if (newEnergyQuantity>= (this.maxEnergyProduction* this.weatherIntensity/100))
            {
                this.nodePower = this.maxEnergyProduction* this.weatherIntensity/100;
                this.nodeState = true;
            }
            else if (newEnergyQuantity <= 0)
            {
                this.nodePower =0;
                this.nodeState = false;
            }
            else
            {
                this.nodePower = newEnergyQuantity;
                this.nodeState = true;
            }  
            //update();          
        }



    }
}