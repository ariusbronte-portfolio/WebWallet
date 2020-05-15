using System;
using System.Linq;
using WebWallet.Infrastructure.Types;

namespace WebWallet.Infrastructure.Extensions
{
    /// <summary>
    ///     Extension methods for setting up services in an <see cref="WebWallet.Infrastructure.Types.Envelope" />.
    /// </summary>
    public static class EnvelopeExtensions
    {
        /// <summary>
        ///     Returns rate of currency. 
        /// </summary>
        public static decimal GetRate(this Envelope envelope, Func<Cube, bool> func)
        {
            return envelope.Cube.TimeCube.Cube.Where(func).Select(x=>x.Rate).FirstOrDefault();
        }
    }
}