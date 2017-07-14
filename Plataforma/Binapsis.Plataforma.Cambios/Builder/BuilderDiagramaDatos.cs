using Binapsis.Plataforma.Cambios.Impl;
using Binapsis.Plataforma.Estructura;
using Binapsis.Plataforma.Estructura.Impl;

namespace Binapsis.Plataforma.Cambios.Builder
{
    public class BuilderDiagramaDatos
    {
        public BuilderDiagramaDatos(IDiagramaDatos diagrama)
        {
            DiagramaDatos = diagrama;
        }

        public void Construir(IObjetoDatos nuevo, IObjetoDatos antiguo)
        {
            IObjetoCambios cambios = new Fabrica().Crear(DiagramaDatos.Tipo);
            BuilderObjetoCambios builder = new BuilderObjetoCambios(cambios);

            builder.Construir(nuevo, antiguo);

            IObjetoDatos datos = nuevo ?? antiguo;

            Construir(datos, cambios);
        }

        public void Construir(IObjetoDatos datos, IObjetoCambios cambios)
        {
            ResumenCambios resumen = new ResumenCambios();
            BuilderResumenCambios builder = new BuilderResumenCambios(resumen, datos);

            builder.Construir(cambios);

            DiagramaDatos.ObjetoDatos = datos;
            DiagramaDatos.ResumenCambios = resumen;
        }

        public IDiagramaDatos DiagramaDatos
        {
            get;
        }
    }
}
