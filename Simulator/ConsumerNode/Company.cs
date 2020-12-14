using System;

namespace Network{

    class Company : ConsumerNode
    {
        public Company(int id) : base(id)
        {
        }

        public override void setPrice()
        {
            energyPrice = 10*energyQuantity;
            Console.WriteLine("Company paid "+energyPrice+" euros for "+energyQuantity+" KW");
        }
    }
}