using Assets.Scripts.Interfaces.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Interfaces.Views
{
    public interface IView<T>
    {
        void SetController(T controller);
    }
}
