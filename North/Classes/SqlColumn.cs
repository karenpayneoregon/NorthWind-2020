﻿namespace North.Classes
{
    public class SqlColumn
    {
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
        public string[] ItemArray => new[] {Name, Description};
        public override string ToString() => Name;

    }
}