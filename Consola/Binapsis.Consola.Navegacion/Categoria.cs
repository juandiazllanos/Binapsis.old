using System;

namespace Binapsis.Consola.Navegacion
{
    public class Categoria : Elemento
    {        
        public Elemento Contenido
        {
            get;
            set;
        }

        public Type Type
        {
            get;
            set;
        }
    }
}
