using Binapsis.Plataforma.Cambios.Analisis;
using Binapsis.Plataforma.Cambios.Impl;
using Binapsis.Plataforma.Estructura;
using Binapsis.Plataforma.Helper.Impl;

namespace Binapsis.Plataforma.Cambios.Builder
{
    class BuilderObjetoCambios
    {
        public BuilderObjetoCambios(IObjetoCambios objetoCambios)
        {
            ObjetoCambios = objetoCambios;
        }

        public void Construir(IObjetoDatos nuevo, IObjetoDatos antiguo)
        {
            AnalisisObjetoCambios aoc = new AnalisisObjetoCambios(ObjetoCambios.Tipo) { ObjetoDatosNuevo = nuevo, ObjetoDatosAntiguo = antiguo };
            aoc.Resolver();
            Construir(aoc);
        }

        private void Construir(AnalisisObjetoCambios aoc)
        {
            if (aoc.Cambio == Cambio.Ninguno) return;

            ObjetoCambios.Cambio = aoc.Cambio;
            ObjetoCambios.Referencia = aoc.Ruta ?? string.Empty;

            if (aoc.Cambio == Cambio.Eliminado)
                new CopyHelper().Copiar(aoc.ObjetoDatosAntiguo, ObjetoCambios);

            else if (aoc.Cambio == Cambio.Modificado) 
                foreach (AnalisisPropiedadCambios apc in aoc.Propiedades)
                    Construir(apc);
        }
                
        private void Construir(AnalisisPropiedadCambios apc)
        {
            if (apc.Cambio == Cambio.Ninguno) return;

            if (apc.GetType() == typeof(AnalisisAtributoCambios))
                Construir((AnalisisAtributoCambios)apc);
            else if (apc.GetType() == typeof(AnalisisReferenciaCambios))
                Construir((AnalisisReferenciaCambios)apc);
            else if (apc.GetType() == typeof(AnalisisColeccionCambios))
                Construir((AnalisisColeccionCambios)apc);
        }

        private void Construir(AnalisisAtributoCambios aac)
        {
            IObjetoDatos antiguo = aac.AnalisisObjetoCambios.ObjetoDatosAntiguo;
            if (antiguo == null) return;

            IObjetoDatos cambios = ObjetoCambios;            
            IPropiedad propiedad = aac.Propiedad;

            cambios.Establecer(propiedad, antiguo.Obtener(propiedad));
        }

        private void Construir(AnalisisReferenciaCambios arc)
        {
            Construir(arc.Referencia, arc.Propiedad);
        }

        private void Construir(AnalisisColeccionCambios acc)
        {
            foreach (AnalisisObjetoCambios aoc in acc.Coleccion)
                Construir(aoc, acc.Propiedad);
        }

        private void Construir(AnalisisObjetoCambios aoc, IPropiedad propiedad)
        {
            if (propiedad.Asociacion == Asociacion.Composicion)
                ConstruirComposicion(aoc, propiedad);
            else if (propiedad.Asociacion == Asociacion.Agregacion)
                ConstruirAgregacion(aoc, propiedad);
        }

        private void ConstruirComposicion(AnalisisObjetoCambios aoc, IPropiedad propiedad)
        {
            if (propiedad.Asociacion != Asociacion.Composicion || aoc.Cambio == Cambio.Ninguno) return;

            IObjetoDatos objetoCambios = ObjetoCambios;
            ObjetoCambios itemCambios = (objetoCambios.CrearObjetoDatos(propiedad) as ObjetoCambios);
            BuilderObjetoCambios builder = null;
            
            builder = new BuilderObjetoCambios(itemCambios);
            builder.Construir(aoc);            
        }

        private void ConstruirAgregacion(AnalisisObjetoCambios aoc, IPropiedad propiedad)
        {
            if (propiedad.Asociacion != Asociacion.Agregacion || aoc.Cambio == Cambio.Ninguno) return;

            IObjetoDatos objetoCambios = ObjetoCambios;

            ObjetoCambios itemCambios = new Fabrica().Crear(propiedad.Tipo);
            BuilderObjetoCambios builder = new BuilderObjetoCambios(itemCambios);
            builder.Construir(aoc);

            objetoCambios.EstablecerObjetoDatos(propiedad, itemCambios);
        }

        private IObjetoCambios ObjetoCambios
        {
            get;
        }

        
    }
}
