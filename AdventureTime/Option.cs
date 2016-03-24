namespace AdventureTime
{
    public class Option
    {
        public string OptionText { get; set; }
        public Item OptionItem { get; set; }
        public Location OptionDestination { get; set; }
        public Item Requires { get; set; }

        public Option(string option)
        {
            OptionText = option;
        }

        public virtual void Action(Option option)
        {
        }
    }
}