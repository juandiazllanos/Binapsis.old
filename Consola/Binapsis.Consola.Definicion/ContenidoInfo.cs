namespace Binapsis.Consola.Definicion
{
    public class ContenidoInfo : ItemConsolaTypeInfo
    {
        internal ContenidoInfo(ConsolaInfo consolaInfo) 
            : base(consolaInfo)
        {
            Columnas = new Columnas(this);
        }

        public Columnas Columnas
        {
            get;
        }

        public ConsultaInfo ConsultaInfo
        {
            get;
            set;
        }        
    }
}
