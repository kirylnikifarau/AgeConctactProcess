using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactProcess.Interfaces;

namespace ContactProcess.Rules
{
    public class SeniorSuffixRule : IAgeSuffixRule
    {
        public bool IsApplicable(int age) => age > 65;
        public string GetSuffix() => " (Пенсионер)";
    }
}
