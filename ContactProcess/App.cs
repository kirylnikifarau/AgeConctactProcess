using ContactProcess.Interfaces;
using ContactProcess.Rules;
using ContactProcess.Services;
using System;
using System.Collections.Generic;

namespace ContactProcess
{
    static class App
    {
        public static void Run()
        {
            try
            {
                Console.Write("Введите имя: ");
                string firstName = Console.ReadLine();

                Console.Write("Введите фамилию: ");
                string lastName = Console.ReadLine();

                Console.Write("Введите дату рождения (ГГГГ-ММ-ДД): ");
                string dob = Console.ReadLine();

                var rules = new List<IAgeSuffixRule>
                {
                    new MinorSuffixRule(),
                    new SeniorSuffixRule()
                };

                var suffixService = new AgeSuffixService(rules);
                var validator = new ContactValidator();
                var formatter = new ContactFormatter(suffixService);

                var contact = validator.ValidateAndCreate(firstName, lastName, dob);

                Console.WriteLine();
                Console.WriteLine(formatter.Format(contact));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }

            Console.ReadKey();
        }
    }
}

