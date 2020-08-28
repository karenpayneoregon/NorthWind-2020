using System;

namespace EntityCoreExtensions.Classes
{
    public class SqlColumn
    {
        public bool IsPrimaryKey { get; set; }
        public bool IsForeignKey { get; set; }
        public bool IsNullable { get; set; }
        /// <summary>
        /// Column/property name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Description/comment from table definition in database table
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Used for populating a ListView or other control
        /// </summary>
        public string[] ItemArray => new[]
        {
            Convert.ToString(IsPrimaryKey ? "Yes" : ""),
            Convert.ToString(IsForeignKey ? "Yes" : ""),
            Name,
            Description,
            Convert.ToString(IsNullable ? "Yes" : "")
        };


        public override string ToString() => Name;

    }
}