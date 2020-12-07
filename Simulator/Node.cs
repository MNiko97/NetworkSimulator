namespace Node{
    class Node{
        public int id;
        public int nodePower;
        public bool nodeConnected;
        public Node(int id){
            this.id = id;
            this.nodePower = 0;
            this.nodeConnected = false;
        }
        public int getNodePower(){
            return nodePower;
        }
    }   
}