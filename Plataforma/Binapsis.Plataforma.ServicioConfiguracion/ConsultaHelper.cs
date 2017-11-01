using Binapsis.Plataforma.Configuracion;
using Binapsis.Plataforma.Configuracion.Datos;
using Binapsis.Plataforma.Datos;
using Binapsis.Plataforma.Estructura;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Binapsis.Plataforma.ServicioConfiguracion
{
    class ConsultaHelper<T>
    {        
        public ConsultaHelper(ContextoInfo contextoInfo)
        {
            ContextoInfo = contextoInfo;
            Tipo = Types.Instancia.Obtener(typeof(T));
            Parametros = new List<ConsultaParametro>();
        }
        
        public IColeccion Ejecutar(IQueryCollection query)
        {
            ConstruirParametros(query);

            IContexto contexto = ContextoHelper.CrearContexto(ContextoInfo);
            IPropiedad[] propiedades = Parametros.Select(item => item.Propiedad).ToArray();
            Recuperar recuperar = RecuperarHelper.CrearComando(contexto, Tipo, propiedades);

            foreach (ConsultaParametro parametro in Parametros)
                recuperar.EstablecerParametro(parametro.Propiedad, parametro.Valor);

            return recuperar.EjecutarConsulta();
        }
        
        private void ConstruirParametros(IQueryCollection query)
        {
            ConsultaParametro item = null;

            Parametros.Clear();

            foreach (var kvp in query)
            {
                item = CrearParametro(kvp.Key, kvp.Value);
                if (item == null) continue;
                Parametros.Add(item);
            }
        }
        
        private ConsultaParametro CrearParametro(string propiedad, string valor)
        {
            IPropiedad propiedadItem = null;

            if (Tipo.ContienePropiedad(propiedad))
                propiedadItem = Tipo[propiedad];
            else
                propiedadItem = Tipo.Propiedades.FirstOrDefault(item => item.Nombre.Equals(propiedad, StringComparison.OrdinalIgnoreCase));

            if (propiedadItem != null)
                return new ConsultaParametro(propiedadItem, valor);
            else
                return null;
        }

        private ContextoInfo ContextoInfo
        {
            get;
        }

        public IList<ConsultaParametro> Parametros
        {
            get;
        }

        public ITipo Tipo
        {
            get;
        }
    }
}
