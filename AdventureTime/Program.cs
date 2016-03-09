using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureTime
{
    class Program
    {
        private static bool isRunning = true;
        private static string gameState = "unstarted";
        private static string gameStage = "start";
        private static string[] objects;

        static void Main(string[] args)
        {
            while (isRunning)
            {
                // Clear the console before every state
                Console.Clear();

                // Do what state
                switch (gameState)
                {
                    // Before playing
                    case "unstarted":
                        // Intro to the game
                        Console.WriteLine("You wander in a forest for hour, \nwhen all of the sudden you discover a mansion beyond an overgrown part of the forest");
                        Console.WriteLine("You check the door of the building, and discover it is not locked");
                        Console.WriteLine("\nWhat do you do?");
                        Console.WriteLine("1 - Go inside");
                        Console.WriteLine("2 - Bail");

                        string action = Console.ReadLine();

                        if(action != "2")
                        {
                            gameState = "started";
                        }
                        else
                        {
                            Console.WriteLine("There is no point of playing an adventure game when there is no adventure");
                            Console.WriteLine("\nPress any key to continue");
                            Console.ReadKey();
                            gameState = "restartquestion";
                        }
                        break;
                    // Let the user decide whether he wants to restart or not
                    case "restartquestion":
                        Console.WriteLine("Do you want to play again? y/n");
                        string answer = Console.ReadLine();

                        if (answer == "y")
                        {
                            gameState = "unstarted";
                        }
                        else if(answer == "n")
                        {
                            gameState = "ended";
                        }
                        else
                        {
                            Console.WriteLine("Enter a valid answer please");
                            Console.WriteLine("Press any key to continue");
                            Console.ReadKey();
                            gameState = "restartquestion";
                        }
                        break;
                    // The game logic (and story) is in here
                    case "started":
                        // Check what stage the player is in
                        switch (gameStage)
                        {
                            case "start":
                                
                                break;
                            case "kitchen":

                                break;
                            case "dungeon":

                                break;
                        }
                        Console.WriteLine("As you enter the building the door shuts behind you.");
                        Console.WriteLine("You are blinded by darkness for there is no light in the room");
                        break;
                    // End the game
                    case "ended":
                        isRunning = false;
                        break;
                    // It should never come to default case (maybe in case of a typo)
                    default:
                        // Display error message
                        Console.WriteLine("An unexpected error has occured!");
                        Console.WriteLine("Press any key to continue");
                        Console.ReadKey();
                        
                        goto case "restartquestion";
                }
            }
        }
    }
}
