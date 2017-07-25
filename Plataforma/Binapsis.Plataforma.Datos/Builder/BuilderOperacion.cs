using Binapsis.Plataforma.Cambios;
using Binapsis.Plataforma.Datos.Impl;
using Binapsis.Plataforma.Datos.Mapeo;
using Binapsis.Plataforma.Datos.Operacion;
using Binapsis.Plataforma.Estructura;

namespace Binapsis.Plataforma.Datos.Builder
{
    abstract class BuilderOperacion
    {
        public BuilderOperacion(OperacionEscritura operacion)
        {
            Operacion = operacion;
        }

        public virtual void Construir()
        {
            Operacion.Contexto = Contexto;
            Operacion.ObjetoDatos = ObjetoDatos;
            Operacion.Comando = CrearComando();
            Operacion.MapeoCatalogo = MapeoCatalogo;
            Operacion.MapeoTabla = MapeoCatalogo.ObtenerMapeoTabla(ObjetoDatos.Tipo);
        }
        
        protected abstract ComandoEscritura CrearComando();
       

        public IContexto Contexto
        {
            get;
            set;
        }

        public IObjetoDatos ObjetoDatos
        {
            get;
            set;
        }

        public MapeoCatalogo MapeoCatalogo
        {
            get;
            set;
        }

        public OperacionEscritura Operacion
        {
            get;
        }

        public IResumenCambios ResumenCambios
        {
            get;
            set;
        }

    }
}
