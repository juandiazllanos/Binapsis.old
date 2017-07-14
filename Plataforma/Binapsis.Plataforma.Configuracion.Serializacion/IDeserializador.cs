using System.IO;

namespace Binapsis.Plataforma.Configuracion.Serializacion
{
    public interface IDeserializador
    {
        void Deserializar(string contenido);
        void Deserializar(Stream contenido);
        void Deserializar(byte[] contenido);
    }
}