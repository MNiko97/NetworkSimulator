using System;

namespace Network{

    class Town : ConsumerNode
    {
        public Town(int id, int energyQuantity) : base(id, energyQuantity)
        {
        }
        
        public override void setPrice(){
            energyPrice = 10*energyQuantity;
            Console.WriteLine("Town paid "+energyPrice+" euros for "+energyQuantity+" KW");
        }
    }



}