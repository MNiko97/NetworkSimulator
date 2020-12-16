using System;
using System.Collections.Generic;

namespace Network
{
    class ConcentrationNode : Node
    {
        public bool outputIsFull;
        public List<Line> inputLine;
        public List<Line> outputLine;
        int totalInputPower;


        public ConcentrationNode() : base ()
        {
            this.inputLine = new List<Line>();
            this.outputLine = new List<Line>();
        }

        public void addInputLine(Line line)
        {
            inputLine.Add(line);
            // Console.WriteLine(string.Join("\t", inputLine));
        }

        public void addOutputLine(Line line)
        {
            if (!outputIsFull){
                outputLine.Add(line);
                outputIsFull = true;
                // Console.WriteLine(outputIsFull);
                // Console.WriteLine(string.Join("\t", outputLine));
            }
            else
            {
                Console.WriteLine("Concentration Node output is already connected, can't connect another line!");
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
            throw new NotImplementedException();
        }
        public override void connect(Line line)
        {
            throw new NotImplementedException();
        }
    }
}