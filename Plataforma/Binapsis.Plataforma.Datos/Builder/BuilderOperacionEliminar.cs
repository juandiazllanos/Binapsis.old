using Binapsis.Plataforma.Datos.Operacion;
using Binapsis.Plataforma.Datos.Impl;
using Binapsis.Plataforma.Datos.Mapeo;

namespace Binapsis.Plataforma.Datos.Builder
{
    class BuilderOperacionEliminar : BuilderOperacion
    {
        public BuilderOperacionEliminar(OperacionEscritura operacion) 
            : base(operacion)
        {
        }
        
        protected override ComandoEscritura CrearComando()
        {
            ComandoEscritura comando = new ComandoEscritura();
            MapeoTabla mapeoTabla = MapeoCatalogo.ObtenerMapeoTabla(ObjetoDatos.Tipo);
            BuilderComandoDelete builder = new BuilderComandoDelete(comando);

            builder.MapeoTabla = mapeoTabla;
            builder.Construir();

            return comando;
        }
    }
}
