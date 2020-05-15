using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml.Serialization;
using WebWallet.Infrastructure.Abstractions;
using WebWallet.Infrastructure.Extensions;
using WebWallet.Infrastructure.Types;

namespace WebWallet.Infrastructure.EcbEuropa
{
    public class EcuEuropa : IEcuEuropa
    {
        private readonly HttpClient _httpClient;

        public EcuEuropa(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public async Task<Envelope> GetEnvelope()
        {
            var xml = await _httpClient.GetStreamAsync("stats/eurofxref/eurofxref-daily.xml");
            var xmlSerializer = new XmlSerializer(typeof(Envelope));
            return xmlSerializer.DeserializeObject<Envelope>(xml);
        }
    }
}