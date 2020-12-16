using System;

namespace Network{

    class ExportCountry : ConsumerNode
    {
        public ExportCountry():base()
        {
        }
        public override string ToString(){
            return "External Source N" + id.ToString();
        }
        public override void setPrice()
        {
            energyPrice = 25*energyQuantity;
            Console.WriteLine("Foreign country paid "+energyPrice+" euros for "+energyQuantity+" KW");
        }
    }
}