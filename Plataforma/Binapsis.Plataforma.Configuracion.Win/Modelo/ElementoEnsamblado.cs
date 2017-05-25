using System;

namespace Binapsis.Plataforma.Configuracion.Win.Modelo
{
    class ElementoEnsamblado : ElementoDefinicion
    {        
        public ElementoEnsamblado(Elemento padre, Definicion definicion) 
            : base(padre, definicion)
        {
        }
        
        protected override ElementoDefinicion CrearElemento(Definicion definicion)
        {
            return new ElementoUri(this, definicion);
        }

        public override Type Type
        {
            get => typeof(Ensamblado);
        }

        public override Type TypeItem
        {
            get => typeof(Uri);
        }

    }
}
