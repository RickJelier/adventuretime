namespace AdventureTime
{
    class DestinationOption : Option
    {
        public DestinationOption(string option) : base(option)
        {
        }

        public override void Action(Option option)
        {
            Location.CurrentLocation = option.OptionDestination;
        }
    }
}