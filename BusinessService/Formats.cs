using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessService
{
    public static class Formats
    {
        public const string DateTimeDisplayFormat = "dd-MMM-yyyy hh:mm:ss tt";
        public const string EntryTimeFormat = "{0:HH:mm}";
        public const string DateISOFormat = "{0:yyyy-MM-dd}";
        public const string DecimalDisplayFormat = "{0:0.00}";
        public const string DecimalSingleDisplayFormat = "{0:0.0}";
        public const string DateDisplayFormat = "{0:dd-MMM-yyyy}";
        public const string MoneyDisplayFormat = "{0:C0}";
        public const string MoneyFormatNoDollarCommaSeparatedNoDecimal = "{0:N0}";
    }
}
