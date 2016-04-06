using MassTransit.AzureServiceBusTransport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ServiceBus;

namespace AgileCourtPOC.Winservices
{
    public class AzureServiceBusAccountSettings : ServiceBusTokenProviderSettings
    {


        const string KeyName = "RootManageSharedAccessKey";
        const string SharedAccessKey = "UU9LGHMaXmvwhGEAS9il/n31cCPJUBQ5WJf92sIAI0=";
        readonly TokenScope _tokenScope;
        readonly TimeSpan _tokenTimeToLive;

        public AzureServiceBusAccountSettings()
        {
            _tokenTimeToLive = TimeSpan.FromDays(1);
            _tokenScope = TokenScope.Namespace;
        }

        string ServiceBusTokenProviderSettings.KeyName
        {
            get { return KeyName; }
        }

        string ServiceBusTokenProviderSettings.SharedAccessKey
        {
            get { return SharedAccessKey; }
        }

        TokenScope ServiceBusTokenProviderSettings.TokenScope
        {
            get { return _tokenScope; }
        }

        TimeSpan ServiceBusTokenProviderSettings.TokenTimeToLive
        {
            get { return _tokenTimeToLive; }
        }
    }
}
