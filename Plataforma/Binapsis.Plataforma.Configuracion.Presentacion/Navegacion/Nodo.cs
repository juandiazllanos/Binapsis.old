namespace Binapsis.Plataforma.Configuracion.Presentacion.Navegacion
{
    public class Nodo : Elemento
    {
        internal Nodo()
        {
            Nodos = new Nodos(this);
        }

        internal Nodo(Elemento elemento)
            : this()
        {            
            Elemento = elemento;
        }

        public Elemento Elemento
        {
            get;        
        }

        public Nodos Nodos
        {
            get;
        }
    }
}
