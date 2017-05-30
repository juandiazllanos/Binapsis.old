using System;

namespace Binapsis.Plataforma.Configuracion.Win.Modelo
{
    class ElementoPropiedad : ElementoDefinicion
    {
        public ElementoPropiedad(Elemento padre, Definicion definicion) 
            : base(padre, definicion)
        {
        }
     
        protected override ElementoDefinicion CrearElemento(Definicion definicion)
        {
            return null;
        }

        protected override Type ObtenerType(Definicion definicion)
        {
            return typeof(Propiedad);
        }

        protected override Type ObtenerTypeItem(Definicion definicion)
        {
            return null;
        }

    }
}
