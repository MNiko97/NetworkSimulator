using System;
using System.Collections.Generic;

namespace Network{

    abstract class ConsumerNode : Node
    {
        public float energyPrice;
        public float energyRequire;
        public List<Line> connexionLine;
        public bool isPrioritized;

        public ConsumerNode(float energyRequire) : base ()
        {
            this.nodePower = 0;        
            this.connexionLine = new List<Line>();
            if (energyRequire<=0)
            {
                this.energyRequire = 0;
                this.isPrioritized = true;
            }
            else
            {
                this.energyRequire = energyRequire;
            }
        }

        public override List<string> getAlert()
        {
            throw new NotImplementedException();
        }
    
        public virtual void setPrice(){
            //
        }
        public void setNewRequirement(float energy)
        {
            if (energy<=0)
            {
                this.energyRequire = 0;
            }
            else
            {
                this.energyRequire = energy;
            }
        }
        public void changeRequirement(){
            Random energy = new Random();
            float min = energyRequire - (energyRequire*20/100);
            float max = energyRequire + (energyRequire*20/100); 
            energyRequire = energy.Next(Convert.ToInt32(min), Convert.ToInt32(max));
        }
        public override void update()
        { 
            if(isConnected && nodeState){
                connexionLine[0].update();
                nodePower = connexionLine[0].getLinePower();
                float power = connexionLine[0].getLinePower();
                if(energyRequire - power < 0){
                    nodeState = false;
                    Console.WriteLine("Too much power in " + this + " OVERFLOW");
                    Console.WriteLine("Asked: " + energyRequire.ToString() + " Received: " + power.ToString());
                    //throw new Exception();
                }
                
            }
            if(isConnected && !nodeState){
                nodePower = 0;
                energyRequire = 0;
            }
        }
        public override void connect(Line line)
        {
            if(!isConnected){
                connexionLine.Add(line);
                isConnected = true;
                nodeState = true;
                line.addNode(this);
            }else{
                Console.WriteLine("Node N", id, " is already connected");
            }
        }
        public override string ToString(){
            return "Consumer N" + id.ToString();
        }
    }
}