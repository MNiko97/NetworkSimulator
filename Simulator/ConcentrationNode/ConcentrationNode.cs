using System;
using System.Collections.Generic;
namespace Network
{
    class ConcentrationNode : Node
    {
        public bool outputIsFull;
        public List<Line> inputLine;
        public List<Line> outputLine;
        public ConcentrationNode() : base ()
        {
            this.inputLine = new List<Line>();
            this.outputLine = new List<Line>();
        }
        public void addInputLine(Line line)
        {
            inputLine.Add(line);
            line.addNode(this);
        }
        public void addOutputLine(Line line)
        {
            if (!outputIsFull)
            {
                outputLine.Add(line);
                line.addNode(this);
                outputIsFull = true;
            }
            else
            {
                Console.WriteLine(this + " can only have 1 OUTPUT!");
            }
        }
        public override string ToString()
        {
            return "Concentration Node N" + id.ToString();
        }
        public override List<string> getAlert()
        {
            throw new NotImplementedException();
        }
        public void sumInput()
        {
            nodePower = 0;
            foreach (Line line in inputLine){
                nodePower += line.getLinePower();
            }
        }
        public override void update()
        {
            sumInput();
            if(nodeState){
                outputLine[0].setPowerLine(nodePower, id);
                outputLine[0].update();
            }
        }
        public override void connect(Line line)
        {
            if(line.isInputAvailable()){
                addOutputLine(line);
            }else{
                addInputLine(line);
            }
            if(inputLine.Count > 0 && outputIsFull){
                isConnected = true;
                nodeState = true;
            }
        }
    }
}
