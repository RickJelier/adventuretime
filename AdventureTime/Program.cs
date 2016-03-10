using System;
using System.Collections;

namespace AdventureTime
{
    class Program
    {
        private static bool isRunning = true;
        private static string gameState = "unstarted";
        private static string gameStage = "start";
        private static Hashtable items = new Hashtable();
        private static string action;

        static void Main(string[] args)
        {
            // Add all the items to the list, if you do this in the while loop, your gonna have a lot of items.
            items.Add("light", false);
            items.Add("key", false);
            items.Add("keyPartOne", false);
            items.Add("keyPartTwo", false);

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

                        action = Console.ReadLine();

                        switch (action)
                        {
                            case "1":
                                gameState = "started";
                                break;
                            case "2":
                                Console.WriteLine("There is no point of playing an adventure game when there is no adventure");
                                Console.WriteLine("\nPress any key to continue");
                                Console.ReadKey();
                                gameState = "restartquestion";
                                break;
                            default:
                                Console.WriteLine("This is not the time to do that.");
                                Console.WriteLine("\nPress any key to continue");
                                Console.ReadKey();
                                break;
                        }
                        break;
                    // Let the user decide whether he wants to restart or not
                    case "restartquestion":
                        Console.WriteLine("Do you want to play again? y/n");
                        string answer = Console.ReadLine();

                        if (answer == "y")
                        {
                            gameState = "unstarted";
                            gameStage = "start";
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
                                if ((bool)items["light"] == true)
                                {
                                    Console.WriteLine("Well isn't that convenient? You can now actually see what you are doing");
                                    Console.WriteLine("The room is empty, every side of the room has a door");
                                    Console.WriteLine("You see that the door left from where you are standing has a key sticking out of it's keyhole");
                                    Console.WriteLine("What door do you go through?");
                                    Console.WriteLine("1 - The door to the left wich has the word kitchen on it");
                                    Console.WriteLine("2 - The door to the right, but something odd is telling your mind not to open that door");
                                    Console.WriteLine("3 - The door across the room");
                                    Console.WriteLine("4 - The door behind you");

                                    action = Console.ReadLine();

                                    switch (action)
                                    {
                                        case "1":
                                            gameStage = "kitchen";
                                            Console.WriteLine("You turn the key and open the door, you walk inside");
                                            Console.WriteLine("\nPress any key to continue");
                                            Console.ReadKey();
                                            break;
                                        case "2":
                                            Console.WriteLine("Even though I told you it wouldn't be a good idea to go through this door you just try to anyway.");
                                            Console.WriteLine("There is bad stuff beyond that door, proceed? (y/n)");
                                            action = Console.ReadLine();
                                            if(action == "n")
                                            {
                                                Console.WriteLine("Wise man, now get on with your adventure!");
                                                Console.WriteLine("\nPress any key to continue");
                                                Console.ReadKey();
                                            }
                                            else if(action == "y")
                                            {
                                                gameState = "restartquestion";
                                                Console.WriteLine("You walk through the door and get eaten by a rat");
                                                Console.WriteLine("Poor you, killed by a rat :/");
                                                Console.WriteLine("\nPress any key to continue");
                                                Console.ReadKey();
                                            }
                                            break;
                                        case "3":
                                            if ((bool)items["key"])
                                            {
                                                gameStage = "escaperoom";
                                                Console.WriteLine("You enter the room...");
                                                Console.WriteLine("\nPress any key to continue");
                                                Console.ReadKey();
                                            }
                                            else
                                            {
                                                Console.WriteLine("This door is locked, maybe you should try and find the key for it");
                                                Console.WriteLine("\nPress any key to continue");
                                                Console.ReadKey();
                                            }
                                            break;
                                        case "4":
                                            Console.WriteLine("This door locked behind you, remember?");
                                            Console.WriteLine("\nPress any key to continue");
                                            Console.ReadKey();
                                            break;
                                        default:
                                            Console.WriteLine("I'm not gonna ask again nicely, don't mess this up!");
                                            break;
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("As you enter the building the door shuts behind you. You hear a loud click and when you check the door it is locked");
                                    Console.WriteLine("You are blinded by darkness for there is no light in the room");
                                    Console.WriteLine("What do you do?");
                                    Console.WriteLine("1 - Search on your hands and feet if there is anything useful in the room");
                                    Console.WriteLine("2 - Search for a way out");
                                    Console.WriteLine("3 - Search for a lightswitch");

                                    action = Console.ReadLine();
                                    switch (action)
                                    {
                                        case "1":
                                            items["light"] = true;

                                            Console.WriteLine("You crawl around the room on your hands and feet and you find a flashlight");
                                            Console.WriteLine("\nPress any key to continue");
                                            Console.ReadKey();
                                            break;
                                        case "2":
                                            Console.WriteLine("You try to find a way out, and find a door but it is locked");
                                            Console.WriteLine("\nPress any key to continue");
                                            Console.ReadKey();
                                            break;
                                        case "3":
                                            Console.WriteLine("You try to find a light switch, and you find one...");
                                            Console.WriteLine("However, when you flip the switch nothing happens.");
                                            Console.WriteLine("\nPress any key to continue");
                                            Console.ReadKey();
                                            break;
                                        default:
                                            Console.WriteLine("Please do something useful here, your life may depend on it.");
                                            Console.WriteLine("\nPress any key to continue");
                                            Console.ReadKey();
                                            break;
                                    }
                                }
                                break;
                            case "kitchen":
                                Console.WriteLine("You enter the kitchen, and right in front of you on a table stands a skull with a lit candle sticking out of it's right eye");
                                Console.WriteLine("*You don't feel so comfortable, maybe it's better to find a way out");
                                Console.WriteLine("You see a couple of cabinets in one of the corners, and walk to them.");
                                Console.WriteLine("What do you do?");
                                Console.WriteLine("1 - Search the cabinets for anything of use");
                                Console.WriteLine("2 - Search the floor");
                                Console.WriteLine("3 - Go back to the hallway");

                                if((bool)items["keyPartOne"] && (bool)items["keyPartTwo"])
                                {
                                    Console.WriteLine("4 - Try put the key-parts together");
                                }

                                action = Console.ReadLine();

                                switch (action)
                                {
                                    case "1":
                                        if (!(bool)items["keyPartTwo"])
                                        {
                                            items["keyPartTwo"] = true;
                                            Console.WriteLine("You find half of a key hidden away in one of the cabinets");
                                            Console.WriteLine("\nPress any key to continue");
                                            Console.ReadKey();
                                        }
                                        else
                                        {
                                            Console.WriteLine("You already searched the floor, you dork.");
                                            Console.WriteLine("\nPress any key to continue");
                                            Console.ReadKey();
                                        }
                                        break;
                                    case "2":
                                        if (!(bool)items["keyPartOne"])
                                        {
                                            items["keyPartOne"] = true;
                                            Console.WriteLine("You find half of a key under the table");
                                            Console.WriteLine("\nPress any key to continue");
                                            Console.ReadKey();
                                        }
                                        else
                                        {
                                            Console.WriteLine("You already searched the floor, you dork.");
                                            Console.WriteLine("\nPress any key to continue");
                                            Console.ReadKey();
                                        }
                                        break;
                                    case "3":
                                        gameStage = "start";
                                        Console.WriteLine("You leave the kitchen and return to the hallway");
                                        Console.WriteLine("\nPress any key to continue");
                                        Console.ReadKey();
                                        break;
                                    case "4":
                                        if ((bool)items["keyPartOne"] && (bool)items["keyPartTwo"])
                                        {
                                            items["keyPartOne"] = false;
                                            items["keyPartTwo"] = false;
                                            items["key"] = true;
                                            Console.WriteLine("You use the candlewax to glue the pieces together, you now have a fully functional key");
                                            Console.WriteLine("\nPress any key to continue");
                                            Console.ReadKey();
                                        }
                                        else
                                        {
                                            goto default;
                                        }
                                        break;
                                    default:
                                        Console.WriteLine("You are pathetic, trying my temper.");
                                        break;
                                }
                                break;
                            case "escaperoom":
                                Console.WriteLine("You enter a small room with another door");
                                Console.WriteLine("Do go trough that door or return to the hallway?");

                                Console.WriteLine("1 - Return");
                                Console.WriteLine("2 - Go trough door");

                                action = Console.ReadLine();
                                switch (action)
                                {
                                    case "1":
                                        gameStage = "start";
                                        Console.WriteLine("You walk through the door you just came through, bit of a waste of time don't you think?");
                                        Console.WriteLine("\nPress any key to continue");
                                        Console.ReadKey();
                                        break;
                                    case "2":
                                        items["key"] = false;
                                        items["ligt"] = false;
                                        gameState = "restartquestion";

                                        Console.WriteLine("Upon opening the door, you see that this is the way out...");
                                        Console.WriteLine("You happily run trough the forest on your way home, what a day...");
                                        Console.WriteLine("\nPress any key to continue");
                                        Console.ReadKey();
                                        break;
                                    default:
                                        Console.WriteLine("What did you just say?");
                                        break;
                                }
                                break;
                        }
                        
                        break;
                    // End the game
                    case "ended":
                        isRunning = false;
                        break;
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
