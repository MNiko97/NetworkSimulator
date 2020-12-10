namespace Network{

class ConsumerNode : Node
    {
    public int energyPrice;
    //public int energyQuantity;

    public ConsumerNode(int id, int energyPrice) : base (id)
    {
        this.energyPrice = energyPrice;
        //this.energyQuantity = energyQuantity;
    }
}
}