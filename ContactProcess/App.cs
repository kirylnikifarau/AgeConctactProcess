using System;
using ContactProcess.Rules;
using ContactProcess.interfaces;
using System.Collections.Generic;
using ContactProcess.Models;

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
                    new SeniorSuffixRule(),
                };

                var contact = new Contact(firstName, lastName, dob, rules);

                Console.WriteLine();
                Console.WriteLine(contact.GetContact());
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }

            Console.ReadKey();
        }
    }
}

