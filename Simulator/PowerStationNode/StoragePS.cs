namespace Network
{
    class StoragePS : PowerStationNode
    

    {

        public StoragePS(int maxEnergyProduction, Fuel fuelType) : base(maxEnergyProduction, fuelType)
        {
            this.fuelType = fuelType;
            this.sourceType["isFlexible"]= true;
            this.sourceType["isWeatherDependant"]= false;
            this.sourceType["isInfinite"]= false;
        }
        public override void setEnergyProduction(float newEnergyQuantity)
        {
            if(newEnergyQuantity =0) //asking to turn off
            {
                this.nodePower = 0;
                this.nodeState = false;
            }
            else //newEnergyQuantity >0 : we produce energy AND if newEnergyQuantity<0 : we want to store it
            {
                if (newEnergyQuantity>=this.maxEnergyProduction) 
                {
                    this.nodePower = this.maxEnergyProduction;
                }
                else if(newEnergyQuantity<= - this.maxEnergyProduction) 
                {
                    this.nodePower = - this.maxEnergyProduction;
                }
                else
                {
                    this.nodePower = newEnergyQuantity;
                }
                this.nodeState = true;
            }
        }

    }
}