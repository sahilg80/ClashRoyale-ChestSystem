using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.UI.TreasureChest.CommandPattern.Interface
{
    public interface ICommand
    {
        void Execute();
        void Undo();
    }
}
