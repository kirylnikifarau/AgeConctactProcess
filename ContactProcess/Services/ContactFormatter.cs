using ContactProcess.Interfaces;
using ContactProcess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactProcess.Services
{
    public class ContactFormatter
    {
        private readonly IAgeSuffixService _suffixService;

        public ContactFormatter(IAgeSuffixService suffixService)
        {
            _suffixService = suffixService;
        }

        public string Format(Contact contact)
        {
            int age = contact.GetAge();
            string suffix = _suffixService.GetSuffix(age);
            return $"Полное имя: {contact.GetFullName()}{suffix} | Возраст: {age} лет";
        }
    }
}
