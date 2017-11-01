namespace Binapsis.Consola.Definicion
{
    public class ActividadInfo : ItemTrabajoTypeInfo
    {
        public ActividadInfo(TrabajoInfo trabajoInfo)
            : base(trabajoInfo)
        {            
        }
        
        public TypeInfo DialogoInfo
        {
            get;
            set;
        }
    }
}
