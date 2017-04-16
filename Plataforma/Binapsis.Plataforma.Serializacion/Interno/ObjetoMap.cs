using Binapsis.Plataforma.Estructura;

namespace Binapsis.Plataforma.Serializacion.Interno
{
    internal class ObjetoMap
    {
        public ObjetoMap(IObjetoDatos od, int id)
        {
            Id = id;
            ObjetoDatos = od;
        }

        public int Id
        {
            get;
            private set;
        }

        public IObjetoDatos ObjetoDatos
        {
            get;
            private set;
        }

        public string Propietario
        {
            get;
            set;
        }
    }
}
