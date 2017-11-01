using Binapsis.Consola.Definicion;
using Binapsis.Consola.Helpers;

namespace Binapsis.Consola.Espacios
{
    public class Espacio
    {        
        #region Metodos
        public virtual Accion CrearAccion(AccionInfo accionInfo)
        {
            return new Accion(accionInfo);
        }

        public virtual Contenido CrearContenido()
        {
            return TypeInfoHelper.Crear(ContenidoInfo.TypeInfo, ContenidoInfo) as Contenido;
        }

        public virtual Modelo CrearModelo(object objeto)
        {
            return new Modelo(ModeloInfo, objeto);
        }
        #endregion

        #region Propiedades
        public ModeloInfo ModeloInfo
        {
            get;
            set;
        }

        public ContenidoInfo ContenidoInfo
        {
            get;
            set;
        }
        #endregion
    }
}
