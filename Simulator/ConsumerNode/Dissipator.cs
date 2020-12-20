using System;

namespace Network{

    class Dissipator : ConsumerNode
    {
        public Dissipator(float energyRequire):base(energyRequire)
        {
        }

        public override void setPrice(){
            energyPrice = 0;
            Console.WriteLine(energyRequire+" KW were lost because of overproduction");
        }    
        public override string ToString(){
            return "Disspator N" + id.ToString();
        }
    }
}
