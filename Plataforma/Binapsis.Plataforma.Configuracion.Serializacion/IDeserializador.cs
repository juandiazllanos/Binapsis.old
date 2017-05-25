using System.IO;
using Binapsis.Plataforma.Estructura.Impl;

namespace Binapsis.Plataforma.Configuracion.Serializacion
{
    public interface IDeserializador
    {
        ObjetoBase Objeto { get; }

        void Deserializar(string contenido);
        void Deserializar(Stream contenido);
        void Deserializar(byte[] contenido);
    }
}