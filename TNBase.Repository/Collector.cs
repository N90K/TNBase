using System;
using System.Collections.Generic;

#nullable disable

namespace TNBase.Repository
{
    public partial class Collector
    {
        public long Key { get; set; }
        public string Forename { get; set; }
        public string Surname { get; set; }
        public string Telephone { get; set; }
        public string Postcodes { get; set; }
    }
}
