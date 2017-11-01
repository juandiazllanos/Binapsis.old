namespace Binapsis.Consola.Definicion
{
    public class Acciones : ColeccionBase<AccionInfo>
    {
        ConsolaInfo _consolaInfo;

        #region Constructores
        public Acciones(ConsolaInfo consolaInfo)
        {
            _consolaInfo = consolaInfo;
        }
        #endregion


        #region Metodos
        public AccionInfo Crear(string nombre, ControladorInfo controladorInfo)
        {
            AccionInfo accionInfo = Crear(nombre);
            accionInfo.ControladorInfo = controladorInfo;
            return accionInfo;
        }

        protected override AccionInfo Instanciar(string nombre)
        {
            return new AccionInfo(_consolaInfo) { Nombre = nombre };
        }
        #endregion
        
    }
}
