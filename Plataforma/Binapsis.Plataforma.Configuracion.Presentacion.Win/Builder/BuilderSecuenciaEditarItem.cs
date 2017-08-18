using Binapsis.Plataforma.Configuracion.Presentacion.Win.Actividades;

namespace Binapsis.Plataforma.Configuracion.Presentacion.Win.Builder
{
    class BuilderSecuenciaEditarItem : BuilderSecuencia
    {
        public override void Construir()
        {
            Secuencia.Agregar("Recuperar");
            Secuencia.Agregar("RecuperarItem", typeof(RecuperarItem));
            Secuencia.Agregar("MostrarItem", typeof(MostrarItem));
            Secuencia.Agregar("Editar");

            Secuencia.Asociar("Recuperar", "RecuperarItem");
            Secuencia.Asociar("RecuperarItem", "MostrarItem");
            Secuencia.Asociar("MostrarItem", "Editar");

            Secuencia.Inicio = "Recuperar";
        }
    }
}
