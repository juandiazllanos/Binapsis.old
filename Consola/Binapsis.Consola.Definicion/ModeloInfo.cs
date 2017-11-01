namespace Binapsis.Consola.Definicion
{
    public class ModeloInfo : ItemConsolaTypeInfo
    {
        #region Constructores
        public ModeloInfo(ConsolaInfo consolaInfo)
            : base(consolaInfo)
        {
            Acciones = new ModeloAcciones(consolaInfo, this);
        }
        #endregion
        

        #region Propiedades
        public ModeloAcciones Acciones
        {
            get;
        }
        #endregion
    }
}
