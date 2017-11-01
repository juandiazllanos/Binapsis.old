using Binapsis.Consola.Controllers;
using Binapsis.Consola.Definicion;
using Binapsis.Consola.Helpers;
using Binapsis.Consola.Navegacion;

namespace Binapsis.Consola.Estructura
{
    public class Pagina : ElementoMain
    {
        public Pagina(Main main, Categoria categoria) 
            : base(main, categoria)
        {
            Acciones = new Acciones(this);
        }

        #region Metodos
        public Contenido CrearContenido()
        {
            Contenido contenido = TypeInfoHelper.Crear(ContenidoInfo.TypeInfo, ContenidoInfo) as Contenido;
            contenido.Pagina = this;
            return contenido;
        }

        public Modelo CrearModelo()
        {
            object item = Controller?.ItemSeleccionado;
            Modelo modelo = new Modelo(ModeloInfo, item);
            return modelo;
        }        
        #endregion


        #region Propiedades
        public Acciones Acciones
        {
            get;
        }

        public Categoria Categoria
        {
            get => Elemento as Categoria;
        }
        
        public ContenidoInfo ContenidoInfo
        {
            get;
            set;
        }

        public PaginaController Controller
        {
            get;
            set;
        }

        public ModeloInfo ModeloInfo
        {
            get;
            set;
        }
        #endregion
    }
}
