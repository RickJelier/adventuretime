using System;
using System.Collections.Generic;

namespace AdventureTime
{
    public class Dialog
    {
        public static void say(string text, bool doConfirm)
        {

            if (doConfirm)
            {
                clearScreen();
                Console.WriteLine(text);
                confirm();
            }
            else
            {
                Console.WriteLine(text);
            }
        }

        public static void clearScreen()
        {
            Console.Clear();
        }

        public static void confirm()
        {
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }

        public static void renderInventory()
        {
            Console.SetCursorPosition(0, 15);
            Console.WriteLine("Items: ");

            for (int i = 0; i < Player.Items.Count; i++)
            {
                Console.Write("| {0} |", Player.Items[i].Name);
            }

            Console.SetCursorPosition(0, 0);
        }

        public static void showOptions(Location currentLocation)
        {
            clearScreen();
            renderInventory();
            Console.WriteLine("{0}:\n{1}", currentLocation.Name, currentLocation.Description);
            say("Where do you go or what do you take?\n", false);

            currentLocation.Options.Clear();
            List<Option> options = new List<Option>();

            List<CustomOption> customOptions = currentLocation.CustomOptions;
            for (int i = 0; i < customOptions.Count; i++)
            {
                options.Add(customOptions[i]);
            }

            
            List<Location> destinations = currentLocation.Destinations; 
            for (int i = 0; i < destinations.Count; i++)
            {
                Option thisOption = new DestinationOption("Go to the " + destinations[i].Name);
                thisOption.OptionDestination = destinations[i];
                options.Add(thisOption);
            }

            List<Item> items = currentLocation.Items;
            for (int i = 0; i < items.Count; i++)
            {
                Option thisOption = new ItemOption("Take the " + items[i].Name);
                thisOption.OptionItem = items[i];
                options.Add(thisOption);
            }

            currentLocation.Options = options;

            for (int i = 0; i < options.Count; i++)
            {
                if (options[i].Requires == null)
                {
                    Console.WriteLine(i + 1 + " - " + options[i].OptionText);
                }
                else
                {
                    if (Player.Items.Contains(options[i].Requires))
                    {
                        Console.WriteLine(i + 1 + " - " + options[i].OptionText);
                    }
                    else
                    {
                        Console.WriteLine(i + 1 + " - Idle");
                    }
                }
            }
        }

        public static void getInput(List<Option> options)
        {
            int action;
            if (Int32.TryParse(Console.ReadLine(), out action))
            {
                if (action <= options.Count)
                {
                    Option option = options[action - 1];
                    option.Action(option);
                }
                else
                {
                    say("This option is not available", true);
                }
            }
            else
            {
                say("This is not valid input", true);
            }
        }

        public static void exitGame()
        {
            Environment.Exit(0);
        }
    }
}