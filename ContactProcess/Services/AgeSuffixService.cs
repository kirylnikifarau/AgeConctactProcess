using System.Collections.Generic;
using ContactProcess.Interfaces;

namespace ContactProcess.Services
{
    public class AgeSuffixService : IAgeSuffixService
    {
        private readonly IEnumerable<IAgeSuffixRule> _rules;

        public AgeSuffixService(IEnumerable<IAgeSuffixRule> rules)
        {
            _rules = rules;
        }

        public string GetSuffix(int age)
        {
            foreach (var rule in _rules)
            {
                if (rule.IsApplicable(age))
                    return rule.GetSuffix();
            }

            return string.Empty;
        }
    }
}


