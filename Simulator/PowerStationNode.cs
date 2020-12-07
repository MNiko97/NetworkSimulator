namespace Network
{
    class PowerStationNode : Node
    {
        public int productionCost ;
        public int pollutionProduction;
        public string flexibility;
        public bool state;
        public Fuel fuelType;
        //maybe change this
        //create the constructor
        public PowerStationNode(int id){
            this.id = id;
            // compléter et corriger
        }
        public void setEnergyProduction(int energyProduction)
        {

        }
        public void setState(bool state)
        {

        }
        public string getFlexibility()
        {
            return ""; //to modify
        }

    }
}

