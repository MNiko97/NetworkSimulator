namespace Network
{
    class WindPS : PowerStationNode
    

    {

        public WindPS(int maxEnergyProduction, Fuel fuelType) : base(maxEnergyProduction, fuelType)
        {
            this.fuelType = fuelType;
            this.flexibility = true;
            this.isWeatherDependent = true;
            this.currentProduction = this.maxEnergyProduction * this.weatherIntensity/100;
            //this.weatherIntensity= 100;
            
            
        }
        public void setWind(int windIntensity) //NEED To have an automatic update
        {
            this.weatherIntensity= windIntensity;
            this.currentProduction = this.maxEnergyProduction * this.weatherIntensity/100;
            update();
        }
        public void setCurrentPower()// NEED TO CHANGE
        {
            this.currentProduction = this.currentProduction * this.weatherIntensity/100;

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
        public override void setUpdate()
        {
            //setCurrentPower();
        }


    }
}