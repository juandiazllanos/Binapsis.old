using Binapsis.Plataforma.Estructura;
using Binapsis.Plataforma.Helper.Impl;

namespace Binapsis.Plataforma.Cambios.Analisis
{
    class AnalisisAtributoCambios : AnalisisPropiedadCambios
    {
        public AnalisisAtributoCambios(AnalisisObjetoCambios aoc, IPropiedad propiedad) 
            : base(aoc, propiedad)
        {
        }

        public override void Resolver()
        {
            Cambio resul = Cambio.Ninguno;
            IObjetoDatos nuevo = AnalisisObjetoCambios.ObjetoDatosNuevo;
            IObjetoDatos antiguo = AnalisisObjetoCambios.ObjetoDatosAntiguo;

            if (!EqualityHelper.Instancia.Igual(nuevo, antiguo, Propiedad))
                resul = Cambio.Modificado;

            Cambio = resul;
        }
    }
}
