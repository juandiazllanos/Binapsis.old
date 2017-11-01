using Binapsis.Consola.Navegacion;

namespace Binapsis.Consola.Estructura
{
    public class Nodos : ColeccionMain<Categoria, Nodo>
    {
        public Nodos(Main main) 
            : base(main)
        {
        }
        
        protected override Nodo Instanciar(Categoria elemento)
        {
            return new Nodo(Main, elemento);
        }
    }
}
