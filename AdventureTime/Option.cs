namespace AdventureTime
{
    public class Option
    {
        public string OptionText { get; set; }
        public string OptionType { get; set; }
        public Item OptionItem { get; set; }
        public Location OptionDestination { get; set; }
        public Item Requires { get; set; }

        public Option(string option, string type)
        {
            OptionText = option;
            OptionType = type;
        }
    }
}