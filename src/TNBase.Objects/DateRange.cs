using System;

namespace TNBase.Objects
{
    public class DateRange
    {
        public DateTime from { get; set; }
        public DateTime to { get; set; }

        public override bool Equals(Object obj)
        {
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                DateRange other = (DateRange)obj;
                return (from == other.from) && (to == other.to);
            }
        }

        public override int GetHashCode()
        {
            return from.GetHashCode() ^ to.GetHashCode();
        }

        public override string ToString()
        {
            return string.Format("{0} - {1}", from.ToShortDateString(), to.ToShortDateString());
        }
    }
}
