using System;
using Binapsis.Plataforma.Estructura;
using Binapsis.Plataforma.Configuracion;
using System.Collections.Generic;
using System.Linq;

namespace Binapsis.Plataforma.Datos.Impl
{
    public class ComandoBase : IComando
    {
        #region Constructores
        public ComandoBase(Comando comando)
            : this(comando, new Parametros(comando))
        {            
        }

        protected ComandoBase(Comando comando, Parametros parametros)
        {
            Comando = comando;
            Parametros = parametros;
        }
        #endregion


        #region Metodos
        public virtual void Ejecutar()
        {
            throw new NotImplementedException();
        }

        public virtual IColeccion EjecutarConsulta()
        {
            throw new NotImplementedException();
        }
        
        public virtual IObjetoDatos EjecutarConsultaSimple()
        {
            throw new NotImplementedException();
        }

        public virtual void EstablecerParametro(string nombre, object valor)
        {
            if (Parametros.Existe(nombre))
                Parametros[nombre].Valor = valor;            
        }

        public virtual void EstablecerParametro(int indice, object valor)
        {
            if (indice >= 0 && indice < Parametros.Contar())
                Parametros[indice].Valor = valor;
        }

        public virtual object ObtenerParametro(string nombre)
        {            
            return Parametros[nombre].Valor;
        }

        public virtual object ObtenerParametro(int indice)
        {
            return Parametros[indice]?.Valor;
        }  
        
        public virtual IList<ParametroComando> ObtenerParametroSalida()
        {
            return Parametros.Where(item => item.Direccion == "OUT").ToList();
        }
        #endregion


        #region Propiedades
        public ComandoTipo ComandoTipo
        {
            get => Comando.ComandoTipo;
        }

        protected Comando Comando
        {
            get;
        }

        public Parametros Parametros
        {
            get;
        }

        public string Sql
        {
            get => Comando.Sql;            
        }                
        #endregion

    }
}
