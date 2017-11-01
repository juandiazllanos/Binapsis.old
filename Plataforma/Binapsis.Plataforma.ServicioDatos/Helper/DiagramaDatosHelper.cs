using System;
using Microsoft.AspNetCore.Http;

using Binapsis.Plataforma.Cambios.Impl;
using Binapsis.Plataforma.ServicioDatos.Impl;

namespace Binapsis.Plataforma.ServicioDatos.Helper
{
    class DiagramaDatosHelper : ControllerHelper<DiagramaDatos>
    {
        DiagramaDatos _dd;

        public DiagramaDatosHelper(ConfiguracionImpl configuracion, HttpContext httpContext, string uri, string tipo) 
            : base(configuracion, httpContext, uri, tipo)
        {
        }

        public void Ejecutar(string contexto)
        {
            OperacionHelper helper = new OperacionHelper(_configuracion, contexto);
            DiagramaDatos dd = Resolver();
            helper.Ejecutar(dd);
        }

        protected override DiagramaDatos Resolver()
        {
            if (_dd == null)
                return _dd = RequestBodyHelper.Instancia.ResolverDiagramaDatos(_httpContext, _tipo);
            else
                return _dd;
        }


        public override void Crear(string contexto)
        {
            throw new NotImplementedException();
        }

        public override void Editar(string contexto)
        {
            throw new NotImplementedException();
        }

        public override void Eliminar(string contexto)
        {
            throw new NotImplementedException();
        }

    }
}
