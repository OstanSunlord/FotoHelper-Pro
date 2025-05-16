using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FotoHelper_Pro.Interfaces
{
    public interface IFotoCommand
    {
        string Name { get; set; }
        void Execute();

    }
}
