namespace Binapsis.Plataforma.Configuracion.Presentacion.Navegacion
{
    public class ResolverNodo
    {
        public ResolverNodo(Navegador navegador, Nodo nodo)
        {
            Navegador = navegador;
            Nodo = nodo;
        }
        
        public void Resolver()
        {
            Navegador.ResolverNodo(Nodo);
            Resuelto = true;
        }

        public bool Resuelto
        {
            get;
            private set;
        }
        
        private Navegador Navegador
        {
            get;
        }

        public Nodo Nodo
        {
            get;
            set;
        }
        

    }
}
