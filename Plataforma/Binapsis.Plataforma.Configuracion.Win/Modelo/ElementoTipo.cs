using System;

namespace Binapsis.Plataforma.Configuracion.Win.Modelo
{
    class ElementoTipo : ElementoDefinicion
    {
        //public ElementoTipo(IRepositorio repositorio, Definicion definicion) 
        //    : base(repositorio, definicion)
        //{
        //}

        public ElementoTipo(Elemento padre, Definicion definicion) 
            : base(padre, definicion)
        {
        }
        
        protected override ElementoDefinicion CrearElemento(Definicion definicion)
        {
            return new ElementoPropiedad(this, definicion);
        }

        public override Type Type
        {
            get => typeof(Tipo);
        }

        public override Type TypeItem
        {
            get => typeof(Propiedad);
        }
    }
}
