namespace Binapsis.Consola.Definicion
{
    public class TypeInfo : ItemConsolaBase 
    {
        internal TypeInfo(ConsolaInfo consolaInfo) 
            : base(consolaInfo)
        {
        }

        public string AssemblyName
        {
            get;
            set;
        }

        public string TypeFullName
        {
            get;
            set;
        }        
    }
}
