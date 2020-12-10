using System;
using System.Collections.Generic;

namespace Network
{
    class ConcentrationNode : Node
    {
        public bool outputIsFull;
        public List<int> inputLine;
        public List<int> outputLine;
        int totalInputPower;


        public ConcentrationNode(int id) : base (id)
        {
            this.inputLine = new List<int>();
            this.outputLine = new List<int>();
        }

        public void addInputLine(int id)
        {
            inputLine.Add(id);
            // Console.WriteLine(string.Join("\t", inputLine));
        }

        public void addOutputLine(int id)
        {
            if (outputIsFull == false){
                outputLine.Add(id);
                outputIsFull = true;
                // Console.WriteLine(outputIsFull);
                // Console.WriteLine(string.Join("\t", outputLine));
            }
            else
            {
                Console.WriteLine("Concentration Node output is already connected, can't connect another line!");
            }
        }

        public int sumInput(){
            totalInputPower =0;
            return totalInputPower;
        }


    }
}