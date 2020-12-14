using System;

namespace Network{

    class Dissipator : ConsumerNode
    {
        public Dissipator(int id, int energyQuantity):base(id,energyQuantity)
        {
        }

        public override void setPrice(){
            energyPrice = 0;
            Console.WriteLine(energyQuantity+" KW were lost because of overproduction");
        }    
    }
}
