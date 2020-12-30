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
        public bool hasAppliedFee ;
        public NuclearPS(int maxEnergyProduction, Fuel fuelType) : base(maxEnergyProduction, fuelType)
        {
            this.fuelType = fuelType;
            this.changingCost = 69420;
            this.changingDelay = 2000;
            this.isChanging = false;
            this.changingState = 1;
            this.sourceType["isFlexible"]= false;
            this.sourceType["isWeatherDependant"]= false;
            this.sourceType["isInfinite"]= false;
            hasAppliedFee = false;
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
        }
        public override void stop()
        {
            if(this.isChanging ==false)
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
        }
        public override void setCurrentCost()
        {
            string mess="";
            switch (this.changingState)
            {
                case 1: //Running
                    mess = "The Nuclear power Plant : "+id+" is running";
                    this.nodeState = true;
                    this.isChanging = false;
                    hasAppliedFee =false;
                    this.nodePower = this.maxEnergyProduction;
                    currentCost = this.fuelType.getCost() * this.nodePower / fuelType.getEnergy();
                    break;
                case 2 : //stopping
                    mess = "The Nuclear power Plant : "+id+" is stopping";
                    if(hasAppliedFee == false)
                    {
                        currentCost = this.changingCost;
                        hasAppliedFee = true;
                    }
                    else
                    {
                        currentCost=0;
                    }
                    Task.Delay(this.changingDelay).ContinueWith(t=>this.changingState = 3).ContinueWith(t=>hasAppliedFee = false);
                    break;
                case 3 : // sleeping
                    mess = "The Nuclear power Plant : "+id+" is sleeping";
                    currentCost = 0;
                    this.isChanging = false;
                    break;

                case 4: //starting
                    mess = "The Nuclear power Plant : "+id+" is starting";
                    if(hasAppliedFee== false)
                    {
                        currentCost = this.changingCost;
                        hasAppliedFee = true;
                    }
                    else
                    {
                        currentCost=0;
                    }
                    Task.Delay(this.changingDelay).ContinueWith(t=>this.changingState = 1).ContinueWith(t=>hasAppliedFee = false);
                    break;
                default : 
                    this.changingState = 1;
                    hasAppliedFee = false;
                    mess = "The Nuclear power Plant : "+id+" has an error";
                    break;
            }
            Console.WriteLine(mess);
        }
              
        
    }
}