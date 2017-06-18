using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace Patterns
{
    class FormatProvider : IFormatProvider, ICustomFormatter
    {
        static readonly string[] _numberwords = "zero one two three four five six seven eight nine minus point".Split();

        IFormatProvider _parent;

        public FormatProvider() : this(CultureInfo.CurrentCulture) { }
        public FormatProvider(IFormatProvider parent)
        {
            _parent = parent;
        }

        object IFormatProvider.GetFormat(Type formatType)
        {
            // CHECKME 
            if (formatType == typeof(ICustomFormatter)) return this;
            return null;
        }

        string ICustomFormatter.Format(string format, object arg, IFormatProvider formatProvider)
        {
            if (arg == null || format != "W")
                return string.Format(_parent, "{0:" + format + "}", arg);

            StringBuilder result = new StringBuilder();
            string digitList = string.Format(CultureInfo.InvariantCulture, "{0}", arg);

            foreach (char digit in digitList)
            {
                int i = "0123456789-.".IndexOf(digit);
                if (i == -1) continue;
                if (result.Length > 0) result.Append(' ');
                result.Append(_numberwords[i]);
            }

            return result.ToString();
        }
    }
}
