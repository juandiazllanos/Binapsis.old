using Binapsis.Consola.Navegacion;

namespace Binapsis.Consola.Estructura
{
    public class Tabs : ColeccionMain<Categoria, Tab>
    {
        public Tabs(Main main) 
            : base(main)
        {
        }
        
        protected override Tab Instanciar(Categoria elemento)
        {
            return new Tab(Main, elemento);
        }
    }
}
