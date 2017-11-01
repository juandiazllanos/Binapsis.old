using Binapsis.Plataforma.Configuracion.Helper;
using Binapsis.Plataforma.Datos.Impl;
using Binapsis.Plataforma.Datos.Mapeo;
using Binapsis.Plataforma.Estructura;
using Binapsis.Plataforma.Helper.Impl;
using System;

namespace Binapsis.Plataforma.Datos.Operacion
{
    abstract class OperacionEscritura : OperacionBase
    {
        public override void Ejecutar()
        {
            foreach (ParametroComando parametro in Comando.Parametros)                
                    Establecer(parametro);

            Contexto.EjecutarComando(Comando);
        }
        
        private void Establecer(ParametroComando parametro)
        {
            MapeoColumna mapeoColumna;

            if (parametro is ParametroColumna parametroColumna)
                mapeoColumna = parametroColumna.MapeoColumna;
            else
                mapeoColumna = MapeoCatalogo.ObtenerMapeoColumna(MapeoTabla, parametro.Nombre);

            Establecer(parametro, mapeoColumna);            
        }

        private void Establecer(ParametroComando parametro, MapeoColumna mapeoColumna)
        {
            object valor = null;

            if (mapeoColumna.Propiedad != null && mapeoColumna.Propiedad.Tipo.EsTipoDeDato)
                valor = ObjetoDatos.Obtener(mapeoColumna.Propiedad);
            else if (mapeoColumna is MapeoColumnaClave mapeoColumnaClave)
                valor = ResolverReferencia(mapeoColumnaClave);
            else if (mapeoColumna.Columna.ClavePrimaria)
                valor = mapeoColumna.MapeoTabla.ObtenerPrimaryKey(mapeoColumna.Columna.Nombre).Get(ObjetoDatos); //Contexto.ObtenerClave(mapeoColumna.MapeoTabla.Tipo)?.Obtener(ObjetoDatos, mapeoColumna.Columna.Nombre);
            else
                return; // terminar

            if (valor == null)
                valor = DefaultValueHelper.Instancia.GetDefaultValue(mapeoColumna.Propiedad); //ValorInicialHelper.Instancia.Obtener(mapeoColumna.Propiedad);

            parametro.Valor = valor;
        }

        private object ResolverReferencia(MapeoColumnaClave mapeoColumna)
        {
            MapeoRelacionClave mapeoRelacionClave = mapeoColumna.MapeoRelacionClave;

            ITipo tipo = mapeoColumna.MapeoRelacionClave.MapeoRelacion.Tipo;
            IPropiedad propiedad = mapeoColumna.MapeoRelacionClave.MapeoRelacion.Propiedad;            
            IObjetoDatos od = null;

            if (propiedad.Asociacion == Asociacion.Agregacion)
                od = ObjetoDatos.ObtenerObjetoDatos(propiedad);
            else if (propiedad.Asociacion == Asociacion.Composicion && 
                    ObjetoDatos.Propietario?.Tipo.Nombre == tipo.Nombre)
                od = ObjetoDatos.Propietario;

            //if (od == null) return null;

            if (mapeoRelacionClave == null)
                throw new Exception($"No se ha podido resolver la columna '{mapeoColumna.Columna.Nombre}'.");

            IPrimaryKey pk = mapeoRelacionClave.ObtenerPrimaryKey();

            if (od != null && pk != null)
                return pk.Get(od);
            else
                return null;

            //if (od != null && mapeoRelacionClave.ClavePrincipal.Propiedad != null)
            //    return od.Obtener(mapeoRelacionClave.ClavePrincipal.Propiedad);
            //else 
            //    return Contexto.ObtenerClave(mapeoRelacionClave.MapeoRelacion.TablaPrincipal.Tipo)?.Obtener(od, mapeoRelacionClave.ClavePrincipal.Columna.Nombre);
        }
        
        public ComandoEscritura Comando
        {
            get;
            set;
        }

        public IObjetoDatos ObjetoDatos
        {
            get;
            set;
        }

        public MapeoTabla MapeoTabla
        {
            get;
            set;
        }
    }
}
