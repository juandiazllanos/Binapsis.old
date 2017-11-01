namespace Binapsis.Consola.Definicion
{
    public class TrabajoInfo : ItemConsolaTypeInfo
    {        
        #region Constructores
        public TrabajoInfo(ConsolaInfo consolaInfo)
            : base(consolaInfo)
        {
            Actividades = new Actividades(this);
            Asociaciones = new Asociaciones(this);
            Resultados = new Resultados(this);            
        }
        #endregion


        #region Metodos
        
        #endregion


        #region Propiedades
        public Actividades Actividades
        {
            get;
        }

        public string ActividadInicio
        {
            get;
            set;
        }

        public Asociaciones Asociaciones
        {
            get;
        }
        
        public Resultados Resultados
        {
            get;
        }
        #endregion
    }
}
