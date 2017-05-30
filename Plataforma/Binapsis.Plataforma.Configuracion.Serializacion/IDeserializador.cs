using System.IO;

namespace Binapsis.Plataforma.Configuracion.Serializacion
{
    public interface IDeserializador
    {
        ConfiguracionBase Objeto { get; }

        void Deserializar(string contenido);
        void Deserializar(Stream contenido);
        void Deserializar(byte[] contenido);
    }
}