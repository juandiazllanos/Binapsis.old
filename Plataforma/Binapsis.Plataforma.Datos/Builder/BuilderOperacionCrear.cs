using Binapsis.Plataforma.Datos.Operacion;
using Binapsis.Plataforma.Datos.Impl;
using Binapsis.Plataforma.Datos.Mapeo;
using Binapsis.Plataforma.Configuracion;

namespace Binapsis.Plataforma.Datos.Builder
{
    class BuilderOperacionCrear : BuilderOperacion
    {
        public BuilderOperacionCrear(OperacionEscritura operacion) 
            : base(operacion)
        {
        }
        
        protected override ComandoEscritura CrearComando()
        {
            Comando comando = Fabrica.Instancia.Crear<Comando>();
            MapeoTabla mapeoTabla = MapeoCatalogo.ObtenerMapeoTabla(ObjetoDatos.Tipo);
            BuilderComando builder = new BuilderComandoInsert(comando);

            builder.MapeoTabla = mapeoTabla;
            builder.Construir();

            return new ComandoEscritura(comando, mapeoTabla);
        }
    }
}
