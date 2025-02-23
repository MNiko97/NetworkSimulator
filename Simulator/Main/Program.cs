﻿using System;
using System.Threading;
using System.Timers;
using System.Threading.Tasks;
namespace Network
{
    class Program
    {
        private static System.Timers.Timer networkUpdateTimer;
        private static Network network = new Network();
        public static int count = 4000;
        static void Main(string[] args)
        {         
            //This is a demonstration
            //Create Power Stations
            network.addPowerStationNode(new GasPS(15000, new Fuel(10, 10, 100))); 
            network.addPowerStationNode(new NuclearPS(30000,new Fuel(50,1,1000)));
            network.addPowerStationNode(new WindPS(5000,new Fuel(0,0,50),network.weather));
            network.addPowerStationNode(new SolarPS(3000,new Fuel(0,0,60),network.weather));
            network.addPowerStationNode(new ImportCountry(2000, new Fuel(100,0,100)));
            network.addPowerStationNode(new GasPS(10000, new Fuel(10000, 10, 100)));

            //Create Consumers
            network.addConsumerNode(new ExportCountry(20000)); 
            network.addConsumerNode(new Town(20000));
            network.addConsumerNode(new Company(40000));
            network.addConsumerNode(new Town(8000));
            network.addConsumerNode(new Dissipator(10000));

            //Create Distribution Nodes
            network.addDistributionNode(); //id = 11
            network.addDistributionNode();

            //Create Concentration Nodes
            network.addConcentrationNode(); //id = 13
            network.addConcentrationNode();
            network.addConcentrationNode();
            network.addConcentrationNode();

            //create 16 lines
            for (int i=0;i<16;i++)
            {
                network.addLine(10000); 
            }

            //Connect two nodes : node 1 (input), node 2 (output), line
            network.connect(0,13,0);
            network.connect(1,13,1);
            network.connect(2,14,2);
            network.connect(3,14,3);
            network.connect(14,13,4);
            network.connect(13,11,5);
            network.connect(11,6,6);
            network.connect(11,7,7);
            network.connect(11,16,8);
            network.connect(4,15,9);
            network.connect(5,15,10);
            network.connect(15,16,11);
            network.connect(16,12,12);
            network.connect(12,8,13);
            network.connect(12,9,14);
            network.connect(12,10,15);

            //Set personalized energy production
            network.sourceArray[0].setEnergyProduction(500);
            network.sourceArray[2].setEnergyProduction(2500);
            network.sourceArray[5].setEnergyProduction(5000);
            
            //Start Simulation
            Start();
        }
        private static void SetTimer()
        {
            // Create a timer with one second interval.
            networkUpdateTimer = new System.Timers.Timer(1000);
            // Hook up the Elapsed event for the timer. 
            networkUpdateTimer.Elapsed += OnTimedEvent;
            networkUpdateTimer.AutoReset = true;
            networkUpdateTimer.Enabled = true;
        }
        private static void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            Console.WriteLine("Current time: {0:HH:mm:ss.fff}", e.SignalTime);
            network.run();
            Console.WriteLine("=============================================");
            Console.WriteLine("\n\n\n\n");            
        }
        private static void Start()
        {
            SetTimer();
            Console.WriteLine("\nPress the Enter key to exit the application...\n");
            Console.ReadLine();
            networkUpdateTimer.Stop();
            networkUpdateTimer.Dispose();
            Console.WriteLine("Terminating the application...");
        }
    }
}
