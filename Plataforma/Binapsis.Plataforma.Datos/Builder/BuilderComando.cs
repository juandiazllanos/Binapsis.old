using Binapsis.Plataforma.Datos.Mapeo;
using System.Collections.Generic;

namespace Binapsis.Plataforma.Datos.Builder
{
    abstract class BuilderComando
    {
        public BuilderComando(Configuracion.Comando comando)
        {
            Comando = comando;            
        }

        public Configuracion.Comando Comando
        {
            get;
        }

        public MapeoTabla MapeoTabla
        {
            get;
            set;
        }

        public IList<MapeoColumna> ParametroColumnas
        {
            get;
            set;
        }

        public virtual void Construir()
        {
            // validar mapeo
            if (MapeoTabla == null) return;
            // construir columnas de parametros
            if (ParametroColumnas == null)
            {
                ParametroColumnas = new List<MapeoColumna>();
                ConstruirParametroColumnas();
            }                
            // construir parametros
            ConstruirParametros();
            // construir sentecia
            ConstruirSentencia(); 
        }

        protected virtual void ConstruirParametroColumnas()
        {            
            var claves = MapeoTabla.ObtenerMapeoColumnaClavePrincipal();
            foreach (MapeoColumna clave in claves)
                ParametroColumnas.Add(clave);
        }

        protected abstract void ConstruirSentencia();

        protected virtual void ConstruirParametros()
        {
            foreach (MapeoColumna mapeoColumna in ParametroColumnas)
                ConstruirParametro(mapeoColumna);
        }

        protected virtual void ConstruirParametro(MapeoColumna mapeoColumna)
        {
            Configuracion.Parametro parametro = Comando.CrearParametro();
            parametro.Nombre = mapeoColumna.Columna.Nombre;
            parametro.Direccion = "IN";            
        }
        
    }
}
