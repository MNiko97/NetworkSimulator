using System;
using System.Collections.Generic;

namespace Network{

    abstract class ConsumerNode : Node
    {
        public float energyPrice;
        public float energyQuantity;
        public bool isConnectedToLine;
        public List<Line> connexionLine;

        public ConsumerNode() : base ()
        {
            this.energyQuantity = 0;
            this.isConnectedToLine = false;
            this.connexionLine = new List<Line>();
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
            if(isConnectedToLine){
                energyQuantity -= connexionLine[0].getLinePower();
            }
        }
        public override void connect(Line line)
        {
            if(!isConnectedToLine){
                connexionLine.Add(line);
                isConnectedToLine = true;
                line.addNode(this);
            }else{
                Console.WriteLine("Node N", id, " is already connected");
            }
        }
    }
}