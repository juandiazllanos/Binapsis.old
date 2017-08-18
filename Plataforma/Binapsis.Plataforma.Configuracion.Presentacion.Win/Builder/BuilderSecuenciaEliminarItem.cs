using Binapsis.Plataforma.Configuracion.Presentacion.Win.Actividades;

namespace Binapsis.Plataforma.Configuracion.Presentacion.Win.Builder
{
    class BuilderSecuenciaEliminarItem : BuilderSecuencia
    {
        public override void Construir()
        {
            Secuencia.Agregar("Recuperar");
            Secuencia.Agregar("RecuperarItem", typeof(RecuperarItem));
            Secuencia.Agregar("EliminarItem", typeof(EliminarItem));
            Secuencia.Agregar("Editar");

            Secuencia.Asociar("Recuperar", "RecuperarItem");
            Secuencia.Asociar("RecuperarItem", "EliminarItem");
            Secuencia.Asociar("EliminarItem", "Editar");

            Secuencia.Inicio = "Recuperar";
        }
    }
}
