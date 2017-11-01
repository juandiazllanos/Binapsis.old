namespace Binapsis.Consola.Definicion
{
    public class Columnas : ColeccionBase<ColumnaInfo>
    {
        ContenidoInfo _contenidoInfo;

        public Columnas(ContenidoInfo contenidoInfo)
        {
            _contenidoInfo = contenidoInfo;
        }

        protected override ColumnaInfo Instanciar(string nombre)
        {
            return new ColumnaInfo(_contenidoInfo) { Nombre = nombre };
        }
    }
}
