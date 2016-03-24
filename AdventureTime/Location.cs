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
        public List<CustomOption> CustomOptions { get; set; }
        public List<Location> Destinations { get; set; }
        public static Location CurrentLocation { get; set; }
        public string LocationType { get; set; }

        public void Show()
        {
            if (LocationType == "ending")
            {
                Dialog.say("Congrats you beat the game!", true);
                Dialog.say("Made by Rick Jelier", true);
                Dialog.exitGame();
            }

            Dialog.showOptions(CurrentLocation);
            Dialog.getInput(Options);
        }
    }
}