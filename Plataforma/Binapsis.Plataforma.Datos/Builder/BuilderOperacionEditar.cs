using Binapsis.Plataforma.Datos.Operacion;
using Binapsis.Plataforma.Datos.Impl;
using Binapsis.Plataforma.Datos.Mapeo;
using System.Linq;
using Binapsis.Plataforma.Estructura;
using System.Collections.Generic;
using Binapsis.Plataforma.Configuracion;

namespace Binapsis.Plataforma.Datos.Builder
{
    class BuilderOperacionEditar : BuilderOperacion
    {
        public BuilderOperacionEditar(OperacionEscritura operacion) 
            : base(operacion)
        {
        }
        
        protected override ComandoEscritura CrearComando()
        {
            Comando comando = Fabrica.Instancia.Crear<Comando>();
            MapeoTabla mapeoTabla = MapeoCatalogo.ObtenerMapeoTabla(ObjetoDatos.Tipo);
            BuilderComandoUpdate builder = new BuilderComandoUpdate(comando);

            // update sobre campos tipo valor o tipo referencia agregada
            IList<IPropiedad> cambios = ResumenCambios.ObtenerCambios(ObjetoDatos)
                .Where(item => item.Tipo.EsTipoDeDato || item.Asociacion == Asociacion.Agregacion).ToList();

            builder.MapeoTabla = mapeoTabla;
            builder.Cambios = cambios;
            builder.Construir();

            CantidadCambios = cambios.Count;

            return new ComandoEscritura(comando, mapeoTabla);
        }

        public int CantidadCambios
        {
            get;
            private set;
        }
    }
}
