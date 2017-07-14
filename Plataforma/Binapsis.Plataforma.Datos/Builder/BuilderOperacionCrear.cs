using Binapsis.Plataforma.Datos.Operacion;
using Binapsis.Plataforma.Datos.Impl;
using Binapsis.Plataforma.Datos.Mapeo;
using System;

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
            ComandoEscritura comando = new ComandoEscritura();
            MapeoTabla mapeoTabla = MapeoCatalogo.ObtenerMapeoTabla(ObjetoDatos.Tipo);
            BuilderComando builder = new BuilderComandoInsert(comando);

            builder.MapeoTabla = mapeoTabla;
            builder.Construir();

            return comando;
        }
    }
}
