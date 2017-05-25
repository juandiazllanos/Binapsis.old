using System;

namespace Binapsis.Plataforma.Configuracion.Win.Modelo
{
    class ElementoPropiedad : ElementoDefinicion
    {
        //public ElementoPropiedad(IRepositorio repositorio, Definicion definicion) 
        //    : base(repositorio, definicion)
        //{
        //}

        public ElementoPropiedad(Elemento padre, Definicion definicion) 
            : base(padre, definicion)
        {
        }
        
        protected override ElementoDefinicion CrearElemento(Definicion definicion)
        {
            return null;
        }

        public override Type Type
        {
            get => typeof(Propiedad);
        }

        public override Type TypeItem
        {
            get => null;
        }
    }
}
