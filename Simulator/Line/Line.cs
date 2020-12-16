using System;
using System.Collections.Generic;

namespace Network{
    class Line : IupdatableComponent{
        public int id;
        public List<Node> connexion;
        public int maxPower;
        public bool lineState;
        public int linePower;
        public bool isConnected;
        
        public Line(int id, int maxPower){
            this.id = id;
            this.maxPower = maxPower;
            this.lineState = false;
            this.linePower = 0;
            this.isConnected = false;
            this.connexion = new List<Node>();
        }
        public void updateLine(){
            if (isConnected){
                linePower = connexion[1].getNodePower();
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
        public void connect(Node node1, Node node2){
            if(!isConnected){
                connexion.Add(node1);
                connexion.Add(node2);
                isConnected = true;
            }
            else{
                Console.WriteLine("The line L", id, " is already connected");
            }
        }
        public override string ToString(){
            return "Line L" + id.ToString();
        }
        public int getLinePower(){
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
            throw new NotImplementedException();
        }

        public List<string> getAlert()
        {
            throw new NotImplementedException();
        }
    }
}