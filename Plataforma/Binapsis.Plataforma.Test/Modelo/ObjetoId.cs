using Binapsis.Plataforma.Estructura.Impl;
using Binapsis.Plataforma.Estructura;
using System;

namespace Binapsis.Plataforma.Test.Modelo
{
    public class ObjetoId : ObjetoBase
    {
        protected ObjetoId(IImplementacion impl) 
            : base(impl)
        {
        }

        protected override ObjetoBase CrearObjetoDatos(IImplementacion impl)
        {
            throw new NotImplementedException();
        }

        public int Id
        {
            get => ObtenerInteger("Id");
        }
    }
}
