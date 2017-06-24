using Binapsis.Plataforma.Cambios.Impl;
using Binapsis.Plataforma.Estructura;
using System.Linq;

namespace Binapsis.Plataforma.Cambios.Builder
{
    class BuilderResumenCambios
    {
        public BuilderResumenCambios(ResumenCambios resumen, IObjetoDatos datos)
        {
            ResumenCambios = resumen;
            ObjetoDatos = datos;
        }

        public void Construir(IObjetoCambios cambios)
        {
            Construir(cambios, ObjetoDatos);
        }
                
        private void Construir(IObjetoCambios cambios, IObjetoDatos datos)
        {
            if (cambios.Cambio == Cambio.Ninguno) return;

            ResumenCambios.Agregar(datos, cambios);

            if (cambios.Cambio == Cambio.Eliminado) return;

            var referencias = cambios.Tipo.Propiedades.Where(item => !item.Tipo.EsTipoDeDato && cambios.Establecido(item));

            foreach (IPropiedad propiedad in referencias)
                Construir(propiedad, cambios);
        }

        private void Construir(IPropiedad propiedad, IObjetoCambios cambios)
        {
            if (propiedad.EsColeccion)
                ConstruirColeccion(propiedad, cambios);
            else
                ConstruirReferencia(propiedad, cambios.ObtenerObjetoDatos(propiedad) as IObjetoCambios);
        }

        private void ConstruirColeccion(IPropiedad propiedad, IObjetoCambios cambios)
        {
            IColeccion coleccion = cambios.ObtenerColeccion(propiedad);
            foreach (IObjetoCambios itemCambios in coleccion)
                ConstruirReferencia(propiedad, itemCambios);
        }

        private void ConstruirReferencia(IPropiedad propiedad, IObjetoCambios cambios)
        {
            //if (cambios == null) return;

            IObjetoDatos referenciaDatos = null;
            IObjetoCambios referenciaCambios = cambios; //.ObtenerObjetoDatos(propiedad) as IObjetoCambios;

            if (referenciaCambios.Cambio == Cambio.Eliminado)
                referenciaDatos = referenciaCambios;
            else
                referenciaDatos = ObjetoDatos.ObtenerObjetoDatos(referenciaCambios.Referencia);

            ConstruirReferencia(propiedad, referenciaCambios, referenciaDatos);
        }

        private void ConstruirReferencia(IPropiedad propiedad, IObjetoCambios cambios, IObjetoDatos datos)
        {
            Construir(cambios, datos);
        }

        private IObjetoDatos ObjetoDatos
        {
            get;
            set;
        }

        public ResumenCambios ResumenCambios
        {
            get;
        }
    }
}
