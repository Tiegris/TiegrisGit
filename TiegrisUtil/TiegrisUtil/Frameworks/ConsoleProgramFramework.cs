using System;

namespace TiegrisUtil.Frameworks
{
    public delegate void ConsoleProgramMainDelegate(string[] args);

    /// <summary>
    /// Provides a framework for short console applications.
    /// It can help validate arguments and ask for initial parameters.
    /// </summary>
    public class ConsoleProgramFramework
    {
        /// <summary>
        /// Provides a framework for short console applications.
        /// It can help validate arguments and ask for initial parameters.
        /// </summary>
        /// <param name="argsValidator">Argument validator class.</param>
        /// <param name="main">This function will be the programs body. 
        /// After the arguments get validated, this function will be executed once.</param>
        /// <param name="waitKeyPress">If true, the program will wait, for a key press after it finished.</param>
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
