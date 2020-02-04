namespace TNBase.DataStorage.Migrations
{
    public interface ISqlMigration
    {
        int Version { get; }

        string Name { get; }

        void Up();
    }
}