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

        void IniciarTransaccion();

        void TerminarTransaccion();

        void DeshacerTransaccion();
    }
}
