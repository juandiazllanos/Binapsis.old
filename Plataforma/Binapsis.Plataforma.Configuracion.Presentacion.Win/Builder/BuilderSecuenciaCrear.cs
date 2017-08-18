namespace Binapsis.Plataforma.Configuracion.Presentacion.Win.Builder
{
    class BuilderSecuenciaCrear : BuilderSecuencia
    {
        public override void Construir()
        {            
            Secuencia.Agregar("Instanciar");
            Secuencia.Agregar("Mostrar");
            Secuencia.Agregar("Crear");

            Secuencia.Asociar("Instanciar", "Mostrar");
            Secuencia.Asociar("Mostrar", "Crear");

            Secuencia.Inicio = "Instanciar";
        }
    }
}
