using System;

namespace Network{

    class ExportCountry : ConsumerNode
    {
        public ExportCountry(int id, int energyQuantity):base(id, energyQuantity)
        {
        }

        public override void setPrice()
        {
            energyPrice = 25*energyQuantity;
            Console.WriteLine("Foreign country paid "+energyPrice+" euros for "+energyQuantity+" KW");
        }
    }
}