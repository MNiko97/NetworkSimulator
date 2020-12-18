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
        public bool isChangingState;
        public bool isOn;
    
        public NuclearPS(int maxEnergyProduction, Fuel fuelType) : base(maxEnergyProduction, fuelType)
        {
            this.fuelType = fuelType;
            this.flexibility = false;
            this.changeStateCost = 4000;
            this.changeStateDelay = 1000;
            this.isChangingState = false;
            this.isOn= true;

        }


        public void turningOff()
        {
            this.isChangingState = false;
            Console.WriteLine("The power station is now off.");
            update();
        }
        public void turningOn()
        {
            this.isChangingState = false;
            this.isOn =true;
            Console.WriteLine("The Power station is now operational");
            update();
        }


        public override void setCurrentCost()
        {
            if (this.isProviding == false)
            {
                if(this.isChangingState) //while it's changing state it can't run
                {
                    CurrentCost = 0;
                    currentProduction =0;
                    currentPollution = 0;
                    //this.isProviding = false; maybe useless
                    Console.WriteLine("Couldn't turn OFF the Power Station while on turn-on or turn-off. Please wait.");
                }
                else
                {
                    if(this.isOn ==true)//was running and ordered it to stop
                    {
                        this.isOn =false;
                        this.isChangingState = true;
                        this.CurrentCost = this.changeStateCost;

                        Console.WriteLine("Turning off the Power Station. Please wait...");
                        Task.Delay(5000).ContinueWith(t=> turningOff());
                        
                    }
                    else //if is not and we dind't change anything then cost = 0
                    {
                        this.CurrentCost = 0;
                        Console.WriteLine("Turning off the Power Station while already off. Nothing changed.");
                    }
                }
                     
            }
            else    //requiring to provide
            {
                if(this.isChangingState) //while it's changing state it can't run
                {
                    CurrentCost = 0;
                    currentProduction =0;
                    currentPollution = 0;
                    //this.isProviding = false; maybe useless
                    Console.WriteLine("Couldn't turn ON the Power Station while on turn-on or turn-off. Please wait.");
                }
                else
                {
                    if(this.isOn ==false) //if we asked to start when it was off
                    {
                        this.isChangingState = true;
                        this.CurrentCost = this.changeStateCost;
                        
                        Console.WriteLine("Turning on the Power Station. Please wait...");
                        Task.Delay(5000).ContinueWith(t=> turningOn());
                    }
                    
                    else //if not blocked
                    {
                        CurrentCost = this.fuelType.getCost() * currentProduction / fuelType.getEnergy();
                    }
                }
                
                
                
            }
        }
        public void changeState()
        {
            CurrentCost = this.changeStateCost;
            if(this.isProviding)
            {
                this.isProviding = false;
            }
            else
            {
                this.isProviding = true;
            }

        }
        
        
        

        // public void testTimer()
        // {
        //     var timerState = new TimerState { Counter = 0 };

        //     timer = new Timer(
        //         callback: new TimerCallback(TimerTask),
        //         state: timerState,
        //         dueTime: 4000,
        //         period: 2000);

        //     while (timerState.Counter <= 10)
        //     {
        //         Task.Delay(1000).Wait();
        //     }

        //     timer.Dispose();
        //     Console.WriteLine($"{DateTime.Now:HH:mm:ss.fff}: done.");
        // }
        // private static void TimerTask(object timerState)
        // {
        //     Console.WriteLine($"{DateTime.Now:HH:mm:ss.fff}: starting a new callback.");
        //     var state = timerState as TimerState;
        //     Interlocked.Increment(ref state.Counter);
        // }

        // class TimerState
        // {
        //     public int Counter;
        // }
        // public void SetTimer()
        // {
        //     // Create a timer with one second interval.
        //     changeStateTimer = new System.Timers.Timer(1000);
            
        //     // Hook up the Elapsed event for the timer. 
        //     changeStateTimer.Elapsed += OnTimedEvent;
        //     // Have the timer fire repeated events (true is the default)
        //     changeStateTimer.AutoReset = true;
        //     // Start the timer
        //     changeStateTimer.Enabled = true;

            
        // }

        // private static void OnTimedEvent(Object source, ElapsedEventArgs e)
        // {
        //     Console.WriteLine("Current time: {0:HH:mm:ss.fff}", e.SignalTime);
        // }
        

        
        
    }
}