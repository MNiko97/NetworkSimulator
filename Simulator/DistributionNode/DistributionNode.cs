using System;
using System.Collections.Generic;

namespace Network
{
    class DistributionNode : Node
    {
        public bool inputIsFull;
        public List<Line> inputLine;
        public List<Line> outputLine;


        public DistributionNode(int id) : base(id)
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



    }

}
