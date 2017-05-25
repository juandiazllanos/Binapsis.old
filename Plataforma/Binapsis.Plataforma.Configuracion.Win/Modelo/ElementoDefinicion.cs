using System;

namespace Binapsis.Plataforma.Configuracion.Win.Modelo
{
    public abstract class ElementoDefinicion : Elemento
    {
        Definicion _definicion;
        
        public ElementoDefinicion(IRepositorio repositorio)
            : base(repositorio)
        {            
        }

        public ElementoDefinicion(Elemento padre, Definicion definicion) 
            : base(padre)
        {
            EstablecerDefinicion(definicion);
        }

        public override void Actualizar()
        {
            Definicion definicion = (Repositorio?.Obtener(typeof(Definicion), $"{Nombre}/{Valor}") as Definicion);
            EstablecerDefinicion(definicion);
        }

        protected void EstablecerDefinicion(Definicion definicion)
        {
            Alias = definicion?.Alias;
            Nombre = definicion?.Nombre;
            Valor = definicion?.Valor;

            if (definicion == null)
            {
                Items = new ElementoDefinicion[] { };
                return;
            }
                
            Items = new IElemento[definicion.Definiciones.Longitud];

            for (int i = 0; i < definicion.Definiciones.Longitud; i++)
                Items[i] = CrearElemento((Definicion)definicion.Definiciones[i]); //new ElementoDefinicion(this, (Definicion)definicion.Definiciones[i]);

            _definicion = definicion;
        }

        
        protected abstract ElementoDefinicion CrearElemento(Definicion definicion);
        
        public abstract override Type Type { get; }

        public abstract override Type TypeItem { get; }

    }
}
