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
                Destinations = new List<Location>(),
                CustomOptions = new List<CustomOption>()
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
                Destinations = new List<Location>(),
                CustomOptions = new List<CustomOption>()
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
                Destinations = new List<Location>(),
                CustomOptions = new List<CustomOption>()
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
                Destinations = new List<Location>(),
                CustomOptions = new List<CustomOption>()
            };

            Location lockedRoom = new Location()
            {
                Name = "locked room",
                Description = "Sealed tightly",
                Items = new List<Item>(),
                Options = new List<Option>(),
                Destinations = new List<Location>(),
                CustomOptions = new List<CustomOption>()
            };

            Location winRoom = new Location()
            {
                Name = "end",
                Description = "Congratulations you beat the game!",
                Items = new List<Item>(),
                Options = new List<Option>(),
                Destinations = new List<Location>(),
                CustomOptions = new List<CustomOption>(),
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

            CustomOption dungeonOption = new CustomOption("Use your knife to open the secret doorway");
            dungeonOption.Requires = requiredItem;
            dungeonOption.OptionDestination = lockedRoom;
            dungeon.CustomOptions.Add(dungeonOption);

            CustomOption kitchenOption = new CustomOption("Put the egg in the fridge");
            kitchenOption.Requires = winningItem;
            kitchenOption.OptionDestination = winRoom;
            kitchen.CustomOptions.Add(kitchenOption);

            Location.CurrentLocation = kitchen;


            while (_isRunning)
            {
                Location.CurrentLocation.Show();
            }
        }
    }
}