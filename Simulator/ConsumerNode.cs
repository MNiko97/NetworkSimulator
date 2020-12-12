using System;

namespace Network{

    class ConsumerNode : Node
    {
        public int energyPrice;
        public int energyQuantity;

        public ConsumerNode(int id, int energyQuantity) : base (id)
        {
            this.energyQuantity = energyQuantity;
        }

        public virtual void setPrice(){
            energyPrice = this.energyQuantity;
        }
    }
}