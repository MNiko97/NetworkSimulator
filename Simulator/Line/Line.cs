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
            Console.WriteLine("step6");
            if (linePower > maxPower){
                Console.WriteLine("Current power exceding line L"+ id.ToString() +" maximum capacity");
                linePower = 0;
                //generate an error to node
                lineState = false;
            }
            else if (linePower < 0){
                Console.WriteLine("Current power in line L"+ id.ToString() + " is negative");
                linePower = 0;
                lineState = false;
            }
            else if (linePower <= maxPower){
                Console.WriteLine("step7");
                lineState = true;
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
            Console.WriteLine("step2");
            if(connexionNode[0].getID() == id){
                Console.WriteLine("step3");
                linePower = newPower;
            }
            else{
                Console.WriteLine("step4");
                linePower = 0;
                lineState = false;
                Console.WriteLine(lineState);
                Console.WriteLine("Error: line connected to 2 sources");
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
            foreach(var node in connexionNode){
                strConnexionNode += "N" + node.id.ToString() + " ";            
            }
            strConnexionNode += "]";
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