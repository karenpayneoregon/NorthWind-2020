namespace North.Classes
{
    public class SqlColumn
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string[] ItemArray => new[] {Name, Description};
        public override string ToString() => Name;

    }
}