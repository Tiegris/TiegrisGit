using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiegrisUtil.Frameworks
{
    public delegate void ConsoleProgramMainDelegate(string[] args);

    public class ConsoleProgramFramework
    {
        public ConsoleProgramFramework(IConsoleProgramArgsValidator argsValidator, 
            ConsoleProgramMainDelegate main, bool waitKeyPress = false) {
            if (argsValidator.IsValid())
                main(argsValidator.args);
            else {
                do {
                    argsValidator.AskForArgs();
                } while (!argsValidator.IsValid());
                main(argsValidator.args);
            }
            if (waitKeyPress) {
                Console.WriteLine("Press any key to continue..");
                Console.ReadKey();
            }
        }

    }
}
