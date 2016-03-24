namespace AdventureTime
{
    public class CustomOption : Option
    {
        public CustomOption(string option) : base(option)
        {
        }

        public override void Action(Option option)
        {
            if (Player.Items.Contains(option.Requires))
            {
                Location.CurrentLocation.Destinations.Add(option.OptionDestination);
                Player.Items.Remove(option.Requires);
            }

            if(option.OptionDestination != null)
            {

            }

            if(option.OptionItem != null)
            {

            }
        }
    }
}