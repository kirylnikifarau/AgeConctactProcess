using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactProcess.Interfaces
{
    public interface IAgeSuffixRule
    {
        bool IsApplicable(int age);
        string GetSuffix();
    }
}
