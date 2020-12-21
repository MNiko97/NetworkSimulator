using System;
using System.Collections.Generic;

namespace Network{

    abstract class ConsumerNode : Node
    {
        public float energyPrice;
        public float energyRequire;
        public List<Line> connexionLine;

        public ConsumerNode(float energyRequire) : base ()
        {
            this.nodePower = 0;        
            this.connexionLine = new List<Line>();
            if (energyRequire<=0)
            {
                this.energyRequire = 0;
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
        public void setEnergyRequire(float energy){
            if (energy<=0)
            {
                this.energyRequire = 0;
            }
            else
            {
                this.energyRequire = energy;
            }
            
        }

        public override void update()
        {
            if(isConnected){
                connexionLine[0].update();
                nodePower = connexionLine[0].getLinePower();
                float power = connexionLine[0].getLinePower();
                if(energyRequire - power < 0){
                    nodeState = false;
                    Console.WriteLine("Too much power in " + this + " OVERFLOW");
                    Console.WriteLine("Asked: " + energyRequire.ToString() + " Received: " + power.ToString());
                    //throw new Exception();
                }
                else{
                   energyRequire -= power; 
                }
                
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