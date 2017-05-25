using System;

namespace Binapsis.Plataforma.Configuracion.Win.Modelo
{
    class ElementoRoot : ElementoDefinicion
    {
        public ElementoRoot(IRepositorio repositorio) 
            : base(repositorio)
        {
            Actualizar();            
        }

        public override void Actualizar()
        {
            Definicion definicion = (Definicion)Repositorio.Obtener(typeof(Definicion), null);
            EstablecerDefinicion(definicion);
        }

        protected override ElementoDefinicion CrearElemento(Definicion definicion)
        {
            return new ElementoEnsamblado(this, definicion);
        }

        public override Type Type
        {
            get => null;
        }

        public override Type TypeItem
        {
            get => typeof(Ensamblado);
        }
    }
}
