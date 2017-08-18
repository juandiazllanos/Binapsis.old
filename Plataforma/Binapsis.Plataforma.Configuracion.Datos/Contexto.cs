using Binapsis.Plataforma.Datos;
using Binapsis.Plataforma.Estructura;

namespace Binapsis.Plataforma.Configuracion.Datos
{
    class Contexto : IContexto
    {
        IContexto _contexto;

        #region Constructores
        public Contexto(IContexto contexto)
        {
            _contexto = contexto;
        }
        #endregion


        #region Metodos
        public void AbrirConexion()
        {
            _contexto.AbrirConexion();
        }

        public void CerrarConexion()
        {
            _contexto.CerrarConexion();
        }

        public void DeshacerTransaccion()
        {
            _contexto.DeshacerTransaccion();
        }

        public virtual void EjecutarComando(IComando comando)
        {
            _contexto.EjecutarComando(comando);
        }

        public IResultado EjecutarConsulta(IComando comando)
        {
            return _contexto.EjecutarConsulta(comando);
        }

        public void IniciarTransaccion()
        {
            _contexto.IniciarTransaccion();
        }

        public IClave ObtenerClave(ITipo tipo)
        {
            return new Clave(tipo);
        }

        public void TerminarTransaccion()
        {
            _contexto.TerminarTransaccion();
        }
        #endregion


        #region Propiedades
        public string CadenaConexion
        {
            get => _contexto.CadenaConexion;
            set => _contexto.CadenaConexion = value;
        }

        public string Nombre
        {
            get => _contexto.Nombre;
            set => _contexto.Nombre = value;
        }
        #endregion

    }
}
