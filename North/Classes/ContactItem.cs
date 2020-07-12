namespace North.Classes
{
    /// <summary>
    /// Container for displaying in a control
    /// </summary>
    public class ContactItem
    {
        public int Id { get; set; }
        public string ContactName { get; set; }
        public string ContactType { get; set; }
        public string HomePhone { get; set; }
        public string CellPhone { get; set; }
        public string OfficePhone { get; set; }
        public override string ToString() => ContactName;

    }
}