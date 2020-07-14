namespace North.Classes
{
    public class CategoryItem
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public override string ToString() => CategoryName;
    }
}
