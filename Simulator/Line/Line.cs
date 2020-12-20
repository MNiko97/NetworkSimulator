using System;
using System.Collections.Generic;

namespace Network{
    class Line : IupdatableComponent{
        public int id;
        public List<Node> connexionNode;
        public float maxPower;
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
                Console.WriteLine("Error: Current power exceding " + this + " maximum capacity");
                linePower = 0;
                //generate an error to node
                lineState = false;
            }
            else if (linePower < 0){
                Console.WriteLine("Error: Abnormal power in " + this);
                linePower = 0;
                lineState = false;
            }
            else if (linePower <= maxPower){
                lineState = true;
            }
        }
        public void addNode(Node node){
            if(!isConnected){
                if(connexionNode.Count <2){
                    connexionNode.Add(node); 
                }
            }else{
                Console.WriteLine("Error: " + this + " is already connected");
                Console.WriteLine("Error: " + node + " is not connected");
            }
            if(connexionNode.Count == 2){
                isConnected = true;
            }
            
        }
        public void setPowerLine(float newPower, int id){
            if(connexionNode[0].getID() == id){
                linePower = newPower;
            }
            else{
                linePower = -1;
                Console.WriteLine("Error: " + this + " is connected to 2 sources");
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
        public string showConnexionNode(){
            string strConnexionNode = "[";
            if(connexionNode.Count == 0){
                strConnexionNode += "empty]";
            }
            if(connexionNode.Count == 1){
                strConnexionNode += "N" + connexionNode[0].id.ToString() + "-NONE";
            }
            if(connexionNode.Count == 2){
                strConnexionNode += "N" + connexionNode[0].id.ToString() + "-" + "N" + connexionNode[1].id.ToString() + "]";
            }
            return strConnexionNode;
        }
        public void update()
        {
           checkLineState();
        }
        public List<string> getAlert()
        {
            throw new NotImplementedException();
        }
        public bool isInputAvailable(){
            if(connexionNode.Count == 0){
                return true;
            }
            else{
                return false;
            }
        }
    }
}