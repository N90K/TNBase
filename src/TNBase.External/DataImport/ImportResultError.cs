namespace TNBase.External.DataImport
{
    public class ImportResultError
    {
        public ImportResultError(string fieldName, string errorMessage, string rawRecord)
        {
            FieldName = fieldName;
            ErrorMessage = errorMessage;
            RawRecord = rawRecord;
        }

        public string FieldName { get; }
        public string ErrorMessage { get; }
        public string RawRecord { get; }
    }
}