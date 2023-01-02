using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatPlantWS.IProcesses
{
    public interface ITriggerProcess
    {
        Task CheckAllTriggers();
    }
}
