using System;

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

                var contact = new Contact(firstName, lastName, dob); ;

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

