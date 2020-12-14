using System;

namespace Network{

    class ConsumerNode : Node
    {
        public int energyPrice;
        public int energyQuantity;

        public ConsumerNode(int id) : base (id)
        {
            this.energyQuantity = 0;
        }

        public virtual void setPrice(){
            energyPrice = this.energyQuantity;
        }
    }
}