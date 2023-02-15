﻿using System.Text.RegularExpressions;
using System;
using System.Threading;

internal class Program
{

    public static string direction { get; set; }
    public static int PosY { get; set; }
    public static int PosX { get; set; }
    public static int mapSize { get; set; }

    private static void Main(string[] args)
    {
        Startup();
        
        //Results();
    }


    public static void Startup()
    {
        
        // Map size
        Console.Write("Enter your MapSize: ");
        mapSize = int.Parse(Console.ReadLine());

        // Start Positions
        startPositionHandler();

        // start direction input  N E S W
        startDirectionHandler();

        // command FFRFF
        string command = Console.ReadLine();

        generateMap();

        foreach (char c in command){
            step(c);
        }

        System.Console.ReadLine();
        System.Console.ReadLine();
        System.Console.ReadLine();


        //string Direction;
        //string Command;
        
    }

    private static void step(char c)
    {
       Thread.Sleep(1000);
        Console.WriteLine();
        
        switch (c)
        {
            case 'F':
                switch (direction)
                {
                    case "N":
                        PosY--;
                        break;
                    case "S":
                        PosY++;
                        break;
                    case "E":
                        PosX++;
                        break;
                    case "W":
                        PosX--;
                        break;
                }
                
                break;

            case 'B':
                switch (direction)
                {
                    case "N":
                        PosY++;
                        break;
                    case "S":
                        PosY--;
                        break;
                    case "E":
                        PosX--;
                        break;
                    case "W":
                        PosX++;
                        break;
                }
                break;

            case 'R':
                switch (direction)
                {
                    case "N":
                        direction = "E";
                        break;
                    case "W":
                        direction = "N";
                        break;
                    case "S":
                        direction = "W";
                        break;
                    case "E":
                        direction = "S";
                        break;
                }

                break;
            case 'L':
                Console.WriteLine("L");
                break;

                
        }
        generateMap();
    }

    public static void startDirectionHandler()
    {
        string startDirection = "";
        while(!startDirection.Equals("N") && !startDirection.Equals("E") && !startDirection.Equals("S") && !startDirection.Equals("W"))
        {
            Console.WriteLine("Enter which direction you want your vehicle to start in.");
            Console.WriteLine("North(N), East(E), South(S), West(W)");
            startDirection = Console.ReadLine();
        }
        direction = startDirection;
    }

    private static void generateMap()
    {
        int[,] mapArea = new int[mapSize, mapSize];

        
        mapArea[PosY -1, PosX -1] = 1;
        


        for (int y = 0; y < mapArea.GetLength(1); y++)
        {
            System.Console.WriteLine("");
            for (int x = 0; x < mapArea.GetLength(0); x++)
            {
                System.Console.Write(mapArea[y, x]);
            }
        }
    }

    private static void startPositionHandler()
    {
        Console.WriteLine("Enter your StartPosition Y: ");
        PosY = int.Parse(Console.ReadLine());
        while (PosY < 1 || PosY > mapSize)
        {
            PosY = StartSettingsHandler(mapSize, "Y");
        }


        Console.WriteLine("Enter your StartPosition X: ");
        
        PosX = int.Parse(Console.ReadLine());
        while (PosX < 1 || PosX > mapSize)
        {
            PosX = StartSettingsHandler(mapSize, "X");
        }
    }

      public static int StartSettingsHandler(int mapSize, string axis){
        Console.WriteLine($"Invalid Value, user a number between 1 and {mapSize}");
        Console.WriteLine($"Enter your StartPosition {axis}: ");
        return int.Parse(Console.ReadLine());
    }

    public static bool onlyDigitCheck(string compare){
        return compare.All(Char.IsDigit);
    }

    


    //    Console.WriteLine("Hello and welcome to Awesome RC Vehicles Simulation Program\n");

    //    Console.Write("Enter your specified direction (N,E,S,W): ");
    //    string Direction = Console.ReadLine();
    //    Console.WriteLine($"Direction Selected: {Direction}");

    //    Console.Write("Please write your desired simulation command: ");
    //    string Command = Console.ReadLine();




}