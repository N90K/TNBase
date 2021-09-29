using System;

namespace TNBase.Repository.UnitTests
{
    public class DatabaseMigration
    {
        public int Version { get; set; }
        public string Name { get; set; }
        public DateTime CreateDate { get; internal set; }
    }
}