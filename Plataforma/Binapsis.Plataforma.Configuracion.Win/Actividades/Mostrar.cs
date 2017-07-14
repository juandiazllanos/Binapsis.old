using Binapsis.Plataforma.Configuracion.Win.Vistas;
using Binapsis.Presentacion.Editores;
using Binapsis.Presentacion.Win;

namespace Binapsis.Plataforma.Configuracion.Win.Actividades
{
    class Mostrar : Actividad
    {
        VistaBase _vista;

        public Mostrar(VistaBase vista)
        {
            _vista = vista;
        }

        public override void Iniciar()
        {
            _vista.Actividad = this;
            _vista.Establecer(Estado);

            IDialogo dialogo = new Dialogo() { Editor = _vista };            
            dialogo.Mostrar();

            if (dialogo.Resultado == ResultadoDialogo.OK)
                Terminar();
            else
                Cancelar();
        }                
    }
}
