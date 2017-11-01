using Binapsis.Consola.Navegacion;

namespace Binapsis.Consola.Estructura
{
    public class Botones : ColeccionMain<Elemento, Boton>
    {
        public Botones(Main main) 
            : base(main)
        {
        }

        protected override Boton Instanciar(Elemento elemento)
        {
            return new Boton(Main, elemento) { AccionInfo = Main.ConsolaInfo.Acciones[elemento.Nombre] };
        }
    }
}
