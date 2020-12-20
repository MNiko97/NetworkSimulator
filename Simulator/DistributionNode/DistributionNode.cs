using System;
using System.Collections.Generic;

namespace Network
{
    class DistributionNode : Node
    {
        private const string V = "Node N";
        public bool inputIsFull;
        public List<Line> inputLine;
        public List<Line> outputLine;


        public DistributionNode() : base()
        {
            this.inputLine = new List<Line>();
            this.outputLine = new List<Line>();
        }

        public void addInputLine(Line line)
        {
            if (inputIsFull == false){
                inputLine.Add(line);
                line.addNode(this);
                inputIsFull = true;
                //Console.WriteLine(inputIsFull);
                //Console.WriteLine(string.Join("\t", inputLine));
            }
            else
            {
                Console.WriteLine("Distribution Node input is already connected, can't connect another line!");
            }
        }
        public void addOutputLine(Line line){
            outputLine.Add(line);
            line.addNode(this);
            //Console.WriteLine(string.Join("\t", outputLine));
        }
        public override string ToString(){
            return "Distribution Node N" + id.ToString();
        }
        public void output(){
            foreach (Line line in outputLine){
                line.setPowerLine(nodePower/outputLine.Count, id);
                line.update();
            }
        }

        public override List<string> getAlert(){
            throw new NotImplementedException();
        }

        public override void update(){
            if(inputIsFull){
               nodePower = inputLine[0].getLinePower(); 
            }
            output();
        }

        public override void connect(Line line){
            if(!isConnected){
                if(line.isInputAvailable()){
                    addOutputLine(line);
                }else{
                    addInputLine(line);
                } 
            }
            if(outputLine.Count > 0 && inputIsFull){    
                isConnected = true;
                nodeState = true;
            }else{
                Console.WriteLine(this+" is already connected");
            }
        }
    }

}
