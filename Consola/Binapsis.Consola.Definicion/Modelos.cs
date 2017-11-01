namespace Binapsis.Consola.Definicion
{
    public class Modelos : ColeccionTypeInfo<ModeloInfo>
    {
        public Modelos(ConsolaInfo consolaInfo)
            : base(consolaInfo)
        {            
        }

        #region Metodos        
        protected override ModeloInfo Instanciar(string nombre)
        {
            return new ModeloInfo(ConsolaInfo) { Nombre = nombre };
        }        
        #endregion

    }
}
