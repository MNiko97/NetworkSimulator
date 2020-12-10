using System;
namespace Network{
    class Line{
        public int id;
        public Node lineIN;
        public Node lineOUT;
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
        }
        public void updateLine(){
            if (isConnected){
                linePower = lineIN.getNodePower();
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
                lineIN = node1;
                lineOUT = node2;
                isConnected = true;
            }
            else{
                Console.WriteLine("The line L", id, " is already connected");
            }
        }
        public override string ToString(){
            return base.ToString() + " L" + id.ToString();
        }
    }
}