using ContactProcess.Models;
using System;
using System.Globalization;

namespace ContactProcess.Services
{
    public class ContactValidator
    {
        public Contact ValidateAndCreate(string firstName, string lastName, string dob)
        {
            if (string.IsNullOrWhiteSpace(firstName))
                throw new ArgumentException("First name cannot be empty.");

            if (string.IsNullOrWhiteSpace(lastName))
                throw new ArgumentException("Last name cannot be empty.");

            if (!DateTime.TryParseExact(dob, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out var parsedDob))
                throw new ArgumentException("Date of Birth must be in format YYYY-MM-DD.");

            int age = CalculateAge(parsedDob);
            if (age < 0 || age > 130)
                throw new ArgumentException("Invalid age.");

            return new Contact(FormatName(firstName), FormatName(lastName), parsedDob);
        }

        private static int CalculateAge(DateTime dob)
        {
            var today = DateTime.Today;
            int age = today.Year - dob.Year;
            if (dob.Date > today.AddYears(-age))
                age--;
            return age;
        }

        private static string FormatName(string name)
        {
            name = name.Trim().ToLower();
            return char.ToUpper(name[0]) + name.Substring(1);
        }
    }
}
