using Binapsis.Plataforma.Estructura;

namespace Binapsis.Plataforma.Serializacion.Interno
{
    internal class NodoObjetoDatos : Nodo
    {
        #region Constructores
        public NodoObjetoDatos(ObjetoMap omap)
            : this(null, omap)
        {            
        }

        //public NodoObjetoDatos(NodoReferencia padre, ObjetoMap omap) 
        //    : this(padre as Nodo, omap)
        //{
        //}

        public NodoObjetoDatos(Nodo padre, ObjetoMap omap)
            : base(padre)
        {
            ObjetoMap = omap;
        }
        #endregion


        #region Propiedades
        public virtual int Id
        {
            get => ObjetoMap.Id;
        }

        public IObjetoDatos ObjetoDatos
        {
            get => ObjetoMap.ObjetoDatos;
        }

        public virtual ObjetoMap ObjetoMap
        {
            get;
            set;
        }

        public virtual string Propietario
        {
            get => ObjetoMap.Propietario;
        }

        public bool EsProxy
        {
            get;
            set;
        }

        public int Indice
        {
            get;
            set;
        }
        
        public string Ruta
        {
            get;
            set;
        }

        public ITipo Tipo
        {
            get => ObjetoMap.ObjetoDatos.Tipo; 
        }
        #endregion

                
        
        //IEnumerable<IPropiedad> INodoObjetoDatos.Atributos
        //{
        //    get
        //    {
        //        if (EsProxy) return new List<IPropiedad>();

        //        if (_atrib == null)
        //        {
        //            _atrib = from IPropiedad propiedad in ObjetoMap.ObjetoDatos.Tipo.Propiedades
        //                     where propiedad.Tipo.EsTipoDeDato && ObjetoMap.ObjetoDatos.Establecido(propiedad)
        //                     select propiedad;
        //        }

        //        return _atrib;
        //    }
        //}

        //IEnumerable<INodoReferencia> INodoObjetoDatos.Referencias
        //{
        //    get
        //    {
        //        if (EsProxy) return new List<INodoReferencia>();

        //        if (_refer == null)
        //        {
        //            _refer = from NodoReferencia item in Nodos
        //                     where !item.Propiedad.Tipo.EsTipoDeDato
        //                     select item;
        //        }

        //        return _refer;
        //    }
        //}
        //#endregion

    }
}
