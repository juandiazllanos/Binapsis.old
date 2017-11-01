namespace Binapsis.Consola.Definicion
{
    public class ItemConsolaTypeInfo : DefinicionTypeInfo
    {
        internal ItemConsolaTypeInfo(ConsolaInfo consolaInfo)
        {
            ConsolaInfo = consolaInfo;
        }

        public ConsolaInfo ConsolaInfo
        {
            get;
        }
    }
}
