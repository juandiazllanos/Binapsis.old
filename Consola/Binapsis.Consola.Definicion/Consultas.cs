namespace Binapsis.Consola.Definicion
{
    public class Consultas : ColeccionBase<ConsultaInfo>
    {
        ConsolaInfo _consolaInfo;

        public Consultas(ConsolaInfo consolaInfo)            
        {
            _consolaInfo = consolaInfo;
        }

        protected override ConsultaInfo Instanciar(string nombre)
        {
            return new ConsultaInfo(_consolaInfo) { Nombre = nombre };
        }
    }
}
