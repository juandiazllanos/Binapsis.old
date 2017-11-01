using Binapsis.Plataforma.Configuracion;
using Binapsis.Plataforma.Estructura;
using Binapsis.Plataforma.Helper;
using Binapsis.Plataforma.Operaciones;

namespace Binapsis.Plataforma
{
    public class EntidadRepositorio
    {
        Contexto _contexto;
        IFabrica _fabrica;

        #region Constructores
        public EntidadRepositorio()
            : this((HelperProvider.HelperContext as HelperContext).Contexto)
        {            
        }

        public EntidadRepositorio(Contexto contexto)
            : this(contexto, HelperProvider.DataFactory as IFabrica)
        {
        }

        public EntidadRepositorio(Contexto contexto, IFabrica fabrica)
        {
            _contexto = contexto;
            _fabrica = fabrica;
        }
        #endregion


        #region Metodos
        public void Guardar(EntidadBase entidad)
        {
            Guardar operacion = new Guardar(_contexto.Url, _contexto.Nombre);
            operacion.Ejecutar(entidad);
        }

        public void Eliminar(EntidadBase entidad)
        {
            Eliminar operacion = new Eliminar(_contexto.Url, _contexto.Nombre);
            operacion.Ejecutar(entidad);
        }

        public EntidadBase Recuperar(Tipo tipo, object id)
        {
            Recuperar operacion = new Recuperar(_contexto.Url, _contexto.Nombre, _fabrica);
            return operacion.Ejecutar(tipo, id);
        }

        public T Recuperar<T>(object id) where T : EntidadBase
        {
            Recuperar operacion = new Recuperar(_contexto.Url, _contexto.Nombre, _fabrica);
            return operacion.Ejecutar<T>(id);
        }
        #endregion

    }
}
