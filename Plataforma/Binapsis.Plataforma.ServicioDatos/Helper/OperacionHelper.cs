using Binapsis.Plataforma.Cambios;
using Binapsis.Plataforma.Cambios.Impl;
using Binapsis.Plataforma.Datos;
using Binapsis.Plataforma.Estructura.Impl;
using Binapsis.Plataforma.ServicioDatos.Impl;
using Binapsis.Plataforma.ServicioDatos.Operaciones;
using System.Collections.Generic;

namespace Binapsis.Plataforma.ServicioDatos.Helper
{
    class OperacionHelper
    {
        IConfiguracion _configuracion;
        IContexto _contexto;
        
        public OperacionHelper(ConfiguracionImpl configuracion, string contexto)
        {
            _configuracion = configuracion;
            _contexto = ContextoHelper.CrearContexto(configuracion.ObtenerConexion(contexto));
        }

        public void Crear(ObjetoDatos od)
        {            
            Crear operacion = new Crear(_configuracion, _contexto);
            operacion.Ejecutar(od);
        }

        public void Crear(Coleccion col)
        {
            Crear operacion = new Crear(_configuracion, _contexto);
            operacion.Ejecutar(col);
        }
                
        public void Editar(ObjetoDatos od)
        {
            Editar operacion = new Editar(_configuracion, _contexto);
            operacion.Ejecutar(od);
        }

        public void Editar(Coleccion col)
        {
            Editar operacion = new Editar(_configuracion, _contexto);
            operacion.Ejecutar(col);
        }

        public void Eliminar(ObjetoDatos od)
        {
            Eliminar operacion = new Eliminar(_configuracion, _contexto);
            operacion.Ejecutar(od);
        }
        
        public void Eliminar(Coleccion col)
        {
            Eliminar operacion = new Eliminar(_configuracion, _contexto);
            operacion.Ejecutar(col);
        }

        public void Ejecutar(DiagramaDatos dd)
        {
            Operacion operacion = new Operacion(_configuracion, _contexto);
            operacion.Ejecutar(dd);
        }

        public void Ejecutar(IList<DiagramaDatos> items)
        {
            Operacion operacion = new Operacion(_configuracion, _contexto);
            operacion.Ejecutar(items as IDiagramaDatos[]);
        }

    }
}
