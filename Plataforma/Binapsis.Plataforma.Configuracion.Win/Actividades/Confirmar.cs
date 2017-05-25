using Binapsis.Plataforma.Estructura.Impl;
using System.Windows.Forms;

namespace Binapsis.Plataforma.Configuracion.Win.Actividades
{
    class Confirmar : Actividad 
    {
        public override void Iniciar()
        {
            if (MessageBox.Show($"Confirmar para {Controlador.Accion.Nombre.ToLower()}", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                Terminar();
            else
                Cancelar();
        }
    }
}
