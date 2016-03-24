namespace AdventureTime
{
    class ItemOption : Option
    {
        public ItemOption(string option) : base(option)
        {
        }

        public override void Action(Option option)
        {
            Player.Items.Add(option.OptionItem);
            Location.CurrentLocation.Items.Remove(option.OptionItem);
        }
    }
}