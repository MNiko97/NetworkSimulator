using System;
using System.Collections.Generic;

namespace Network{
    class Line : IupdatableComponent{
        public int id;
        public List<Node> connexionNode;
        public int maxPower;
        public bool lineState;
        public float linePower;
        public bool isConnected;
        
        public Line(int id, int maxPower){
            this.id = id;
            this.maxPower = maxPower;
            this.lineState = false;
            this.linePower = 0;
            this.isConnected = false;
            this.connexionNode = new List<Node>();
            
        }
        public void checkLineState(){
            if (linePower > maxPower){
                Console.WriteLine("Current power exceding line L"+ id.ToString() +" maximum capacity");
                linePower = 0;
                //generate an error to node
                this.lineState = false;
                Console.WriteLine(this.lineState);
            }
            if (linePower < 0){
                Console.WriteLine("Current power in line L"+ id.ToString() + " is negative");
                this.linePower = 0;
                this.lineState = false;
            }
            else{
                this.lineState = true;
            }
        }
        public void addNode(Node node){
            if(!isConnected){
                if(connexionNode.Count <2){
                    connexionNode.Add(node); 
                    if (connexionNode.Count == 2){
                        isConnected = true;
                    }
                }
            }
            else{
                Console.WriteLine("The line L", id, " is already connected");
            }
        }
        public void setPowerLine(float newPower, int id){
            if(connexionNode[0].getID() == id){
                linePower = newPower;
            }
            else{
                Console.WriteLine("Error two sources on the line");
                linePower = 0;
            }
            
        }
        public override string ToString(){
            return "Line L" + id.ToString();
        }
        public float getLinePower(){
            return linePower;
        }
        public bool getLineState(){
            return this.lineState;
        }
        public int getID(){
            return id;
        }

        public void update()
        {
           checkLineState();
        }

        public List<string> getAlert()
        {
            throw new NotImplementedException();
        }
    }
}