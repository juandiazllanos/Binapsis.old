namespace Binapsis.Consola.Definicion
{
    public class AsociacionInfo : ItemTrabajoBase
    {
        internal AsociacionInfo(TrabajoInfo trabajoInfo) 
            : base(trabajoInfo)
        {
        }

        public string ActividadDestino
        {
            get;
            set;
        }

        public string ActividadOrigen
        {
            get;
            set;
        }        
    }
}
