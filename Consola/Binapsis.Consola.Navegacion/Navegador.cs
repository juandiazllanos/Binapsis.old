using Binapsis.Consola.Navegacion;

namespace Binapsis.Consola
{
    public class Navegador : Elemento 
    {
        public Navegador()
        {
            Comandos = new Elementos(this);
            Categorias = new Elementos(this);            

            Nombre = "Navegador";
        }

        public Elementos Comandos
        {
            get;
        }

        public Elementos Categorias
        {
            get;
        }        
    }
}
