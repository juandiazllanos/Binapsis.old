using Binapsis.Plataforma.Estructura;

namespace Binapsis.Plataforma.Serializacion.Interno
{
    internal class NodoObjetoDatos : Nodo
    {
        #region Constructores
        public NodoObjetoDatos()
            : base()
        {
        }

        public NodoObjetoDatos(Nodo nodoPadre)
            : base(nodoPadre)
        {
        }        
        #endregion


        #region Propiedades
        public virtual int Id
        {
            get => ObjetoMap.Id;
        }

        public IObjetoDatos ObjetoDatos
        {
            get; 
            set;
        }

        public virtual ObjetoMap ObjetoMap
        {
            get;
            set;
        }

        public virtual string Propietario
        {
            get => ObjetoMap.Propietario;
            set => ObjetoMap.Propietario = value;
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
            get => ObjetoDatos?.Tipo; 
        }
        #endregion
    }
}
