using System.Threading.Tasks;
using WebWallet.Infrastructure.Types;

namespace WebWallet.Infrastructure.Abstractions
{
    public interface IEcuEuropa
    {
        Task<Envelope> GetEnvelope();
    }
}