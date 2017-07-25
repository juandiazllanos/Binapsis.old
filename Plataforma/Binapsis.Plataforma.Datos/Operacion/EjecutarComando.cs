using Binapsis.Plataforma.Datos.Helper;
using Binapsis.Plataforma.Datos.Impl;
using Binapsis.Plataforma.Datos.Mapeo;
using Binapsis.Plataforma.Estructura;
using System;

namespace Binapsis.Plataforma.Datos.Operacion
{
    class EjecutarComando : OperacionBase, IComando
    {
        public EjecutarComando(IComando comando)
        {
            Comando = comando;
            MapeoTabla = (comando as ComandoTabla)?.MapeoTabla;
        }

        #region Metodos
        public override void Ejecutar()
        {
            
        }

        public IColeccion EjecutarConsulta()
        {
            ComandoLectura comando = (Comando as ComandoLectura);
            if (comando == null) throw new Exception("Comando de lectura no es válido.");

            IColeccion coleccion;

            try
            {
                Contexto.AbrirConexion();
                coleccion = Helper.RecuperarColeccion(comando);
            }
            finally
            {
                Contexto.CerrarConexion();
            }

            return coleccion;
        }

        public IObjetoDatos EjecutarConsultaSimple()
        {
            ComandoLectura comando = (Comando as ComandoLectura);
            if (comando == null) throw new Exception("Comando de lectura no es válido.");

            IObjetoDatos od;

            try
            {
                Contexto.AbrirConexion();
                od = Helper.Recuperar(comando);
            }
            finally
            {
                Contexto.CerrarConexion();
            }

            return od;
        }


        public void EstablecerParametro(int indice, object valor)
        {
            Comando.EstablecerParametro(indice, valor);
        }

        public void EstablecerParametro(string nombre, object valor)
        {
            Comando.EstablecerParametro(nombre, valor);
        }

        public object ObtenerParametro(int indice)
        {
            return Comando.ObtenerParametro(indice);
        }

        public object ObtenerParametro(string nombre)
        {
            return Comando.ObtenerParametro(nombre);
        }
        #endregion


        #region Propiedades
        private IComando Comando
        {
            get;
            set;
        }
        
        public RecuperarHelper Helper
        {
            get;
            set;
        }

        internal MapeoTabla MapeoTabla
        {
            get;
            set;
        }
        #endregion

    }
}
