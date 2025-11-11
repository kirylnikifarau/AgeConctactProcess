using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactProcess.Interfaces;

namespace ContactProcess.Rules
{
    public class MinorSuffixRule : IAgeSuffixRule
    {
        public bool IsApplicable(int age) => age < 18;
        public string GetSuffix() => " (Несовершеннолетний)";
    }
}
