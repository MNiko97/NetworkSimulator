using System;
namespace Network{
    class ExportCountry : ConsumerNode
    {
        public ExportCountry(float energyRequire):base( energyRequire){}
        public override void setPrice()
        {
            energyPrice = 25*energyRequire;
            Console.WriteLine("Foreign country paid "+energyPrice+" euros for "+energyRequire+" KW");
        }
    }
}
