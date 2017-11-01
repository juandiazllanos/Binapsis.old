namespace Binapsis.Consola.Definicion
{
    public class ItemTrabajoBase : DefinicionBase
    {
        internal ItemTrabajoBase(TrabajoInfo trabajoInfo)
        {
            TrabajoInfo = trabajoInfo;
        }

        public TrabajoInfo TrabajoInfo
        {
            get;
        }
    }
}
