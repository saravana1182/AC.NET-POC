using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgileCourtPOC.Infrastructure
{
    public enum ServiceCommand
    {
        Unknown,
        Start,
        Stop
    }
    public interface IInfrastructureService
    {
        bool Start();
        bool Stop();
    }
}
