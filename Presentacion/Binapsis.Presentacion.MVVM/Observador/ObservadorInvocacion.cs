using Binapsis.Presentacion.MVVM.Controlador;

namespace Binapsis.Presentacion.MVVM.Observador
{
    class ObservadorInvocacion
    {
        ControladorInvocacionModelo _controlador;

        public ObservadorInvocacion(ControladorInvocacionModelo controlador)
        {
            _controlador = controlador;
        }

        public void Notificar(string comando)
        {
            _controlador.Ejecutar(comando);
        }
    }
}
