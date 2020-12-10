namespace Network
{
    class PowerStationNode : Node
    {
        public int productionCost ;
        public int pollutionProduction;
        public string flexibility;
        public Fuel fuelType;

        public PowerStationNode(int id): base(id){
            

        }
        

        public int getProductionCost()
        {
            productionCost = this.fuelType.getCost() * 3;
            return productionCost ;
        }

    }
}

