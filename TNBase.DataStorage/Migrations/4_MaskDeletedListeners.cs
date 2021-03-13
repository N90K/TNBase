using System.Data;
using System.Data.SQLite;

namespace TNBase.DataStorage.Migrations
{
    public class _4_MaskDeletedListeners : SqlMigration
    {
        public _4_MaskDeletedListeners(SQLiteConnection connection) : base(connection)
        { }

        public override void Up()
        {
            using (var command = connection.CreateCommand())
            {
                command.CommandText = $@"UPDATE Listeners SET 
                                            Title='N/A',
                                            Forename='Deleted',
                                            Surname='Deleted',
                                            Addr1=null,
                                            Addr2=null,
                                            Town=null,
                                            County=null,
                                            Postcode=null,
                                            Telephone=null,
                                            BirthdayDay=null,
                                            BirthdayMonth=null,
                                            Info=null,
                                            StatusInfo=null
                                        WHERE Status='DELETED' AND 
                                            MemStickPlayer=false AND 
                                            Stock=3 AND 
                                            (Magazine=0 OR (Magazine=1 AND MagazineStock=1))";
                command.ExecuteNonQuery();
            }
        }
    }
}
