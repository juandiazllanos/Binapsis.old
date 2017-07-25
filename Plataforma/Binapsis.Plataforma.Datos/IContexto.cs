namespace Binapsis.Plataforma.Datos
{
    public interface IContexto
    {
        string CadenaConexion
        {
            get;
            set;
        }

        string Nombre
        {
            get;
            set;
        }

        void EjecutarComando(IComando comando);

        IResultado EjecutarConsulta(IComando comando);

        void AbrirConexion();

        void IniciarTransaccion();

        void TerminarTransaccion();

        void DeshacerTransaccion();

        void CerrarConexion();
    }
}
