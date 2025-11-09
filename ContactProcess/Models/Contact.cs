using System;
using System.Globalization;
using ContactProcess.interfaces;
using ContactProcess.Rules;
using System.Collections.Generic;

namespace ContactProcess.Models
{
    public class Contact
    {
        public string FirstName { get; }
        public string LastName { get; }
        public DateTime DateOfBirth { get; }

        private readonly IEnumerable<IAgeSuffixRule> _rules;

        public Contact(string firstName, string lastName, string dob, IEnumerable<IAgeSuffixRule> rules)
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
            _rules = rules ?? throw new ArgumentNullException(nameof(rules));

            ValidateAgeRange();
        }

        private void ValidateAgeRange()
        {
            int age = GetAge();
            if (age < 0)
                throw new ArgumentException("Age cannot be negative. Check the birth date.");
            if (age > 130)
                throw new ArgumentException("Age cannot exceed 130 years. Check the birth date.");
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

        private string GetSuffixByRules(int age)
        {
            foreach (var rule in _rules)
            {
                if (rule.IsApplicable(age))
                    return rule.GetSuffix();
            }

            return string.Empty;
        }

        public string GetFullNameWithSuffix()
        {
            int age = GetAge();
            string fullName = $"{FirstName} {LastName}";
            return fullName + GetSuffixByRules(age);
        }

        public string GetContact()
        {
            return $"Полное имя: {GetFullNameWithSuffix()} | Возраст: {GetAge()} лет";
        }
    }

}
