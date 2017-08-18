namespace Binapsis.Plataforma.Configuracion.Presentacion.Win.Builder
{
    class BuilderSecuenciaEliminar : BuilderSecuencia
    {
        public override void Construir()
        {
            Secuencia.Agregar("Recuperar");
            Secuencia.Agregar("Eliminar");

            Secuencia.Asociar("Recuperar", "Eliminar");

            Secuencia.Inicio = "Recuperar";
        }
    }
}
