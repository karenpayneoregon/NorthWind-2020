namespace North.Classes
{
    public class CountryItem
    {
        public CountryItem()
        {
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int CustomerCount { get; set; }
        public string[] ItemArray => new[]
        {
            Name,
            CustomerCount.ToString()
        };
    }
}