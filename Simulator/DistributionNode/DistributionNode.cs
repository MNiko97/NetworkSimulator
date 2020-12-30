using System;
using System.Collections.Generic;
namespace Network
{
    class DistributionNode : Node
    {
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
            if (!inputIsFull){
                inputLine.Add(line);
                line.addNode(this);
                inputIsFull = true;
            }
            else
            {
                Console.WriteLine(this + " can only have 1 INPUT!");
            }
        }
        public void addOutputLine(Line line)
        {
            outputLine.Add(line);
            line.addNode(this);
        }
        public override string ToString()
        {
            return "Distribution Node N" + id.ToString();
        }
        public void output()
        {
            foreach (Line line in outputLine)
            {
                line.setPowerLine(nodePower/outputLine.Count, id);
                line.update();
            }
        }
        public override List<string> getAlert()
        {
            throw new NotImplementedException();
        }
        public override void update()
        {
            if(inputIsFull)
            {
               nodePower = inputLine[0].getLinePower(); 
            }
            output();
        }
        public override void connect(Line line)
        {            
            if(line.isInputAvailable())
            {
                addOutputLine(line);
            }
            else
            {
                addInputLine(line);
            } 
            if(outputLine.Count > 0 && inputIsFull)
            {  
                isConnected = true;
                nodeState = true;
            }
        }
    }
}
