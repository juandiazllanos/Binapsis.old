using Binapsis.Plataforma.Estructura;
using Binapsis.Plataforma.Helper.Impl;

namespace Binapsis.Plataforma.Cambios.Analisis
{
    class AnalisisReferenciaCambios : AnalisisPropiedadCambios
    {
        public AnalisisReferenciaCambios(AnalisisObjetoCambios aoc, IPropiedad propiedad) 
            : base(aoc, propiedad)
        {
        }

        private void Construir()
        {
            IObjetoDatos nuevo = AnalisisObjetoCambios.ObjetoDatosNuevo.ObtenerObjetoDatos(Propiedad);
            IObjetoDatos antiguo = AnalisisObjetoCambios.ObjetoDatosAntiguo.ObtenerObjetoDatos(Propiedad);
            Referencia = new AnalisisObjetoCambios(Propiedad.Tipo, AnalisisObjetoCambios) { ObjetoDatosNuevo = nuevo, ObjetoDatosAntiguo = antiguo };
            Referencia.Ruta = $"{AnalisisObjetoCambios.Ruta}/{Propiedad.Nombre}";
        }

        public override void Resolver()
        {
            Cambio resul = Cambio.Ninguno;

            Construir();

            if (Propiedad.Asociacion == Asociacion.Composicion)
            {
                Referencia.Resolver();
                if (Referencia.Cambio != Cambio.Ninguno) resul = Cambio.Modificado;
            }
            else if (!EqualityHelper.Instancia.Igual(Referencia.ObjetoDatosNuevo, Referencia.ObjetoDatosAntiguo))
            {
                resul = Referencia.ObjetoDatosAntiguo != null ? Cambio.Eliminado : Cambio.Creado;
                Referencia.Cambio = resul;
            }                
            
            Cambio = resul;
        }

        public AnalisisObjetoCambios Referencia
        {
            get;
            private set;
        }

    }
}
