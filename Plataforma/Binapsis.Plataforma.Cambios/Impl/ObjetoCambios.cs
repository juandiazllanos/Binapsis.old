using Binapsis.Plataforma.Estructura;
using Binapsis.Plataforma.Estructura.Impl;

namespace Binapsis.Plataforma.Cambios.Impl
{
    public class ObjetoCambios : ObjetoDatos, IObjetoCambios
    {               
        public ObjetoCambios(ITipo tipo)
            : this(new FabricaImpl().Crear(tipo))
        {
        }

        public ObjetoCambios(IImplementacion impl) 
            : base(impl)
        {
            Cambio = Cambio.Ninguno;
        }

        protected override ObjetoBase CrearObjetoDatos(IImplementacion impl)
        {
            return new ObjetoCambios(impl) { Cambio = Cambio };
        }

        public Cambio Cambio
        {
            get;
            set;
        }

        public string Referencia
        {
            get;
            set;
        }
        
    }
}
