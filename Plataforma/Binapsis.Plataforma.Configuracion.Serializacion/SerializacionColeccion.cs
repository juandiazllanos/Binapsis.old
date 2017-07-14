using Binapsis.Plataforma.Serializacion;
using System.Collections;
using System.IO;
using System.Linq;

namespace Binapsis.Plataforma.Configuracion.Serializacion
{
    public class SerializacionColeccion : ISerializador
    {
        public SerializacionColeccion(IList items)
        {
            Items = items;
        }

        public IList Items
        {
            get;
        }

        public byte[] Contenido
        {
            get;
            private set;
        }

        public IEscritor Escritor
        {
            get;
            set;
        }

        public void Serializar()
        {
            Serializar(new Secuencia());
        }

        public void Serializar(Stream contenido)
        {
            Serializar(new Secuencia(contenido));
        }

        private void Serializar(Secuencia secuencia)
        {
            if (Escritor == null) return;

            Serializador serializador = new SerializadorObjetoDatos(secuencia, Escritor);
            serializador.Serializar(Items);
            Contenido = secuencia.Contenido;
        }
    }
}
