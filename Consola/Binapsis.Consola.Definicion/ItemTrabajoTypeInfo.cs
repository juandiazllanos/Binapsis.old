namespace Binapsis.Consola.Definicion
{
    public class ItemTrabajoTypeInfo : DefinicionTypeInfo
    {
        public ItemTrabajoTypeInfo(TrabajoInfo trabajoInfo)
        {
            TrabajoInfo = trabajoInfo;
        }

        public TrabajoInfo TrabajoInfo
        {
            get;
        }
    }
}
