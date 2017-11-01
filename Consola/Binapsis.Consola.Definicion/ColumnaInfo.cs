namespace Binapsis.Consola.Definicion
{
    public class ColumnaInfo : DefinicionBase
    {
        internal ColumnaInfo(ContenidoInfo contenidoInfo)
        {
            ContenidoInfo = contenidoInfo;
        }

        public int Ancho
        {
            get;
            set;
        }

        public ContenidoInfo ContenidoInfo
        {
            get;
        }

        public int Indice
        {
            get;
            set;
        }
        
        public string Texto
        {
            get;
            set;
        }
    }
}
