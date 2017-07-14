using System;

namespace Binapsis.Plataforma.Configuracion.Win.Modelo
{
    public class ElementoDefinicion : Elemento
    {
        Definicion _definicion;
        //Type _typeItem;
        
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
            Type = ObtenerType(definicion);
            TypeItem = ObtenerTypeItem(definicion);

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

        protected virtual Type ObtenerType(Definicion definicion)
        {
            return Propietario?.TypeItem;
        }

        protected virtual Type ObtenerTypeItem(Definicion definicion)
        {
            if (definicion == null) return null;

            Type typeBase = typeof(ConfiguracionBase);
            return typeBase.Assembly.GetType($"{typeBase.Namespace}.{definicion.Valor}");            
        }
                
        protected virtual ElementoDefinicion CrearElemento(Definicion definicion)
        {
            Type type = Type.GetType($"{typeof(ElementoDefinicion).Namespace}.Elemento{definicion.Nombre}");

            if (type != null)
                return (ElementoDefinicion)Activator.CreateInstance(type, new object[] { this, definicion });
            else
                return new ElementoDefinicion(this, definicion);
        }
        
        //public override Type Type
        //{
        //    get;
        //    protected set;
        //}

        //public override Type TypeItem
        //{
        //    get;
        //    protected set;
        //}

    }
}
