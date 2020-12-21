namespace Network
{
    class ImportCountry : PowerStationNode
    {
        public ImportCountry(int maxEnergyProduction,Fuel fuelType): base(maxEnergyProduction,fuelType)
        {
            this.fuelType = fuelType;
            this.nodeState = false;

        }
        public override void setEnergyProduction(float newEnergyQuantity)
        {
            
            if(newEnergyQuantity <=0) //asking to turn off
            {
                // nodeState = false;
                // nodePower = 0;
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