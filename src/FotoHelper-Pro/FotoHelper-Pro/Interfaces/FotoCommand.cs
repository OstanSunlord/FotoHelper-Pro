using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FotoHelper_Pro.Interfaces
{
    public abstract class FotoCommand : IFotoCommand
    {
        protected string _name;
        public string Name { get => _name; set => _name = value; }

        public abstract void Execute();
    }
}
