using System;

namespace Network{

    class ExportCountry : ConsumerNode
    {
        public ExportCountry(int id):base(id)
        {
        }

        public override void setPrice()
        {
            energyPrice = 25*energyQuantity;
            Console.WriteLine("Foreign country paid "+energyPrice+" euros for "+energyQuantity+" KW");
        }
    }
}