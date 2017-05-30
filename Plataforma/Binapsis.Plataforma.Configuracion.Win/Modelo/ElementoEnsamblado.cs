using System;

namespace Binapsis.Plataforma.Configuracion.Win.Modelo
{
    class ElementoEnsamblado : ElementoDefinicion
    {        
        public ElementoEnsamblado(Elemento padre, Definicion definicion) 
            : base(padre, definicion)
        {
        }

        protected override Type ObtenerType(Definicion definicion)
        {
            return typeof(Ensamblado);
        }

        protected override Type ObtenerTypeItem(Definicion definicion)
        {
            return typeof(Uri);
        }

        protected override ElementoDefinicion CrearElemento(Definicion definicion)
        {
            return new ElementoUri(this, definicion);
        }
        
    }
}
