using Binapsis.Plataforma.Estructura.Impl;
using Binapsis.Plataforma.Estructura;
using System;

namespace Binapsis.Plataforma
{
    public class EntidadBase : ObjetoBase
    {
        public EntidadBase(IImplementacion impl) 
            : base(impl)
        {
        }

        protected override ObjetoBase CrearObjetoDatos(IImplementacion impl)
        {
            throw new NotImplementedException();
        }
    }
}
