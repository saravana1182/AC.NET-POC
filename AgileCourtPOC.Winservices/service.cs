using AgileCourtPOC.Infrastructure;
using AgileCourtPOC.Winservices.Services;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;

namespace AgileCourtPOC.Winservices
{
    public class Service: ServiceControl
    {
        private List<IInfrastructureService> _serviceWorkers;



        private void Init()
        {
            _serviceWorkers = new List<IInfrastructureService>
                                  {
                                    new VaidationCodeService()
                                  };
        }
        public bool Start(HostControl hostControl)
        {
            hostControl.RequestAdditionalTime(TimeSpan.FromSeconds(30));

            Init();

            foreach (var infrastructureService in _serviceWorkers.Where(infrastructureService => infrastructureService != null))
            {
                CommandService(infrastructureService, ServiceCommand.Start);
            }

            return true;
        }

        public bool Stop(HostControl hostControl)
        {
            hostControl.RequestAdditionalTime(TimeSpan.FromSeconds(30));
            foreach (var infrastructureService in _serviceWorkers.Where(infrastructureService => infrastructureService != null))
            {
                CommandService(infrastructureService, ServiceCommand.Stop);
            }

        
            return true;
        }

        private void CommandService(IInfrastructureService service, ServiceCommand command)
        {
            if (service == null) throw new ArgumentNullException("service");
            try
            {
                switch (command)
                {
                    case ServiceCommand.Start:
                        Task.Factory.StartNew(() => service.Start());
                        break;
                    case ServiceCommand.Stop:
                        Task.Factory.StartNew(() => service.Stop());
                        break;
                    default:
                        throw new ApplicationException(string.Format("Service Command [{0}] is not supported", command));
                }
            }
            catch (Exception ex)
            {
            }
        }
    }
}
