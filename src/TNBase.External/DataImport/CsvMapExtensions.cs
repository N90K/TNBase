using CsvHelper.Configuration;

namespace TNBase.External.DataImport
{
    public static class CsvMapExtensions
    {
        public static MemberMap<TClass, string> Required<TClass>(this MemberMap<TClass, string> memberMap)
        {
            return memberMap.Convert(x =>
            {
                var field = x.Row.GetField<string>(memberMap.Data.Member.Name);
                if (string.IsNullOrEmpty(field))
                {
                    throw new FieldValidationException(memberMap.Data.Member.Name, $"{memberMap.Data.Member.Name} is required");
                }

                return field;
            });
        }
    }
}
