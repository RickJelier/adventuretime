using System;
using System.Collections;
using System.Collections.Generic;

namespace AdventureTime
{
    class Program
    {
        private static bool isRunning = true;
        private static string gameState = "unstarted";
        private static Hashtable items = new Hashtable();
        private static string action;
        private static List<string> questions = new List<string>();

        static void Main(string[] args)
        {
            // Add all the items to the list, if you do this in the while loop, your gonna have a lot of items.
            items.Add("light", false);
            items.Add("key", false);
            items.Add("keyPartOne", false);
            items.Add("keyPartTwo", false);

            // Creating gamestages
            GameStage kitchen = new GameStage("kitchen");
            GameStage start = new GameStage("start");
            GameStage escaperoom = new GameStage("escaperoom");
            GameStage outside = new GameStage("outside");
            GameStage restartquestion = new GameStage("restartquestion");
            GameStage ended = new GameStage("ended");

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
                        outside.dialog("You wander in a forest for hours, \nwhen all of the sudden you discover a mansion beyond an overgrown part of the forest You check the door of the building, and discover it is not locked \nWhat do you do?");

                        questions.Add("Go inside");
                        questions.Add("Bail");

                        action = outside.ask(questions);
                        questions.Clear();

                        switch (action)
                        {
                            case "1":
                                gameState = "started";
                                start.enter();
                                break;
                            case "2":
                                gameState = "restartquestion";
                                outside.dialog("There is no point of playing an adventure game when there is no adventure");
                                outside.confirm();
                                break;
                            default:
                                outside.dialog("This is not the time to do that.");
                                outside.confirm();
                                break;
                        }
                        break;
                    // Let the user decide whether he wants to restart or not
                    case "restartquestion":
                        restartquestion.dialog("Do you want to play again? y/n");
                        string answer = Console.ReadLine();

                        if (answer == "y")
                        {
                            gameState = "unstarted";
                            start.enter();
                        }
                        else if(answer == "n")
                        {
                            gameState = "ended";
                        }
                        else
                        {
                            restartquestion.dialog("Enter a valid answer please");
                            restartquestion.confirm();
                            restartquestion.enter();
                        }
                        break;
                    // The game logic (and story) is in here
                    case "started":

                        // Check what stage the player is in
                        switch (GameStage.currentArea)
                        {
                            case "start":
                                start.enter();

                                if ((bool)items["light"] == true)
                                {
                                    start.dialog("Well isn't that convenient? You can now actually see what you are doing\nThe room is empty, every side of the room has a door\nYou see that the door left from where you are standing has a key sticking out of it's keyhole\nWhat door do you go through?");

                                    questions.Add("The door to the left wich has the word kitchen on it");
                                    questions.Add("The door to the right, but something odd is telling your mind not to open that door");
                                    questions.Add("The door across the room");
                                    questions.Add("The door behind you");

                                    action = start.ask(questions);
                                    questions.Clear();

                                    switch (action)
                                    {
                                        case "1":
                                            start.dialog("You turn the key and open the door, you walk inside");
                                            start.confirm();
                                            kitchen.enter();
                                            break;
                                        case "2":
                                            start.dialog("Even though I told you it wouldn't be a good idea to go through this door you just try to anyway.\nThere is bad stuff beyond that door, proceed?");
                                            questions.Add("Yes");
                                            questions.Add("No");

                                            action = start.ask(questions);
                                            questions.Clear();

                                            if (action == "2")
                                            {
                                                start.dialog("Wise man, now get on with your adventure!");
                                                start.confirm();
                                            }
                                            else if(action == "1")
                                            {
                                                gameState = "restartquestion";
                                                start.dialog("You walk through the door and get eaten by a rat\nPoor you, killed by a rat :/");
                                                start.confirm();
                                            }
                                            break;
                                        case "3":
                                            if ((bool)items["key"])
                                            {
                                                start.dialog("You enter the room...");
                                                escaperoom.enter();
                                                start.confirm();
                                            }
                                            else
                                            {
                                                start.dialog("This door is locked, maybe you should try and find the key for it");
                                                start.confirm();
                                            }
                                            break;
                                        case "4":
                                            start.dialog("This door locked behind you, remember?");
                                            start.confirm();
                                            break;
                                        default:
                                            start.dialog("I'm not gonna ask again nicely, don't mess this up!");
                                            start.confirm();
                                            break;
                                    }
                                }
                                else
                                {
                                    start.dialog("As you enter the building the door shuts behind you. You hear a loud click and when you check the door it is locked\nYou are blinded by darkness for there is no light in the room\nWhat do you do?");

                                    questions.Add("Search on your hands and feet if there is anything useful in the room");
                                    questions.Add("Search for a way out");
                                    questions.Add("Search for a lightswitch");

                                    action = start.ask(questions);
                                    questions.Clear();
                                    switch (action)
                                    {
                                        case "1":
                                            items["light"] = true;

                                            start.dialog("You crawl around the room on your hands and feet and you find a flashlight");
                                            start.confirm();
                                            break;
                                        case "2":
                                            start.dialog("You try to find a way out, and find a door but it is locked");
                                            start.confirm();
                                            break;
                                        case "3":
                                            start.dialog("You try to find a light switch, and you find one...\nHowever, when you flip the switch nothing happens.");
                                            start.confirm();
                                            break;
                                        default:
                                            start.dialog("Please do something useful here, your life may depend on it.");
                                            start.confirm();
                                            break;
                                    }
                                }
                                break;
                            case "kitchen":
                                kitchen.dialog("You enter the kitchen, and right in front of you on a table stands a skull with a lit candle sticking out of it's right eye\n*You don't feel so comfortable, maybe it's better to find a way out\nYou see a couple of cabinets in one of the corners, and walk to them.\nWhat do you do?");
                                questions.Add("Search the cabinets for anything of use");
                                questions.Add("Search the floor");
                                questions.Add("Go back to the hallway");
                                
                                if((bool)items["keyPartOne"] && (bool)items["keyPartTwo"])
                                {
                                    questions.Add("Try put the key-parts together");
                                }

                                action = kitchen.ask(questions);
                                questions.Clear();

                                switch (action)
                                {
                                    case "1":
                                        if (!(bool)items["keyPartTwo"])
                                        {
                                            items["keyPartTwo"] = true;
                                            kitchen.dialog("You find half of a key hidden away in one of the cabinets");
                                            kitchen.confirm();
                                        }
                                        else
                                        {
                                            kitchen.dialog("You already searched the cabinets, so this is useless to do again.");
                                            kitchen.confirm();
                                        }
                                        break;
                                    case "2":
                                        if (!(bool)items["keyPartOne"])
                                        {
                                            items["keyPartOne"] = true;
                                            kitchen.dialog("You find half of a key under the table");
                                            kitchen.confirm();
                                        }
                                        else
                                        {
                                            kitchen.dialog("You already searched the floor, you dork.");
                                            kitchen.confirm();
                                        }
                                        break;
                                    case "3":
                                        start.enter();
                                        kitchen.dialog("You leave the kitchen and return to the hallway");
                                        kitchen.confirm();
                                        break;
                                    case "4":
                                        if ((bool)items["keyPartOne"] && (bool)items["keyPartTwo"])
                                        {
                                            items["keyPartOne"] = false;
                                            items["keyPartTwo"] = false;
                                            items["key"] = true;
                                            kitchen.dialog("You use the candlewax to glue the pieces together, you now have a fully functional key");
                                            kitchen.confirm();
                                        }
                                        else
                                        {
                                            goto default;
                                        }
                                        break;
                                    default:
                                        kitchen.dialog("You are pathetic, trying my temper.");
                                        kitchen.confirm();
                                        break;
                                }
                                break;
                            case "escaperoom":
                                escaperoom.dialog("You enter a small room with another door\nDo go trough that door or return to the hallway?");

                                questions.Add("Return");
                                questions.Add("Go trough door");

                                action = escaperoom.ask(questions);

                                questions.Clear();
                                switch (action)
                                {
                                    case "1":
                                        start.enter();
                                        escaperoom.dialog("You walk through the door you just came through, bit of a waste of time don't you think?");
                                        escaperoom.confirm();
                                        break;
                                    case "2":
                                        items["key"] = false;
                                        items["ligt"] = false;
                                        gameState = "restartquestion";

                                        escaperoom.dialog("Upon opening the door, you see that this is the way out...\nYou happily run trough the forest on your way home, what a day...");
                                        escaperoom.confirm();
                                        break;
                                    default:
                                        escaperoom.dialog("What did you just say?");
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
                        ended.dialog("An unexpected error has occured!");
                        ended.confirm();
                        restartquestion.enter();
                        break;
                }
            }
        }
    }
}
