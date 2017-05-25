using System.IO;
using Binapsis.Plataforma.Estructura.Impl;

namespace Binapsis.Plataforma.Configuracion.Serializacion
{
    public interface ISerializador 
    {
        byte[] Contenido { get; }
        ObjetoBase Objeto { get; }

        void Serializar();
        void Serializar(Stream contenido);
    }
}