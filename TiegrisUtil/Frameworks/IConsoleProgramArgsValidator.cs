using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiegrisUtil.Frameworks
{
    public interface IConsoleProgramArgsValidator
    {
        string[] args { get; }
        bool IsValid();
        void AskForArgs();
    }
}
