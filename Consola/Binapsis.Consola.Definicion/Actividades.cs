namespace Binapsis.Consola.Definicion
{
    public class Actividades : ColeccionTypeInfo<ActividadInfo>
    {
        public Actividades(TrabajoInfo trabajoInfo) 
            : base(trabajoInfo.ConsolaInfo)
        {
            TrabajoInfo = trabajoInfo;
        }

        protected override ActividadInfo Instanciar(string nombre)
        {
            return new ActividadInfo(TrabajoInfo) { Nombre = nombre };
        }

        protected TrabajoInfo TrabajoInfo
        {
            get;
        }
    }
}
