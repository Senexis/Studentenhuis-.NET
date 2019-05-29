using System;
using System.Globalization;
using System.ComponentModel.DataAnnotations;

namespace Avans.Studentenhuis.Models
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    public class MealDateRangeValidAttribute : ValidationAttribute
    {
        public DateTime From { get; }

        public DateTime To { get; }

        public MealDateRangeValidAttribute()
        {
            From = DateTime.Today;
            To = DateTime.Today.AddDays(14);
        }
        public override bool IsValid(object value)
        {
            var dateTime = (DateTime) value;

            return From <= dateTime && dateTime <= To;
        }

        public override string FormatErrorMessage(string name)
        {
            return string.Format(CultureInfo.CurrentCulture, ErrorMessageString, name, From, To);
        }
    }
}
