using System;

namespace Binapsis.Plataforma.Configuracion.Win.Modelo
{
    class ElementoTabla : ElementoDefinicion
    {
        public ElementoTabla(Elemento padre, Definicion definicion) 
            : base(padre, definicion)
        {
        }

        protected override Type ObtenerTypeItem(Definicion definicion)
        {
            return typeof(Columna);
        }
    }
}
