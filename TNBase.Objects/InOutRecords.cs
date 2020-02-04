using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TNBase.Objects
{
    [Table("Listeners")]
    public class InOutRecords
    {
        [Key, ForeignKey("Listener")]
        public int Wallet { get; set; }
        public int In1 { get; set; }
        public int In2 { get; set; }
        public int In3 { get; set; }
        public int In4 { get; set; }
        public int In5 { get; set; }
        public int In6 { get; set; }
        public int In7 { get; set; }
        public int In8 { get; set; }
        public int Out1 { get; set; }
        public int Out2 { get; set; }
        public int Out3 { get; set; }
        public int Out4 { get; set; }
        public int Out5 { get; set; }
        public int Out6 { get; set; }
        public int Out7 { get; set; }
        public int Out8 { get; set; }
        [Required]
        public virtual Listener Listener { get; set; }
    }
}