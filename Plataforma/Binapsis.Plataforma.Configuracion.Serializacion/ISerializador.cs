using System.IO;

namespace Binapsis.Plataforma.Configuracion.Serializacion
{
    public interface ISerializador 
    {
        byte[] Contenido { get; }
        ConfiguracionBase Objeto { get; }

        void Serializar();
        void Serializar(Stream contenido);
    }
}