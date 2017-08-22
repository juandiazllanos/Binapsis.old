using Microsoft.AspNetCore.Mvc;
using Binapsis.Plataforma.Estructura;
using Binapsis.Plataforma.Configuracion.Datos;
using Binapsis.Plataforma.Datos;
using Binapsis.Plataforma.Configuracion;
using System;
using System.Linq;
using Microsoft.AspNetCore.Http;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Binapsis.Plataforma.ServicioConfiguracion.Controllers
{
    public class ContextoController<T> : Controller where T : ConfiguracionBase
    {
        public ContextoController(ContextoInfo contextoInfo)
        {
            ContextoInfo = contextoInfo;
            Contexto = ContextoHelper.CrearContexto(contextoInfo);
        }

        #region Metodos        
        protected T Obtener(string clave) 
        {
            Recuperar recuperar = RecuperarHelper.CrearComando(Contexto, typeof(T));
            recuperar.EstablecerParametro(0, clave);
            IObjetoDatos od = recuperar.EjecutarConsultaSimple();            
            T instancia = Fabrica.Instancia.Crear<T>(od);
            return instancia; 
        }

        protected IColeccion ObtenerColeccion(IQueryCollection query)
        {
            ConsultaHelper<T> consultaHelper = new ConsultaHelper<T>(ContextoInfo);
            return consultaHelper.Ejecutar(query);
        }
        
        protected void Crear(T od)
        {            
            Crear crear = new Crear(Contexto);
            crear.Ejecutar(od);
        }

        protected void Editar(string clave, T od)
        {            
            Editar editar = new Editar(Contexto);
            editar.Ejecutar(od, clave);
        }

        protected void Eliminar(string clave)
        {            
            T od = Obtener(clave);
            if (od == null) return;

            Eliminar eliminar = new Eliminar(Contexto);
            eliminar.Ejecutar(od);
        }
        #endregion


        #region Propiedades
        protected IContexto Contexto
        {
            get;
        }

        protected ContextoInfo ContextoInfo
        {
            get;
        }

        //protected virtual Type Type
        //{
        //    get;
        //}
        #endregion
    }
}
