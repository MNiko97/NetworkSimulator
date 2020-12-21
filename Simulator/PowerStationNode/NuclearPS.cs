using System;
using System.Threading.Tasks;

namespace Network
{
    class NuclearPS : PowerStationNode 
    

    {
        public int changingDelay;
        public int changingCost;
        public int changingState;
        public bool isChanging;
        
    
        public NuclearPS(int maxEnergyProduction, Fuel fuelType) : base(maxEnergyProduction, fuelType)
        {
            this.fuelType = fuelType;
            //this.isFlexible = false;
            this.changingCost = 4000;
            this.changingDelay = 5000;
            this.isChanging = false;
            this.nodePower = maxEnergyProduction;
            
            this.changingState = 1;
            this.sourceType["isFlexible"]= false;
            this.sourceType["isWeatherDependant"]= false;
            this.sourceType["isInfinite"]= false;

            
            
        }
        public override void setEnergyProduction(float newEnergyQuantity)
        {
            if(this.isChanging ==false) //if the station is NOT turning OFF or ON
            {
                if(newEnergyQuantity <=0) //asking to turn off
                {
                    if (this.nodeState) //if STATE TRUE  --> want to turn OFF
                    {
                        this.nodePower = 0;
                        this.nodeState = false;

                        this.isChanging = true; //BLOCKING OTHER COMMANDS
                        this.changingState = 2; //turning off state
                    }
                    else //if STATE FALSE --> already OFF
                    {
                        this.nodePower = 0;
                        this.nodeState = false;
                        
                        this.isChanging = false;
                        this.changingState = 3; //sleeping state
                    }
                    
                }
                else // asking to turn ON
                {
                    if (this.nodeState) // if STATE TRUE --> already ON
                    {
                        this.nodePower = this.maxEnergyProduction;
                        this.nodeState = true;

                        this.isChanging = false;
                        this.changingState = 1; //running state
                    }
                    else //IF STATE OFF --> want to start
                    {
                        this.nodePower = 0;
                        this.nodeState = false;

                        this.isChanging = true;
                        this.changingState = 4; //turning on state
                    }
                }
            }
            else //when changing a state
            {
                this.nodePower = 0; // always 0 
                this.nodeState = false; //always not providing
            }
            
            update();
        }
        public override void setCurrentCost()
        {
            switch (this.changingState)
            {
                case 1: //Running
                    //Console.WriteLine("CASE 1");

                    this.nodeState = true;
                    this.isChanging = false;

                    this.nodePower = this.maxEnergyProduction;
                    currentCost = this.fuelType.getCost() * this.nodePower / fuelType.getEnergy();
                    
                    break;

                case 2 : //stopping
                    //Console.WriteLine("CASE 2");

                    currentCost = this.changingCost;

                    Task.Delay(this.changingDelay).ContinueWith(t=>this.changingState = 3);

                    break;
                    
                case 3 : // sleeping
                    //Console.WriteLine("CASE 3");

                    currentCost = 0;
                    this.isChanging = false;

                    
                    break;

                case 4: //starting
                    //Console.WriteLine("CASE 4");

                    currentCost = this.changingCost;

                    Task.Delay(this.changingDelay).ContinueWith(t=>this.changingState = 1);
                    break;

                default : 
                    this.changingState = 1;
                    Console.WriteLine("Station state ERROR");
                    break;

            }
        }
              
        
    }
}