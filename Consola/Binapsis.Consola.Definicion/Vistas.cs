namespace Binapsis.Consola.Definicion
{
    public class Vistas : ColeccionTypeInfo<VistaInfo>
    {
        public Vistas(ConsolaInfo consolaInfo) 
            : base(consolaInfo)
        {
        }

        protected override VistaInfo Instanciar(string nombre)
        {
            return new VistaInfo(ConsolaInfo) { Nombre = nombre };
        }
    }
}
