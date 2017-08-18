namespace Binapsis.Plataforma.Configuracion.Presentacion.Win.Actividades
{
    class Actualizar : Actividad
    {
        public override void Iniciar()
        {
            Entorno.Main.Actualizar();
            Terminar();
        }
    }
}
