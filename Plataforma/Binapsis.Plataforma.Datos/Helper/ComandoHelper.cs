using System;
using Binapsis.Plataforma.Estructura;
using Binapsis.Plataforma.Datos.Impl;
using Binapsis.Plataforma.Datos.Mapeo;
using Binapsis.Plataforma.Configuracion;
using Binapsis.Plataforma.Datos.Operacion;

namespace Binapsis.Plataforma.Datos.Helper
{
    public class ComandoHelper : IComando
    {
        IComando _comando;

        public ComandoHelper(IComando comando)
        {
            _comando = comando;
        }

        public void Ejecutar()
        {
            _comando.Ejecutar();
        }

        public IColeccion EjecutarConsulta()
        {
            return _comando.EjecutarConsulta();
        }

        public IObjetoDatos EjecutarConsultaSimple()
        {
            return _comando.EjecutarConsultaSimple();
        }

        public void EstablecerParametro(int indice, object valor)
        {
            _comando.EstablecerParametro(indice, valor);
        }

        public void EstablecerParametro(string nombre, object valor)
        {
            _comando.EstablecerParametro(nombre, valor);
        }

        public void EstablecerParametro(IPropiedad propiedad, object valor)
        {
            MapeoTabla mapeoTabla = (_comando as EjecutarComando)?.MapeoTabla;

            if (mapeoTabla == null)
                mapeoTabla = (_comando as ComandoTabla)?.MapeoTabla;

            if (mapeoTabla == null) throw new Exception("El comando de tabla no es válido.");

            if (propiedad.Tipo.EsTipoDeDato)
                EstablecerParametroAtributo(mapeoTabla, propiedad, valor);
            else
                EstablecerParametroReferencia(mapeoTabla, propiedad, valor);

        }

        private void EstablecerParametroAtributo(MapeoTabla mapeoTabla, IPropiedad propiedad, object valor)
        {            
            Columna columna = mapeoTabla.ObtenerColumna(propiedad);
            EstablecerParametro(columna, valor);
        }

        private void EstablecerParametroReferencia(MapeoTabla mapeoTabla, IPropiedad propiedad, object valor)
        {
            if (propiedad.Tipo.EsTipoDeDato) throw new Exception("La propiedad no es de tipo referencia.");
            if (propiedad.Asociacion != Asociacion.Agregacion) throw new Exception("La propiedad no es de asociación agregado");

            IObjetoDatos od = valor as IObjetoDatos;
            if (od == null) throw new Exception($"Valor no es de tipo '{propiedad.Tipo.Nombre}'.");
            
            MapeoRelacion mapeoRelacion = mapeoTabla.ObtenerMapeoRelacionPorPropiedad(propiedad);
            if (mapeoRelacion == null) throw new Exception($"La propiedad '{propiedad.Nombre}' no tiene una relación asociada.");

            foreach (MapeoRelacionClave clave in mapeoRelacion.Claves)
                EstablecerParametro(clave.ClaveSecundaria.Columna, od.Obtener(clave.ClavePrincipal.Propiedad));
        }

        public void EstablecerParametro(Columna columna, object valor)
        {
            _comando.EstablecerParametro(columna.Nombre, valor);
        }



        public object ObtenerParametro(int indice)
        {
            return _comando.ObtenerParametro(indice);
        }

        public object ObtenerParametro(string nombre)
        {
            return _comando.ObtenerParametro(nombre);
        }


    }
}
