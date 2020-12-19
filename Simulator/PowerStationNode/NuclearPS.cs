using System;
using System.Threading;
using System.Threading.Tasks;
// using System.Timers;
namespace Network
{
    class NuclearPS : PowerStationNode 
    

    {
        public int changeStateDelay;
        public int changeStateCost;
        public bool isChanging;
        public int stationState;
    
        public NuclearPS(int maxEnergyProduction, Fuel fuelType) : base(maxEnergyProduction, fuelType)
        {
            this.fuelType = fuelType;
            this.flexibility = false;
            this.changeStateCost = 4000;
            this.changeStateDelay = 5000;
            this.isChanging = false;
            this.currentProduction = maxEnergyProduction;
            
            this.stationState = 1;

            
            
        }
        public override void setEnergyProduction(int newEnergyQuantity)
        {
            if(this.isChanging ==false) //if the station is NOT turning OFF or ON
            {
                if(newEnergyQuantity <=0) //asking to turn off
                {
                    if (this.nodeState) //if STATE TRUE  --> want to turn OFF
                    {
                        this.currentProduction = 0;
                        this.nodeState = false;

                        this.isChanging = true; //BLOCKING OTHER COMMANDS
                        this.stationState = 2; //turning off state
                    }
                    else //if STATE FALSE --> already OFF
                    {
                        this.currentProduction = 0;
                        this.nodeState = false;
                        
                        this.isChanging = false;
                        this.stationState = 3; //sleeping state
                    }
                    
                }
                else // asking to turn ON
                {
                    if (this.nodeState) // if STATE TRUE --> already ON
                    {
                        this.currentProduction = this.maxEnergyProduction;
                        this.nodeState = true;

                        this.isChanging = false;
                        this.stationState = 1; //running state
                    }
                    else //IF STATE OFF --> want to start
                    {
                        this.currentProduction = 0;
                        this.nodeState = false;

                        this.isChanging = true;
                        this.stationState = 4; //turning on state
                    }
                }
            }
            else //when changing a state
            {
                this.currentProduction = 0; // always 0 
                this.nodeState = false; //always not providing
            }
            
            update();
        }
        public override void setCurrentCost()
        {
            switch (this.stationState)
            {
                case 1: //Running
                    Console.WriteLine("CASE 1");

                    this.nodeState = true;
                    this.isChanging = false;

                    this.currentProduction = this.maxEnergyProduction;
                    currentCost = this.fuelType.getCost() * this.currentProduction / fuelType.getEnergy();
                    
                    break;

                case 2 : //stopping
                    Console.WriteLine("CASE 2");



                    currentCost = this.changeStateCost;

                    Task.Delay(this.changeStateDelay).ContinueWith(t=>this.stationState = 3);

                    break;
                    
                case 3 : // sleeping
                    Console.WriteLine("CASE 3");

                    currentCost = 0;
                    this.isChanging = false;

                    
                    break;

                case 4: //starting
                    Console.WriteLine("CASE 4");

                    currentCost = this.changeStateCost;

                    Task.Delay(this.changeStateDelay).ContinueWith(t=>this.stationState = 1);
                    break;

                default : 
                    this.stationState = 1;
                    Console.WriteLine("Station state ERROR");
                    break;

            }
        }
        


        
        

        
        
    }
}