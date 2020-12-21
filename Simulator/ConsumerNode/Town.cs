using System;

namespace Network{

    class Town : ConsumerNode
    {
        public Town(float energyRequire) : base( energyRequire)
        {

        }

        public override void setPrice(){
            
            energyPrice = 10*energyRequire;
            Console.WriteLine("Town paid "+energyPrice+" euros for "+energyRequire+" KW");
        }
        // public override string ToString(){
        //     return "Town N" + id.ToString();
        // }
    }
}