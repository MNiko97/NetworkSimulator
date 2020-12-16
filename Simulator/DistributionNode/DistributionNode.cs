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
                inputIsFull = true;
                Console.WriteLine(inputIsFull);
                Console.WriteLine(string.Join("\t", inputLine));
            }
            else
            {
                Console.WriteLine("Distribution Node input is already connected, can't connect another line!");
            }
        }
        public void addOutputLine(Line line){
            outputLine.Add(line);
            Console.WriteLine(string.Join("\t", outputLine));
        }
        public override string ToString(){
            return "Distribution Node N" + id.ToString();
        }
        public override List<string> getAlert()
        {
            throw new NotImplementedException();
        }

        public override void update()
        {
            //to implement
        }

        public override void connect(Line line)
        {
            throw new NotImplementedException();
        }
    }

}
