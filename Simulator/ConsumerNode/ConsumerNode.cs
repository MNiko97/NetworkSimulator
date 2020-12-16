using System;
using System.Collections.Generic;

namespace Network{

    abstract class ConsumerNode : Node
    {
        public int energyPrice;
        public int energyQuantity;
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
            //to implement
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