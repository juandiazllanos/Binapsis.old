
using Binapsis.Plataforma.Cambios;
using Binapsis.Plataforma.Datos;
using Binapsis.Plataforma.Datos.Impl;
using Binapsis.Plataforma.Estructura;

namespace Binapsis.Plataforma.Configuracion.Datos
{
    public abstract class Operacion
    {
        public Operacion(IContexto contexto)
            : this(new ContextoBase(contexto))
        {
        }

        internal Operacion(ContextoBase contexto)
        {
            Contexto = contexto;
            Configuracion = new ConfiguracionImpl(ConfiguracionRepositorio.Instancia);
        }

        public abstract void Ejecutar(IObjetoDatos obj);

        protected void Ejecutar(IDiagramaDatos dd)
        {
            IDAS das = new DAS(Configuracion, Contexto);
            das.AplicarCambios(dd);
        }
        
        public IConfiguracion Configuracion
        {
            get;
        }

        public IContexto Contexto
        {
            get;
        }
    }
}
