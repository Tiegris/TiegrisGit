using System.Collections.Generic;
using System.Linq;
using TiegrisUtil.Collections;

namespace Frameworks.Patterns.Command
{
    public class CommandProcessor
    {
        private AgingStack<Command> commands;

        public CommandProcessor(int stackSize) {
            commands = new AgingStack<Command>(stackSize);
        }

        public void ExecuteCommand(Command cmd) {
            cmd.Execute();
            commands.Push(cmd);
        }
        public void RevertLastCommand() {
            if (!HasAny)
                return;
            Command lastCommand = commands.Pop();
            lastCommand.Revert();
        }

        public void Clear() {
            commands.Clear();
        }
        public bool HasAny => commands.HasAny;

    }
}
