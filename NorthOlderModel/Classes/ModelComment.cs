namespace NorthOlderModel.Classes
{
    public class ModelComment
    {
        public string Name { get; internal set; }
        public string Comment { get; internal set; }
        public string DisplayText { get; set; }
        public override string ToString() => Name;

    }
}