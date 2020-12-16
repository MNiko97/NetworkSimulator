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
        public void updateLine(){
            if (isConnected){
                linePower = connexionNode[1].getNodePower();
                if(checkLineState()){
                    lineState = true;
                }
                else{
                    linePower = 0;
                    lineState = false;
                } 
            }
            else{
                linePower = 0;
                lineState = false;
                Console.WriteLine("Line L", id, " is not connected");
            }       
        }
        public bool checkLineState(){
            if (linePower >= maxPower){
                return false;
            }
            else if (linePower < 0){
                Console.WriteLine("The current power in line L", id, " is négative");
                return false;
            }
            else{
                return true;
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
            
        }
        public override string ToString(){
            return "Line L" + id.ToString();
        }
        public float getLinePower(){
            return linePower;
        }
        public bool getLineState(){
            return lineState;
        }
        public int getID(){
            return id;
        }

        public void update()
        {
            //to implement
        }

        public List<string> getAlert()
        {
            throw new NotImplementedException();
        }
    }
}