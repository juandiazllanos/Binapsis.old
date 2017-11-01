namespace Binapsis.Consola.Definicion
{
    public class Contenidos : ColeccionTypeInfo<ContenidoInfo>
    {        
        public Contenidos(ConsolaInfo consolaInfo)
            : base (consolaInfo)
        {
        }        

        protected override ContenidoInfo Instanciar(string nombre)
        {
            return new ContenidoInfo(ConsolaInfo) { Nombre = nombre };
        }
    }
}
