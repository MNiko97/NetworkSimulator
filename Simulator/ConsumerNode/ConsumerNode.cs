using System;
using System.Collections.Generic;

namespace Network{

    class ConsumerNode : Node
    {
        public int energyPrice;
        public int energyQuantity;

        public ConsumerNode(int id) : base (id)
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