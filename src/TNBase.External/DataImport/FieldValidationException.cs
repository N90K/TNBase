using System;

namespace TNBase.External.DataImport
{
    public class FieldValidationException : Exception
    {
        public FieldValidationException(string fieldName, string message) : base(message)
        {
            FieldName = fieldName;
        }

        public string FieldName { get; set; }
    }
}
