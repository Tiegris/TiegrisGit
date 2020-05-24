using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiegrisUtil.Frameworks
{
    /// <summary>
    /// Common interface for argument validator classes.
    /// </summary>
    public interface IConsoleProgramArgsValidator
    {
        /// <summary>
        /// Argument array.
        /// </summary>
        string[] args { get; }

        /// <summary>
        /// Chechks if the argumets satisfy the requirements.
        /// </summary>
        /// <returns>true if the arguments satisfy the requirements.</returns>
        bool IsValid();

        /// <summary>
        /// This function is called automaticly by the ConsoleProgramFramework until the arguments are valid.
        /// It asks for user input, and sets the arguments.
        /// </summary>
        void AskForArgs();
    }
}
