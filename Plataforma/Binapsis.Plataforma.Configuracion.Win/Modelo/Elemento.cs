using System;

namespace Binapsis.Plataforma.Configuracion.Win.Modelo
{
    public abstract class Elemento : IElemento
    {
        public Elemento(Elemento padre)
            : this(padre.Repositorio)
        {
            Propietario = padre;
            Root = padre.Root;
        }

        public Elemento(IRepositorio repositorio)            
        {
            Repositorio = repositorio;
            Items = new Elemento[] { };
            Root = this;
        }
        
        public virtual void Actualizar()
        {
            
        }

        public string Alias
        {
            get;
            protected set;
        }

        public IElemento[] Items
        {
            get;
            protected set;
        }

        public string Nombre
        {
            get;
            protected set;
        }

        public IElemento Propietario
        {
            get;            
        }

        public IRepositorio Repositorio
        {
            get;
            protected set;
        }

        public IElemento Root
        {
            get;
            protected set;
        }

        public string Valor
        {
            get;
            protected set;
        }

        public virtual Type Type
        {
            get;
            protected set;
        }

        public virtual Type TypeItem
        {
            get;
            protected set;
        }
        
    }
}
