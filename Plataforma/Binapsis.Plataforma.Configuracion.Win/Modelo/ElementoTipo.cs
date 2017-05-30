using System;

namespace Binapsis.Plataforma.Configuracion.Win.Modelo
{
    class ElementoTipo : ElementoDefinicion
    {
        public ElementoTipo(Elemento padre, Definicion definicion) 
            : base(padre, definicion)
        {
        }

        protected override Type ObtenerType(Definicion definicion)
        {
            return typeof(Tipo);
        }

        protected override Type ObtenerTypeItem(Definicion definicion)
        {
            return typeof(Propiedad);
        }

        protected override ElementoDefinicion CrearElemento(Definicion definicion)
        {
            return new ElementoPropiedad(this, definicion);
        }
        
    }
}
