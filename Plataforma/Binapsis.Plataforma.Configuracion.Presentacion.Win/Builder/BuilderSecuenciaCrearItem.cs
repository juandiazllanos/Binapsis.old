using Binapsis.Plataforma.Configuracion.Presentacion.Win.Actividades;

namespace Binapsis.Plataforma.Configuracion.Presentacion.Win.Builder
{
    class BuilderSecuenciaCrearItem : BuilderSecuencia
    {
        public override void Construir()
        {
            Secuencia.Agregar("Recuperar");
            Secuencia.Agregar("InstanciarItem", typeof(InstanciarItem));
            Secuencia.Agregar("MostrarItem", typeof(MostrarItem));
            Secuencia.Agregar("Editar");

            Secuencia.Asociar("Recuperar", "InstanciarItem");
            Secuencia.Asociar("InstanciarItem", "MostrarItem");
            Secuencia.Asociar("MostrarItem", "Editar");

            Secuencia.Inicio = "Recuperar";
        }
    }
}
