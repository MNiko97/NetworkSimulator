using System.Collections.Generic;

namespace Network{
    abstract class Node : IupdatableComponent{
        public int id;
        public float nodePower;
        public bool nodeState;
        public Node(){
            this.id = 0;
            this.nodePower = 0;
            this.nodeState = false;
        }
        public void setId(int id){
            this.id = id;
        }
        public float getNodePower(){
            return nodePower;
        }
        public bool getNodeState(){
            return nodeState;
        }
        public int getID(){
            return id;
        }
        public abstract void connect(Line line);
        public abstract void update();
        public abstract List<string> getAlert(); 
    }   
}