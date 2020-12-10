using System;
using System.Collections.Generic;

namespace Network
{
    class DistributionNode : Node
    {
        public bool inputIsFull;
        public List<int> inputLine;
        public List<int> outputLine;


        public DistributionNode(int id) : base(id)
        {
            this.inputLine = new List<int>();
            this.outputLine = new List<int>();
        }

        public void addInputLine(int id)
        {
            if (inputIsFull == false){
                inputLine.Add(id);
                inputIsFull = true;
                Console.WriteLine(inputIsFull);
                Console.WriteLine(string.Join("\t", inputLine));
            }
            else
            {
                Console.WriteLine("Distribution Node input is already connected, can't connect another line!");
            }
        }
        public void addOutputLine(int id){
            outputLine.Add(id);
            Console.WriteLine(string.Join("\t", outputLine));
        }



    }

}
