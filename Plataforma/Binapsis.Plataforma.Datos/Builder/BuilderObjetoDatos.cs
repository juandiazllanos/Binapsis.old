using Binapsis.Plataforma.Configuracion;
using Binapsis.Plataforma.Configuracion.Helper;
using Binapsis.Plataforma.Datos.Helper;
using Binapsis.Plataforma.Datos.Impl;
using Binapsis.Plataforma.Datos.Mapeo;
using Binapsis.Plataforma.Estructura;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Binapsis.Plataforma.Datos.Builder
{
    class BuilderObjetoDatos
    {
        public BuilderObjetoDatos(IObjetoDatos od)
        {
            ObjetoDatos = od;
        }

        public void Construir()
        {
            foreach (IPropiedad propiedad in ObjetoDatos.Tipo.Propiedades)
                Establecer(propiedad);
        }

        public void Establecer(IPropiedad propiedad)
        {
            if (propiedad.Tipo.EsTipoDeDato)
                EstablecerAtributo(propiedad);
            else 
                EstablecerReferencia(propiedad);            
        }

        private void EstablecerReferencia(IPropiedad propiedad)
        {
            MapeoRelacion mapeoRelacion = MapeoCatalogo.ObtenerMapeoRelacion(ObjetoDatos.Tipo, propiedad);
            if (mapeoRelacion == null) throw new Exception($"La propiedad '{propiedad.Nombre}' no esta asociada a una relación.");

            EstablecerReferencia(mapeoRelacion);
        }

        private void EstablecerReferencia(MapeoRelacion mapeoRelacion)
        {
            IPropiedad propiedad = mapeoRelacion.Propiedad;
                        
            if (propiedad.Asociacion == Asociacion.Agregacion)
                RecuperarObjetoDatos(mapeoRelacion);
            else if (propiedad.Asociacion == Asociacion.Composicion)
                CrearObjetoDatos(mapeoRelacion);            
        }

        private void RecuperarObjetoDatos(MapeoRelacion mapeoRelacion)
        {
            // validar clave
            if (!ValidarClaveSecundaria(mapeoRelacion)) return;
            // obtener referencia del monton
            IObjetoDatos od = RecuperarHelper.Heap.Obtener(Datos.ObtenerClavePrincipal(mapeoRelacion));
            // establecer referencia recuperada
            if (od != null)
            {
                ObjetoDatos.EstablecerObjetoDatos(mapeoRelacion.Propiedad, od);
                return;
            }
            // crear consulta
            ComandoLectura consulta = ConsultaHelper.CrearConsultaTablaPrincipal(mapeoRelacion);            
            // parametrizar consulta
            EstablecerParametros(consulta, mapeoRelacion);
            // establecer referencia
            od = RecuperarHelper.Recuperar(consulta);
            ObjetoDatos.EstablecerObjetoDatos(mapeoRelacion.Propiedad, od);
        }
        
        private void CrearObjetoDatos(MapeoRelacion mapeoRelacion)
        {
            // validar clave
            if (!ValidarClavePrincipal(mapeoRelacion)) return;
            // crear consulta
            ComandoLectura consulta = ConsultaHelper.CrearConsultaTablaSecundaria(mapeoRelacion);
            // parametrizar consulta
            EstablecerParametros(consulta, mapeoRelacion);
            // recuperar referencia
            RecuperarHelper.Recuperar(ObjetoDatos, mapeoRelacion.Propiedad, consulta);            
        }

        private bool ValidarClavePrincipal(MapeoRelacion mapeoRelacion)
        {
            var claves = mapeoRelacion.Claves.Select(item => item.ClavePrincipal);
            return ValidarClave(claves);
        }

        private bool ValidarClaveSecundaria(MapeoRelacion mapeoRelacion)
        {
            var claves = mapeoRelacion.Claves.Select(item => item.ClaveSecundaria);
            return ValidarClave(claves);
        }

        private bool ValidarClave(IEnumerable<MapeoColumna> claves)
        {
            foreach (MapeoColumna mapeoColumna in claves)
                if (ValidarValorInicial(mapeoColumna))
                    return false;

            return true;
        }

        private bool ValidarValorInicial(MapeoColumna mapeoColumna)
        {
            if (mapeoColumna.Propiedad != null)
                return Datos.Obtener(mapeoColumna.Columna) == ValorInicialHelper.Instancia.Obtener(mapeoColumna.Propiedad);
            else
                return false; // no se puede validar, la columna no tiene un tipo
        }

        private void EstablecerParametros(ComandoLectura consulta, MapeoRelacion mapeoRelacion)
        {
            foreach (MapeoRelacionClave clave in mapeoRelacion.Claves)
                if (mapeoRelacion.Propiedad.Asociacion == Asociacion.Agregacion)
                    consulta.EstablecerParametro(clave.ClavePrincipal.Columna, Datos.Obtener(clave.ClaveSecundaria.Columna));
                else 
                    consulta.EstablecerParametro(clave.ClaveSecundaria.Columna, Datos.Obtener(clave.ClavePrincipal.Columna));
        }
        
        private void EstablecerAtributo(IPropiedad propiedad)
        {
            Columna columna = MapeoTabla.ObtenerColumna(propiedad);
            if (columna == null) throw new Exception($"La propiedad '{propiedad.Nombre}' no tiene una columna asociada.");

            MapeoColumna mapeoColumna = MapeoCatalogo.ObtenerMapeoColumna(MapeoTabla, columna);
            if (mapeoColumna == null) throw new Exception($"La columna '{columna.Nombre}' no se ha podido resolver.");

            EstablecerAtributo(mapeoColumna);
        }
        
        private void EstablecerAtributo(MapeoColumna mapeoColumna)
        {
            IPropiedad propiedad = mapeoColumna?.Propiedad;
            if (propiedad == null) throw new Exception($"La propiedad no es válida");

            Columna columna = mapeoColumna?.Columna;
            if (columna == null) throw new Exception($"La columna no es válida");

            switch(propiedad.Tipo.Nombre)
            {
                case "Boolean":
                    ObjetoDatos.EstablecerBoolean(propiedad, Datos.ObtenerBoolean(columna));
                    break;
                case "Byte":
                    ObjetoDatos.EstablecerByte(propiedad, Datos.ObtenerByte(columna));
                    break;
                case "Char":
                    ObjetoDatos.EstablecerChar(propiedad, Datos.ObtenerChar(columna));
                    break;
                case "DateTime":
                    ObjetoDatos.EstablecerDateTime(propiedad, Datos.ObtenerDateTime(columna));
                    break;
                case "Decimal":
                    ObjetoDatos.EstablecerDecimal(propiedad, Datos.ObtenerDecimal(columna));
                    break;
                case "Double":
                    ObjetoDatos.EstablecerDouble(propiedad, Datos.ObtenerDouble(columna));
                    break;
                case "Int16":
                    ObjetoDatos.EstablecerShort(propiedad, Datos.ObtenerShort(columna));
                    break;
                case "Int32":
                    ObjetoDatos.EstablecerInteger(propiedad, Datos.ObtenerInteger(columna));
                    break;
                case "Int64":
                    ObjetoDatos.EstablecerLong(propiedad, Datos.ObtenerLong(columna));
                    break;
                case "SByte":
                    ObjetoDatos.EstablecerSByte(propiedad, Datos.ObtenerSByte(columna));
                    break;
                case "Single":
                    ObjetoDatos.EstablecerFloat(propiedad, Datos.ObtenerFloat(columna));
                    break;
                case "String":
                    ObjetoDatos.EstablecerString(propiedad, Datos.ObtenerString(columna));
                    break;
                case "UInt16":
                    ObjetoDatos.EstablecerUShort(propiedad, Datos.ObtenerUShort(columna));
                    break;
                case "UInt32":
                    ObjetoDatos.EstablecerUInteger(propiedad, Datos.ObtenerUInteger(columna));
                    break;
                case "UInt64":
                    ObjetoDatos.EstablecerULong(propiedad, Datos.ObtenerULong(columna));
                    break;
                    
            }
        }
        

        public ConsultaHelper ConsultaHelper
        {
            get;
            set;
        }

        public ResultadoTabla Datos
        {
            get;
            set;
        }

        public RecuperarHelper RecuperarHelper
        {
            get;
            set;
        }
        

        public IObjetoDatos ObjetoDatos
        {
            get;
            set;
        }
        
        public MapeoCatalogo MapeoCatalogo
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
