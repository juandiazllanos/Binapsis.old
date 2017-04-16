using System.Collections.Generic;
using Binapsis.Plataforma.Estructura;
using System.Linq;

namespace Binapsis.Plataforma.Serializacion.Interno
{
    internal class NodoObjeto : Nodo, INodoObjeto
    {
        IEnumerable<IPropiedad> _atrib;
        IEnumerable<INodoReferencia> _refer;

        protected NodoObjeto(ObjetoMap omap)
        {
            Objeto = omap;
        }

        public NodoObjeto(NodoReferencia padre, ObjetoMap omap) 
            : base(padre)
        {
            Objeto = omap;
        }
        
        public bool EsProxy { get; set; }

        public int Indice { get; set; }

        public ObjetoMap Objeto { get; }

        public string Ruta { get; set; }

        public ITipo Tipo
        {
            get { return Objeto.ObjetoDatos.Tipo; }
        }

        #region INodoObjeto
        int INodoObjeto.Id
        {
            get { return Objeto.Id; }
        }

        string INodoObjeto.Propietario
        {
            get { return Objeto.Propietario; }
        }

        IObjetoDatos INodoObjeto.ObjetoDatos
        {
            get { return Objeto.ObjetoDatos; }
        }

        IEnumerable<IPropiedad> INodoObjeto.Atributos
        {
            get
            {
                if (EsProxy) return new List<IPropiedad>();

                if (_atrib == null)
                {
                    _atrib = from IPropiedad propiedad in Objeto.ObjetoDatos.Tipo.Propiedades
                             where propiedad.Tipo.EsTipoDeDato && Objeto.ObjetoDatos.Establecido(propiedad)
                             select propiedad;
                }

                return _atrib;
            }
        }

        IEnumerable<INodoReferencia> INodoObjeto.Referencias
        {
            get
            {
                if (EsProxy) return new List<INodoReferencia>();

                if (_refer == null)
                {
                    _refer = from NodoReferencia item in Nodos
                             where !item.Propiedad.Tipo.EsTipoDeDato
                             select item;
                }

                return _refer;
            }
        }
        #endregion

    }
}
