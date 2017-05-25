using System;

namespace Binapsis.Plataforma.Configuracion.Win.Modelo
{
    class ElementoUri : ElementoDefinicion
    {
        public ElementoUri(Elemento padre, Definicion definicion) 
            : base(padre, definicion)
        {
        }

        protected override ElementoDefinicion CrearElemento(Definicion definicion)
        {
            return new ElementoTipo(this, definicion);
        }

        public override Type Type
        {
            get => typeof(Uri);
        }

        public override Type TypeItem
        {
            get => typeof(Tipo);
        }

    }
}
