using System.Collections.Generic;

namespace Network{
    abstract class Node : updatableComponent{
        public int id;
        public int nodePower;
        public bool nodeState;
        public Node(int id){
            this.id = id;
            this.nodePower = 0;
            this.nodeState = false;
        }
        public int getNodePower(){
            return nodePower;
        }
        public bool getNodeState(){
            return nodeState;
        }
        public void updateNode(){
            // To implement
        }
        public int getID(){
            return id;
        }
        public abstract void update();
        public abstract List<string> getAlert(); 
    }   
}