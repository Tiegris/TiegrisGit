using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiegrisUtil.Cleanup;
using TiegrisUtil.Frameworks;

namespace BinClearupConsole
{
    class ArgsValidator : IConsoleProgramArgsValidator
    {
        public ArgsValidator(string[] _args) {
            args = _args;
        } 

        public string[] args { get; private set; }

        public void AskForArgs() {    
            Console.WriteLine("Specify a path to be the root of the search, or type 'pwd' to use Present Working Directory!");
            string ans = Console.ReadLine();
            if (ans.Trim().ToUpper() == "PWD")
                args = new string[] { Directory.GetCurrentDirectory() };
            else 
                args = new string[] { ans };
        }

        public bool IsValid() => (args.Length == 1) && Directory.Exists(args[0]);

    }

    class Program
    {
        static void Main(string[] args) {
            ConsoleProgramFramework program = new ConsoleProgramFramework(new ArgsValidator(args), run, true);            
        }

        static void run(string[] args) {
            BinaryCleanup cleanup = new BinaryCleanup(args[0]);
            foreach (var item in cleanup.ListAll())
                Console.WriteLine(item.FullName);
            string sizeString = cleanup.GetTotalSizeAsHumanReadable();
            Console.WriteLine(sizeString);
            string ans;
            do {
                Console.WriteLine("Do you want to remove all? (Y/N)");
                ans = Console.ReadLine().Trim().ToUpper();
            } while (!(ans[0] == 'Y' || ans[0] == 'N'));
            if (ans[0] == 'Y') {
                Console.WriteLine("Your answer was interpreted as Yes.");
                cleanup.DeleteAll();
                Console.WriteLine($"Deleted {sizeString} of data.");
            } else {
                Console.WriteLine("Your answer was interpreted as No.");
            }
        }
    }
}
