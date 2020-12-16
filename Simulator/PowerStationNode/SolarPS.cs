namespace Network
{
    class SolarPS : PowerStationNode
    

    {

        public SolarPS(int maxEnergyProduction, Fuel fuelType) : base(maxEnergyProduction, fuelType)
        {
            this.fuelType = fuelType;
            this.flexibility = false;
            this.isWeatherDependent = true;
            //this.weatherIntensity= 0;
            //update();
            this.currentProduction = this.maxEnergyProduction * this.weatherIntensity/100;
        }
        public void setSolar(int solarIntensity) //NEED To have an automatic update
        {
            this.weatherIntensity= solarIntensity;
            this.currentProduction = this.maxEnergyProduction * this.weatherIntensity/100;
            update();
        }
        public void setCurrentPower() // NEED TO CHANGE
        {
            this.currentProduction = this.maxEnergyProduction * this.weatherIntensity/100;

        }
        public override void setUpdate()
        {
            //setCurrentPower();
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
                this.currentProduction = this.maxEnergyProduction * this.weatherIntensity/100;
                this.isProviding = true;
            }  
            update();          
        }


    }
}