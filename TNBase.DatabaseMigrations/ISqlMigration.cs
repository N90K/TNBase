namespace TNBase.DatabaseMigrations
{
    public interface ISqlMigration
    {
        int Version { get; }

        string Name { get; }

        void Up();
    }
}