using Assets.Scripts.UI.TreasureChest.CommandPattern.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.UI.TreasureChest.CommandPattern
{
    public class TreasureChestTrade
    {
        private Stack<ICommand> commandList;

        public TreasureChestTrade()
        {
            commandList = new Stack<ICommand>();
        }

        public void ClearCommands() => commandList.Clear();

        public void AddCommand(ICommand command)
        {
            commandList.Clear();
            commandList.Push(command);
            command.Execute();
        }

        public void UndoCommand()
        {
            if (commandList.Count > 0)
            {
                ICommand command = commandList.Pop();
                command.Undo();
            }
        }
    }
}
