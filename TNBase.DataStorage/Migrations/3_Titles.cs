using System.Data;
using System.Data.SQLite;

namespace TNBase.DataStorage.Migrations
{
    public class _3_Titles : SqlMigration
    {
        public _3_Titles(SQLiteConnection connection) : base(connection)
        { }

        public override void Up()
        {
            using (var command = connection.CreateCommand())
            {
                command.CommandText = $"UPDATE Listeners SET Title='Mr.' WHERE Title='Mr'";
                command.ExecuteNonQuery();

                command.CommandText = $"UPDATE Listeners SET Title='Ms.' WHERE Title='Ms'";
                command.ExecuteNonQuery();

                command.CommandText = $"UPDATE Listeners SET Title='Mrs.' WHERE Title='Mrs'";
                command.ExecuteNonQuery();

                command.CommandText = $"UPDATE Listeners SET Title='Rev.' WHERE Title='Rev'";
                command.ExecuteNonQuery();
            }
        }
    }
}
