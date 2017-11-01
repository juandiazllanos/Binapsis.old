using Binapsis.Consola.Definicion;
using Binapsis.Consola.Estructura;
using Binapsis.Consola.Graphics;
using Binapsis.Plataforma;
using Binapsis.Plataforma.Helper;

namespace Binapsis.Consola
{
    public class Main
    {
        #region Constructores
        public Main(ConsolaInfo consolaInfo, string url)
        {
            ConsolaInfo = consolaInfo;
            Url = url;

            Botones = new Botones(this);
            Nodos = new Nodos(this);
            Paginas = new Paginas(this);
            Tabs = new Tabs(this);            
        }
        #endregion


        #region Metodos        
        public void EstablecerContexto(string contexto)
        {            
            HelperConfig.Establecer(Url);
            HelperContext helperContext = new HelperContext(contexto);
            HelperProvider.HelperContext = helperContext;
        }        
        #endregion


        #region Propiedades
        public Botones Botones
        {
            get;
        }

        public ConsolaInfo ConsolaInfo
        {
            get;
        }
        
        public Galeria Galeria
        {
            get;
            set;
        }
        
        public Nodos Nodos
        {
            get;
        }

        public Paginas Paginas
        {
            get;
        }

        public Pagina PaginaActual
        {
            get;
            internal set;
        }

        public Tabs Tabs
        {
            get;
        }

        public string Url
        {
            get;
        }
        #endregion

    }
}
