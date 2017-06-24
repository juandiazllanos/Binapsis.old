using Binapsis.Plataforma.Estructura;
using Binapsis.Plataforma.Cambios;
using Binapsis.Plataforma.Cambios.Impl;

namespace Binapsis.Plataforma.Serializacion.Estrategia
{
    class DeserializarObjetoCambios : DeserializarObjetoDatos
    {
        public DeserializarObjetoCambios(IObjetoCambios cambios, ILector lector) 
            : base(cambios, lector)
        {
        }

        public DeserializarObjetoCambios(ITipo tipo, ILector lector) 
            : base(tipo, lector)
        {
        }

        protected override void LeerObjetoDatos()
        {
            base.LeerObjetoDatos();

            if (ObjetoDatos is IObjetoCambios cambios)
            {
                // leer en el orden de los parametros EscribirObjetoDatos()
                cambios.Referencia = Lector.LeerRuta();
                cambios.Cambio = Lector.LeerCambio();
            }

        }

        protected override DeserializarObjetoDatos CrearEstrategia(ITipo tipo)
        {
            return new DeserializarObjetoCambios(tipo, Lector) { HeapId = HeapId, Fabrica = Fabrica };
        }

        protected override DeserializarObjetoDatos CrearEstrategia(IObjetoDatos od)
        {
            if (od is IObjetoCambios cambios)
                return new DeserializarObjetoCambios(cambios, Lector) { HeapId = HeapId, Fabrica = Fabrica };
            else
                return base.CrearEstrategia(od);
        }

        protected override IObjetoDatos CrearObjetoDatos(ITipo tipo)
        {
            return new ObjetoCambios(tipo);
        }

    }
}
