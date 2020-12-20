using System;

namespace Network{

    class ExportCountry : ConsumerNode
    {
        public ExportCountry(int powerDemand):base( powerDemand)
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