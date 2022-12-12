using CsvHelper.Configuration;
using System.Globalization;
using TNBase.Objects;

namespace TNBase.External.DataImport
{
    public class ListenerCsvMap : ClassMap<Listener>
    {
        public ListenerCsvMap()
        {
            AutoMap(CultureInfo.InvariantCulture);
            Map(m => m.Forename).Required();
            Map(m => m.Surname).Required();
            Map(m => m.Wallet).Optional().Default(0, true);
            Map(m => m.Title).Optional();
            Map(m => m.Addr1).Optional();
            Map(m => m.Addr2).Optional();
            Map(m => m.Town).Optional();
            Map(m => m.County).Optional();
            Map(m => m.Postcode).Optional();
            Map(m => m.OnlineOnly).Optional().Default(false, true);
            Map(m => m.Magazine).Optional().Default(false, true).Name("ReceivesMagazine");
            Map(m => m.MemStickPlayer).Optional().Default(false, true).Name("HasPlayerIssued");
            Map(m => m.Telephone).Optional();
            Map(m => m.Joined).Optional().Name("JoinedDate").TypeConverterOption.Format("dd/MM/yyyy");
            Map(m => m.BirthdayDay).Optional();
            Map(m => m.BirthdayMonth).Optional();
            Map(m => m.Status).Optional().Default("Active", true);
            Map(m => m.StatusInfo).Optional().Name("PauseStartDate", "PauseEndDate").TypeConverter<StatusInfoConverter>();
            Map(m => m.Stock).Optional().Default(0, true).Name("NewsStock");
            Map(m => m.NewsWalletsIssued).Optional().Default(0, true).Name("NumberOfNewsIssued");
            Map(m => m.MagazineStock).Optional().Default(0, true);
            Map(m => m.MagazineWalletsIssued).Optional().Default(0, true).Name("NumberOfMagazinesIssued");
            Map(m => m.Info).Optional().Name("Information");
            Map(m => m.WarnOfAddressChange).Optional().Default(false, true);
            Map(m => m.DeletedDate).Optional();
            Map(m => m.LastIn).Optional();
            Map(m => m.LastOut).Optional();
            Map(m => m.InOutRecords.Wallet).Optional().Default(0, true);
            Map(m => m.InOutRecords.In1).Optional().Default(0, true);
            Map(m => m.InOutRecords.In2).Optional().Default(0, true);
            Map(m => m.InOutRecords.In3).Optional().Default(0, true);
            Map(m => m.InOutRecords.In4).Optional().Default(0, true);
            Map(m => m.InOutRecords.In5).Optional().Default(0, true);
            Map(m => m.InOutRecords.In6).Optional().Default(0, true);
            Map(m => m.InOutRecords.In7).Optional().Default(0, true);
            Map(m => m.InOutRecords.In8).Optional().Default(0, true);
            Map(m => m.InOutRecords.Out1).Optional().Default(0, true);
            Map(m => m.InOutRecords.Out2).Optional().Default(0, true);
            Map(m => m.InOutRecords.Out3).Optional().Default(0, true);
            Map(m => m.InOutRecords.Out4).Optional().Default(0, true);
            Map(m => m.InOutRecords.Out5).Optional().Default(0, true);
            Map(m => m.InOutRecords.Out6).Optional().Default(0, true);
            Map(m => m.InOutRecords.Out7).Optional().Default(0, true);
            Map(m => m.InOutRecords.Out8).Optional().Default(0, true);
        }
    }
}