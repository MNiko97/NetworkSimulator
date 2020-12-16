using System;

namespace Network{

    class Dissipator : ConsumerNode
    {
        public Dissipator():base()
        {
        }

        public override void connect(Line line)
        {
            throw new NotImplementedException();
        }

        public override void setPrice(){
            energyPrice = 0;
            Console.WriteLine(energyQuantity+" KW were lost because of overproduction");
        }    
        public override string ToString(){
            return "Disspator N" + id.ToString();
        }
    }
}
