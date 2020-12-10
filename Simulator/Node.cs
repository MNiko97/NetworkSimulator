namespace Network{
    class Node{
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
        public override string ToString(){
            return "Node N" + id.ToString();
        }
    }   
}