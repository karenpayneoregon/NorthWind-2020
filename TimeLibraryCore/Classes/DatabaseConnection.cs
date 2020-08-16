namespace TimeLibraryCore.Classes
{
    /// <summary>
    /// Defines a database connection 
    /// </summary>
    public class DatabaseConnection
    {
        public string Name { get; set; }
        public string Value { get; set; }
        public override string ToString() => Name;

    }
}