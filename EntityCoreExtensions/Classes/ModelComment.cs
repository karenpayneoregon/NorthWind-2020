namespace EntityCoreExtensions.Classes
{
    public class ModelComment
    {
        public string Name { get; internal set; }
        public string Comment { get; internal set; }
        public string Full => $"{Name}, {Comment}";
        public override string ToString() => Name;

    }
}