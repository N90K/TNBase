namespace TNBase.External.DataImport
{
    public class ImportResultItem
    {
        private ImportResultError error;

        public ImportResultItem(int currentIndex)
        {
            Row = currentIndex;
        }

        public int Row { get; }
        public ImportResultError Error => error;
        public bool HasError => Error != null;

        internal void SetError(string fieldName, string message, string rawRecord)
        {
            error = new ImportResultError(fieldName, message, rawRecord);
        }
    }
}