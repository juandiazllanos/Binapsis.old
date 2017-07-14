using System;
using System.Collections.Generic;
using System.Text;

namespace Binapsis.Plataforma.Datos
{
    public interface IComando
    {
        //IContexto Contexto { get; set; }
        void Ejecutar();
    }
}
