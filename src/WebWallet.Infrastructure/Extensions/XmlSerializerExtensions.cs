using System.IO;
using System.Xml.Serialization;

namespace WebWallet.Infrastructure.Extensions
{
    /// <summary>
    ///     Extension methods for setting up services in an <see cref="System.Xml.Serialization.XmlSerializer" />.
    /// </summary>
    public static class XmlSerializerExtensions
    {
        /// <summary>
        ///     Cast xml to {T} object.
        /// </summary>
        public static T DeserializeObject<T>(this XmlSerializer serializer, Stream stream)
        {
            return (T) serializer.Deserialize(stream);
        }
    }
}