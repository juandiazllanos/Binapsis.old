namespace Binapsis.Plataforma.Configuracion.Presentacion.Win.Builder
{
    class BuilderSecuenciaEditar : BuilderSecuencia
    {        
        public override void Construir()
        {
            Secuencia.Agregar("Recuperar");
            Secuencia.Agregar("Mostrar");
            Secuencia.Agregar("Editar");

            Secuencia.Asociar("Recuperar", "Mostrar");
            Secuencia.Asociar("Mostrar", "Editar");

            Secuencia.Inicio = "Recuperar";
        }
    }
}
