using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace FinanceAnalysis.Helpers
{

    // <summary>
    /// Validates a text against a regular expression
    /// </summary>
    public class GenericRegexValidator : ValidationRule
    {
        private string _pattern;
        private Regex _regex;

        public string Pattern
        {
            get { return _pattern; }
            set
            {
                _pattern = value;
                _regex = new Regex(_pattern, RegexOptions.IgnoreCase);
            }
        }

        internal GenericRegexValidator() { }


        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value == null || !_regex.Match(value.ToString()).Success)
            {
                return new ValidationResult(false, "The value is not a valid e-mail address");
            }
            else
            {
                return new ValidationResult(true, null);
            }
        }
    }
 
}
