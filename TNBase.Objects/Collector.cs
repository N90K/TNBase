using System.Xml.Serialization;

namespace TNBase.Objects
{
    /// <summary>
    /// Collector - someone who will collect usb memory stick players
    /// </summary>
    public class Collector
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public Collector() { }

        /// <summary>
        /// Unique ID
        /// </summary>
        [XmlIgnore]
        public int ID;

        /// <summary>
        /// Forename for the Collector
        /// </summary>
        public string Forename;

        /// <summary>
        /// Surname for the Collector.
        /// </summary>
        public string Surname;

        /// <summary>
        /// A telephone number for the Collector.
        /// </summary>
        public string Number;

        /// <summary>
        /// Postcodes for the collector.
        /// 
        /// Note: These will be in a CSV format.
        /// </summary>
        public string Postcodes;
    }
}
