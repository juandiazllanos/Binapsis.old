using Binapsis.Plataforma.AgenteDatos.Helper;
using Binapsis.Plataforma.Cambios;
using Binapsis.Plataforma.Estructura;
using Binapsis.Plataforma.Estructura.Impl;

using System.Collections.Generic;

namespace Binapsis.Plataforma.AgenteDatos
{
    public class ServicioDatos
    {
        string _url;
        string _contexto;
        IFabrica _fabrica;
        
        public ServicioDatos(string url, string contexto, IFabrica fabrica)
        {
            _url = url;
            _contexto = contexto;
            _fabrica = fabrica;
        }
        
        public IObjetoDatos ObtenerObjetoDatos(ITipo tipo, object id)
        {
            ObjetoDatosHelper helper = new ObjetoDatosHelper(_url, _contexto);
            return helper.Obtener(_fabrica, tipo, id);
        }

        public IObjetoDatos ObtenerObjetoDatos(ITipo tipo, string clave, object valor)
        {
            ObjetoDatosHelper helper = new ObjetoDatosHelper(_url, _contexto);
            return helper.Obtener(_fabrica, tipo, clave, valor);
        }

        public IColeccion ObtenerColeccion(ITipo tipo)
        {
            ColeccionHelper helper = new ColeccionHelper(_url, _contexto);
            return helper.Obtener(_fabrica, tipo);
        }

        public IColeccion ObtenerColeccion(ITipo tipo, string clave, object valor)
        {
            ColeccionHelper helper = new ColeccionHelper(_url, _contexto);
            return helper.Obtener(_fabrica, tipo, clave, valor);
        }

        public IColeccion ObtenerColeccion(ITipo tipo, IDictionary<string, object> parametros)
        {
            ColeccionHelper helper = new ColeccionHelper(_url, _contexto);
            return helper.Obtener(_fabrica, tipo, parametros);
        }


        public void CrearObjetoDatos(IObjetoDatos od)
        {
            ObjetoDatosHelper helper = new ObjetoDatosHelper(_url, _contexto);
            helper.Crear(od);
        }

        public void CrearColeccion(IColeccion col)
        {
            ColeccionHelper helper = new ColeccionHelper(_url, _contexto);
            helper.Crear(col);
        }

        public void EditarObjetoDatos(IObjetoDatos od)
        {
            ObjetoDatosHelper helper = new ObjetoDatosHelper(_url, _contexto);
            helper.Editar(od);
        }

        public void EditarColeccion(IColeccion col)
        {
            ColeccionHelper helper = new ColeccionHelper(_url, _contexto);
            helper.Editar(col);
        }

        public void EliminarObjetoDatos(IObjetoDatos od)
        {
            ObjetoDatosHelper helper = new ObjetoDatosHelper(_url, _contexto);
            helper.Eliminar(od);
        }

        public void EliminarColeccion(Coleccion col)
        {
            ColeccionHelper helper = new ColeccionHelper(_url, _contexto);
            helper.Eliminar(col);
        }

        public void Establecer(IDiagramaDatos dd)
        {
            DiagramaDatosHelper helper = new DiagramaDatosHelper(_url, _contexto);
            helper.Establecer(dd);
        }

        public void Establecer(IList<IDiagramaDatos> items)
        {
            DiagramaDatosHelper helper = new DiagramaDatosHelper(_url, _contexto);
            helper.Establecer(items);
        }

    }
}
