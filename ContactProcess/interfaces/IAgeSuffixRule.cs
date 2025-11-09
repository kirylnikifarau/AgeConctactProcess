using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactProcess.interfaces
{
    public interface IAgeSuffixRule
    {
        bool IsApplicable(int age);
        string GetSuffix();
    }
}
