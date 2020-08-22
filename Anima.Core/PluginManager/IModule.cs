using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.Composition;

namespace Anima.Core
{
    [InheritedExport(typeof(IModule))]
    public interface IModule
    {
        string ModuleName { get; }
        string ModuleDescription { get; }
        string ModuleAuthor { get; }

        void ModuleStart();
        void ModuleTick();
        void ModuleEnd();
    }
}
