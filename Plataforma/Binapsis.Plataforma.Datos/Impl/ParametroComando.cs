using Binapsis.Plataforma.Configuracion;
using System;
//using ParametroDescriptor = Binapsis.Plataforma.Configuracion.Parametro;

namespace Binapsis.Plataforma.Datos.Impl
{
    public class ParametroComando
    {
        Parametro _parametro;
        protected object _valor;

        #region Constructores
        public ParametroComando(Parametro parametro)
        {
            _parametro = parametro;
        }
        #endregion


        #region Metodos
        protected virtual void Establecer(object valor)
        {
            if (Type != null)
                _valor = Convert.ChangeType(valor, Type);
            else
                _valor = valor;
        }
        #endregion


        #region Propiedades
        public string Direccion
        {
            get => _parametro.Direccion;            
        }
                
        public string Nombre
        {
            get => _parametro.Nombre;            
        }

        public int Longitud
        {
            get => _parametro.Longitud;
        }

        public int Indice
        {
            get => _parametro.Indice;            
        }

        public Type Type
        {
            get;
            set;
        }

        public object Valor
        {
            get => _valor;
            set => Establecer(value);
        }
        #endregion

    }
}
