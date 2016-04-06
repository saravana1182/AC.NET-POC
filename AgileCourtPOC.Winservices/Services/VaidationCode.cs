using AgileCourtPOC.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MassTransit;
using Microsoft.Practices.Unity;
using System.Configuration;
using MassTransit.AzureServiceBusTransport;
using Microsoft.ServiceBus;
namespace AgileCourtPOC.Winservices.Services
{
    public class VaidationCodeService : IInfrastructureService
    {
        //Endpoint=sb://agilepoc.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=UU9LGHMaXmvwhGEAS9il/n31cCPJUBQ5WJf92sIAI0=

        private IUnityContainer _container;
        private IBusControl _bus;
        public bool Start()
        {
            ServiceBusEnvironment.SystemConnectivity.Mode = ConnectivityMode.Http;
            var _serviceUri = ServiceBusEnvironment.CreateServiceUri("sb", "agilepoc", "AgilePOC.ValidationCodeService");
            _container = new UnityContainer();
            
            _container.RegisterType<IBus>(new InjectionFactory(_=> {return MassTransit.Bus.Factory.CreateUsingAzureServiceBus( b=> {

                ServiceBusTokenProviderSettings settings = new AzureServiceBusAccountSettings();
                IServiceBusHost host = b.Host(_serviceUri,h=>h.SharedAccessSignature(s=> {
                    s.KeyName = settings.KeyName;
                    s.SharedAccessKey = settings.SharedAccessKey;
                    s.TokenScope = settings.TokenScope;
                    s.TokenTimeToLive = settings.TokenTimeToLive;
                }));


            } ); } ));

            //Implement a message;
            //Implement a consumer
            //Register it here
            //Should work

            return true;
        }

        public bool Stop()
        {
            throw new NotImplementedException();
        }
    }
}
