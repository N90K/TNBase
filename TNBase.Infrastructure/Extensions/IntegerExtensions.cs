using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TNBase.Infrastructure.Extensions
{
    public static class IntegerExtensions
    {
        public static string WithSuffix(this int value)
        {
            string number = value.ToString();
            if (number.EndsWith("11") || number.EndsWith("12") || number.EndsWith("13")) return number + "th";
            if (number.EndsWith("1")) return number + "st";
            if (number.EndsWith("2")) return number + "nd";
            if (number.EndsWith("3")) return number + "rd";
            return number + "th";
        }
    }
}
