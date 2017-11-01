using System;
using System.Collections.Generic;
using System.Text;

namespace Binapsis.Consola.Navegacion
{
    public class Grupo : Elemento
    {
        public Grupo()
        {
            Elementos = new Elementos(this);
        }

        public Elementos Elementos
        {
            get;
        }
    }
}
