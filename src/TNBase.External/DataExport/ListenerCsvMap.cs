using CsvHelper.Configuration;
using TNBase.External.TypeConverters;
using TNBase.Objects;

namespace TNBase.External.DataExport
{
    public class ListenerCsvMap : ClassMap<Listener>
    {
        public ListenerCsvMap()
        {
            //
            Map(m => m.Forename).Index(0);
            Map(m => m.Surname).Index(1);
            Map(m => m.Wallet).Index(2);
            Map(m => m.Title).Index(3);
            Map(m => m.Addr1).Index(4);
            Map(m => m.Addr2).Index(5);
            Map(m => m.Town).Index(6);
            Map(m => m.County).Index(7);
            Map(m => m.Postcode).Index(8);
            Map(m => m.OnlineOnly).Index(9);
            Map(m => m.Magazine).Index(10).Name("ReceivesMagazine");
            Map(m => m.MemStickPlayer).Index(11).Name("HasPlayerIssued");
            Map(m => m.Telephone).Index(12);
            Map(m => m.Joined).Index(13).Name("JoinedDate").TypeConverterOption.Format("dd/MM/yyyy");
            Map(m => m.BirthdayDay).Index(14);
            Map(m => m.BirthdayMonth).Index(15);
            Map(m => m.Status).Index(16);
            Map(m => m.StatusInfo).Index(17).Name("PauseStartDate").TypeConverter<StatusInfoConverter>();
            Map(m => m.StatusInfo, false).Index(18).Name("PauseEndDate").TypeConverter<StatusInfoConverter>();
            Map(m => m.Stock).Index(19).Name("NewsStock");
            Map(m => m.NewsWalletsIssued).Index(20).Name("NumberOfNewsIssued");
            Map(m => m.MagazineStock).Index(21).Default(0, true);
            Map(m => m.MagazineWalletsIssued).Index(22).Name("NumberOfMagazinesIssued");
            Map(m => m.Info).Index(23).Name("Information");
            Map(m => m.WarnOfAddressChange).Index(24);
            Map(m => m.DeletedDate).Index(25).TypeConverterOption.Format("dd/MM/yyyy");
            Map(m => m.LastIn).Index(26).TypeConverterOption.Format("dd/MM/yyyy");
            Map(m => m.LastOut).Index(27).TypeConverterOption.Format("dd/MM/yyyy");
            Map(m => m.InOutRecords.Wallet).Index(28);
            Map(m => m.InOutRecords.In1).Index(29);
            Map(m => m.InOutRecords.In2).Index(30);
            Map(m => m.InOutRecords.In3).Index(31);
            Map(m => m.InOutRecords.In4).Index(32);
            Map(m => m.InOutRecords.In5).Index(33);
            Map(m => m.InOutRecords.In6).Index(34);
            Map(m => m.InOutRecords.In7).Index(35);
            Map(m => m.InOutRecords.In8).Index(36);
            Map(m => m.InOutRecords.Out1).Index(37);
            Map(m => m.InOutRecords.Out2).Index(38);
            Map(m => m.InOutRecords.Out3).Index(39);
            Map(m => m.InOutRecords.Out4).Index(40);
            Map(m => m.InOutRecords.Out5).Index(41);
            Map(m => m.InOutRecords.Out6).Index(42);
            Map(m => m.InOutRecords.Out7).Index(43);
            Map(m => m.InOutRecords.Out8).Index(44);
        }
    }
}
