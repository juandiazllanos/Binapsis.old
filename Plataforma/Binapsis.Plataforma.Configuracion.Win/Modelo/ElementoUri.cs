using System;

namespace Binapsis.Plataforma.Configuracion.Win.Modelo
{
    class ElementoUri : ElementoDefinicion
    {
        public ElementoUri(Elemento padre, Definicion definicion) 
            : base(padre, definicion)
        {
        }

        protected override Type ObtenerType(Definicion definicion)
        {
            return typeof(Uri);
        }

        protected override Type ObtenerTypeItem(Definicion definicion)
        {
            return typeof(Tipo);
        }

        protected override ElementoDefinicion CrearElemento(Definicion definicion)
        {
            return new ElementoTipo(this, definicion);
        }
        

    }
}
