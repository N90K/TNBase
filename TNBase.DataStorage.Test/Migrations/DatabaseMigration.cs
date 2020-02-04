using System;

namespace TNBase.DataStorage.Test.Migrations
{
    public class DatabaseMigration
    {
        public int Version { get; set; }
        public string Name { get; set; }
        public DateTime CreateDate { get; internal set; }
    }
}