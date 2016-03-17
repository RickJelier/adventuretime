using System.Collections.Generic;

namespace AdventureTime
{
    class Program
    {
        public static bool _isRunning = true;

        static void Main(string[] args)
        {
            // Making the location
            Location kitchen = new Location()
            {
                Name = "kitchen",
                Description = "The kitchen is a mess",
                Items = new List<Item>()
                {
                    new Item("Chef hat"),
                    new Item("Spoon")
                },
                Options = new List<Option>(),
                Destinations = new List<Location>()
            };

            Location hallway = new Location()
            {
                Name = "hallway",
                Description = "It's dark in here",
                Items = new List<Item>()
                {
                    new Item("Dead rat"),
                    new Item("Flashlight")
                },
                Options = new List<Option>(),
                Destinations = new List<Location>()
            };

            Location outside = new Location()
            {
                Name = "outside",
                Description = "The weather is wonderful",
                Items = new List<Item>()
                {
                    new Item("Stick"),
                    new Item("Stone")
                },
                Options = new List<Option>(),
                Destinations = new List<Location>()
            };

            Location dungeon = new Location()
            {
                Name = "dungeon",
                Description = "This dungeon is really small",
                Items = new List<Item>()
                {
                    new Item("Key"),
                    new Item("Empty bottle")
                },
                Options = new List<Option>(),
                Destinations = new List<Location>()
            };

            Location lockedRoom = new Location()
            {
                Name = "locked room",
                Description = "Sealed tightly",
                Items = new List<Item>(),
                Options = new List<Option>(),
                Destinations = new List<Location>()
            };

            Location winRoom = new Location()
            {
                Name = "the end",
                Description = "Congratulations you beat the game!",
                Items = new List<Item>(),
                Options = new List<Option>(),
                Destinations = new List<Location>(),
                LocationType = "ending"
            };

            // Assigning the destinations to every location
            hallway.Destinations.Add(kitchen);
            hallway.Destinations.Add(dungeon);
            dungeon.Destinations.Add(hallway);
            outside.Destinations.Add(hallway);
            kitchen.Destinations.Add(hallway);
            lockedRoom.Destinations.Add(dungeon);

            Item winningItem = new Item("Golden egg");
            Item requiredItem = new Item("Tableknife");
            kitchen.Items.Add(requiredItem);
            lockedRoom.Items.Add(winningItem);

            Option dungeonOption = new Option("Use your knife to open the secret doorway", "custom");
            dungeonOption.Requires = requiredItem;
            dungeonOption.OptionDestination = lockedRoom;
            dungeon.Options.Add(dungeonOption);

            Option kitchenOption = new Option("Put the egg in the fridge", "custom");
            kitchenOption.Requires = winningItem;
            kitchenOption.OptionDestination = winRoom;
            kitchen.Options.Add(kitchenOption);

            Location.CurrentLocation = kitchen;

            while (_isRunning)
            {
                Location.CurrentLocation.GenerateOptions();
                Location.CurrentLocation.Show();
            }
        }
    }
}