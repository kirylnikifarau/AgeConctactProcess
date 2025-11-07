using System;
using System.Globalization;

namespace ContactProcess
{
    public class Contact
    {
        public string FirstName { get; }
        public string LastName { get; }
        public DateTime DateOfBirth { get; }

        public Contact(string firstName, string lastName, string dob)
        {
            if (string.IsNullOrWhiteSpace(firstName))
                throw new ArgumentException("First name cannot be empty.");

            if (string.IsNullOrWhiteSpace(lastName))
                throw new ArgumentException("Last name cannot be empty.");

            if (!DateTime.TryParseExact(dob, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out var parsedDob))
                throw new ArgumentException("Date of Birth must be in format YYYY-MM-DD.");

            FirstName = FormatName(firstName);
            LastName = FormatName(lastName);
            DateOfBirth = parsedDob;
        }

        private string FormatName(string value)
        {
            value = value.Trim().ToLower();
            return char.ToUpper(value[0]) + value.Substring(1);
        }

        public int GetAge()
        {
            var today = DateTime.Today;
            int age = today.Year - DateOfBirth.Year;

            if (DateOfBirth.Date > today.AddYears(-age))
                age--;

            return age;
        }

        public string GetFullNameWithSuffix()
        {
            int age = GetAge();
            string fullName = $"{FirstName} {LastName}";

            if (age < 18)
                fullName += " (Несовершеннолетний)";
            else if (age > 65)
                fullName += " (Пенсионер)";

            return fullName;
        }

        public string GetContact()
        {
            return $"Полное имя: {GetFullNameWithSuffix()} Возраст: {GetAge()} лет";
        }
    }
}
