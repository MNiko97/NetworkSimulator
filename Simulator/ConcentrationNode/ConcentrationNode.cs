using System;
using System.Collections.Generic;

namespace Network
{
    class ConcentrationNode : Node
    {
        public bool outputIsFull;
        public List<Line> inputLine;
        public List<Line> outputLine;
        float totalInputPower;


        public ConcentrationNode() : base ()
        {
            this.inputLine = new List<Line>();
            this.outputLine = new List<Line>();
        }

        public void addInputLine(Line line)
        {
            inputLine.Add(line);
            line.addNode(this);
            // Console.WriteLine(string.Join("\t", inputLine));
        }

        public void addOutputLine(Line line)
        {
            if (!outputIsFull){
                outputLine.Add(line);
                line.addNode(this);
                outputIsFull = true;
                // Console.WriteLine(outputIsFull);
                // Console.WriteLine(string.Join("\t", outputLine));
            }
            else
            {
                Console.WriteLine("Concentration Node N" + id.ToString() +" output is already connected, can't connect another line!");
            }
        }
        public override string ToString(){
            return "Concentration Node N" + id.ToString();
        }
        public override List<string> getAlert()
        {
            throw new NotImplementedException();
        }

        public void sumInput(){
            totalInputPower = 0;
            foreach (Line line in inputLine){
                totalInputPower += line.getLinePower();
            }

        }

        public override void update()
        {
            //to implement
        }
        public override void connect(Line line)
        {
            if(line.isInputAvailable()){
                addOutputLine(line);
            }else{
                addInputLine(line);
            }
        }
    }
}