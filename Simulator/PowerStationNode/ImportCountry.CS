namespace Network
{
    class ImportCountry : PowerStationNode
    {
        public ImportCountry(int maxEnergyProduction,Fuel fuelType): base(maxEnergyProduction,fuelType)
        {
            this.fuelType = fuelType;
            this.sourceType["isFlexible"]= true;
            this.sourceType["isWeatherDependant"]= false;
            this.sourceType["isInfinite"]= true;

        }
        public override void setEnergyProduction(float newEnergyQuantity)
        {
            
            if(newEnergyQuantity <=0) //asking to turn off
            {
                this.nodePower = 0;
                this.nodeState = false;
            }
            else
            {
                this.nodePower = newEnergyQuantity;
                this.nodeState = true;
            }
             
        }

        
    }
}