using System;
using System.Collections.Generic;

namespace Network{

    abstract class ConsumerNode : Node
    {
        public int energyPrice;
        public int energyQuantity;

        public ConsumerNode() : base ()
        {
            this.energyQuantity = 0;
        }

        public override List<string> getAlert()
        {
            throw new NotImplementedException();
        }
    
        public virtual void setPrice(){
            energyPrice = this.energyQuantity;
        }

        public override void update()
        {
            throw new NotImplementedException();
        }
    }
}