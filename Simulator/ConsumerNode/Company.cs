using System;

namespace Network{

    class Company : ConsumerNode
    {
        public Company() : base()
        {
        }

        public override void connect(Line line)
        {
            throw new NotImplementedException();
        }

        public override void setPrice()
        {
            energyPrice = 10*energyQuantity;
            Console.WriteLine("Company paid "+energyPrice+" euros for "+energyQuantity+" KW");
        }
        public override string ToString(){
            return "Company N" + id.ToString();
        }
    }
}