using System;

namespace Network{

    class Company : ConsumerNode
    {
        public Company(float energyRequire) : base(energyRequire)
        {
        }

        public override void setPrice()
        {
            energyPrice = 10*energyRequire;
            Console.WriteLine("Company paid "+energyPrice+" euros for "+energyRequire+" KW");
        }
        public override string ToString(){
            return "Company N" + id.ToString();
        }
    }
}