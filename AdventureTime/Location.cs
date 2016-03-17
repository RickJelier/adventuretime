using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventureTime
{
    public class Location
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Item> Items { get; set; }
        public List<Option> Options { get; set; }
        public List<Location> Destinations { get; set; }
        public static Location CurrentLocation { get; set; }
        public string LocationType { get; set; }

        public void Show()
        {
            Console.Clear();
            Console.SetCursorPosition(0, 15);
            Console.WriteLine("Items: ");
                
            for (int i = 0; i < Player.Items.Count; i++)
            {
                Console.Write("| " + Player.Items[i].Name + " ");
            }
            Console.Write("|");
            Console.SetCursorPosition(0, 0);

            Console.WriteLine(Name + ":\n" + Description);
            if(LocationType != "ending")
            {
                Console.WriteLine("Where do you go or what do you take?");
            }
            else
            {
                Console.WriteLine("Press any key to continue");
                Console.ReadKey();
                Console.Clear();
                Console.WriteLine("Made by Rick Jelier");
                Console.WriteLine("Press any key to continue");
                Console.ReadKey();
                Environment.Exit(0);
            }

            for (int i = 0; i < Options.Count; i++)
            {
                if (Options[i].Requires == null)
                {
                    Console.WriteLine(i + 1 + " - " + Options[i].OptionText);
                }
                else
                {
                    if (Player.Items.Contains(Options[i].Requires))
                    {
                        Console.WriteLine(i + 1 + " - " + Options[i].OptionText);
                    }
                    else
                    {
                        Console.WriteLine(i + 1 + " - Idle");
                    }
                }
            }

            int action;
            if(Int32.TryParse(Console.ReadLine(), out action))
            {
                if(action <= Options.Count())
                {
                    if(Options[action-1].OptionType == "destination")
                    {
                        CurrentLocation = Options[action - 1].OptionDestination;
                    }
                    else if(Options[action - 1].OptionType == "item")
                    {
                        Player.Items.Add(Options[action - 1].OptionItem);
                        CurrentLocation.Items.Remove(Options[action - 1].OptionItem);
                    }
                    else if(Options[action - 1].OptionType == "custom")
                    {
                        if (Player.Items.Contains(Options[action - 1].Requires))
                        {
                            Destinations.Add(Options[action - 1].OptionDestination);
                            Options[action - 1].OptionType = "destination";

                            Player.Items.Remove(Options[action - 1].Requires);
                        }
                    }

                    Options.RemoveAll(TypeIsNotCustom);
                }
                else
                {
                    Options.RemoveAll(TypeIsNotCustom);
                    Console.Clear();
                    Console.WriteLine("This option is not available");
                    Console.WriteLine("Press any key to continue");
                    Console.ReadKey();
                }
            }
            else
            {
                Options.RemoveAll(TypeIsNotCustom);
                Console.Clear();
                Console.WriteLine("This is not valid input");
                Console.WriteLine("Press any key to continue");
                Console.ReadKey();
            }
        }

        public void GenerateOptions()
        {
            Options.RemoveAll(TypeIsNotCustom);

            for(int i = 0; i < Destinations.Count; i++)
            {
                Option thisOption = new Option("Go to the " + Destinations[i].Name, "destination");
                thisOption.OptionDestination = Destinations[i];
                Options.Add(thisOption);
            }

            for(int i = 0; i < Items.Count; i++)
            {
                Option thisOption = new Option("Take the " + Items[i].Name, "item");
                thisOption.OptionItem = Items[i];
                Options.Add(thisOption);
            }
        }

        private static bool TypeIsNotCustom(Option option)
        {
            bool removeThis = true;
            if (option.OptionType == "custom")
            {
                removeThis = false ;
            }

            return removeThis;
        }
    }
}