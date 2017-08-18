namespace Binapsis.Plataforma.Configuracion.Presentacion.Win.Builder
{
    class BuilderSecuenciaSeleccionar : BuilderSecuencia
    {
        public override void Construir()
        {   
            Secuencia.Agregar("Seleccionar");
            Secuencia.Agregar("Recuperar");

            Secuencia.Asociar("Seleccionar", "Recuperar");

            Secuencia.Inicio = "Seleccionar";
        }
    }
}
