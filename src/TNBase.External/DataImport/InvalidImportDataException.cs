using System;

namespace TNBase.External.DataImport
{
    [Serializable]
    public class InvalidImportDataException : Exception
    {
        public InvalidImportDataException(string message) : base(message) { }
    }
}
