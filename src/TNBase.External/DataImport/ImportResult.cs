using System.Collections.Generic;

namespace TNBase.External.DataImport
{
    public class ImportResult
    {
        public IEnumerable<ImportResultItem> Records { get; set; }
        public string RawHeader { get; set; }
    }
}