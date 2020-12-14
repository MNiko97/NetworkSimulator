using System;
using System.Threading;

namespace Network
{
    class NuclearPS : PowerStationNode 
    

    {
        public int changeStateDelay;
        public int changeStateCost;
        public bool isChangingState;
    
        public NuclearPS(int maxEnergyProduction, Fuel fuelType) : base(maxEnergyProduction, fuelType)
        {
            this.fuelType = fuelType;
            this.flexibility = false;
            this.changeStateCost = 4000;
            this.changeStateDelay = 1000;
            this.isChangingState = false;


        }
        public override void setCurrentCost()
        {
            if (this.isProviding == false)
            {
                //ordered it to stop
                
                this.isChangingState = true;
                changeRunningState();
                
            }
            else
            {
                if(this.isChangingState)
                {
                    CurrentCost = 0;
                    currentProduction =0;
                    currentPollution = 0;
                }
                else
                {
                    CurrentCost = this.fuelType.getCost() * currentProduction / fuelType.getEnergy();
                }
                
                
            }
        }
        public void changeRunningState()
        {
            CurrentCost = this.changeStateCost;
            int i = 0;
            while(i<this.changeStateDelay)
            {
                i ++;
            }
            this.isChangingState = false;

        }
        

        
        
    }
}