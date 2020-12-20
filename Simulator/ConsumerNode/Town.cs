using System;

namespace Network{

    class Town : ConsumerNode
    {
        public Town(int powerDemand) : base( powerDemand)
        {
            energyQuantity = 10000;  
        }

        public override void setPrice(){
            
            energyPrice = 10*energyQuantity;
            Console.WriteLine("Town paid "+energyPrice+" euros for "+energyQuantity+" KW");
        }
        public override string ToString(){
            return "Town N" + id.ToString() + " Asking "+ energyQuantity + "MW";
        }
    }
}