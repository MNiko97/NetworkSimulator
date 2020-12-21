namespace Network
{
    class GasPS : PowerStationNode
    

    {

        public GasPS(int maxEnergyProduction, Fuel fuelType) : base(maxEnergyProduction, fuelType)
        {
            this.fuelType = fuelType;
            this.sourceType["isFlexible"]= true;
            this.sourceType["isWeatherDependant"]= false;
            this.sourceType["isInfinite"]= false;
        }

    }
}