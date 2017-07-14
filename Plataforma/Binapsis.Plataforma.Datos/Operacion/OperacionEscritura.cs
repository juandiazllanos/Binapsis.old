﻿using Binapsis.Plataforma.Configuracion.Helper;
using Binapsis.Plataforma.Datos.Impl;
using Binapsis.Plataforma.Datos.Mapeo;
using Binapsis.Plataforma.Estructura;
using System;

namespace Binapsis.Plataforma.Datos.Operacion
{
    abstract class OperacionEscritura : OperacionBase
    {
        public override void Ejecutar()
        {
            foreach (Parametro parametro in Comando.Parametros)                
                    Establecer(parametro);

            Contexto.EjecutarComando(Comando);
        }
        
        private void Establecer(Parametro parametro)
        {
            MapeoColumna mapeoColumna;

            if (parametro is ParametroColumna parametroColumna)
                mapeoColumna = parametroColumna.MapeoColumna;
            else
                mapeoColumna = MapeoCatalogo.ObtenerMapeoColumna(MapeoTabla, parametro.Nombre);

            Establecer(parametro, mapeoColumna);            
        }

        private void Establecer(Parametro parametro, MapeoColumna mapeoColumna)
        {
            object valor = null;

            if (mapeoColumna.Propiedad != null && mapeoColumna.Propiedad.Tipo.EsTipoDeDato)
                valor = ObjetoDatos.Obtener(mapeoColumna.Propiedad);
            else if (mapeoColumna is MapeoColumnaClave mapeoColumnaClave)
                valor = ResolverReferencia(mapeoColumnaClave);
            else
                return; // terminar

            if (valor == null)
                valor = ValorInicialHelper.Instancia.Obtener(mapeoColumna.Propiedad);

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

            if (od == null || mapeoRelacionClave == null)
                throw new Exception($"No se ha podido resolver la columna '{mapeoColumna.Columna.Nombre}'.");

            return od.Obtener(mapeoRelacionClave.ClavePrincipal.Propiedad);            
        }
        
        public ComandoEscritura Comando
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
