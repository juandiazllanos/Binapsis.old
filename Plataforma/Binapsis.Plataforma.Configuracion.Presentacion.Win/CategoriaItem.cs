using Binapsis.Plataforma.Configuracion.Presentacion.Navegacion;

namespace Binapsis.Plataforma.Configuracion.Presentacion.Win
{
    class CategoriaItem : Categoria
    {
        public CategoriaItem(string propiedad)
            : base()
        {
            Propiedad = propiedad;
        }

        public string Propiedad
        {
            get;            
        }
    }
}
