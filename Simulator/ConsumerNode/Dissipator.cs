using System;
namespace Network{
    class Dissipator : ConsumerNode
    {
        public Dissipator(float energyRequire):base(energyRequire)
        {
            this.isPrioritized = false;
        }
        public override void setPrice()
        {
            energyPrice = 0;
            Console.WriteLine(energyRequire+" KW were lost because of overproduction");
        }
    }
}
