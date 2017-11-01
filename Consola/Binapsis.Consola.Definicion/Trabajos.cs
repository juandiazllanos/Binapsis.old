namespace Binapsis.Consola.Definicion
{
    public class Trabajos : ColeccionTypeInfo<TrabajoInfo>
    {
        public Trabajos(ConsolaInfo consolaInfo) 
            : base(consolaInfo)
        {
        }

        protected override TrabajoInfo Instanciar(string nombre)
        {
            return new TrabajoInfo(ConsolaInfo) { Nombre = nombre };
        }
    }
}
