using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

using Binapsis.Plataforma.Cambios.Impl;
using Binapsis.Plataforma.ServicioDatos.Impl;

namespace Binapsis.Plataforma.ServicioDatos.Helper
{
    class DiagramaDatosColeccionHelper : ControllerHelper<IList<DiagramaDatos>>
    {
        IList<DiagramaDatos> _items;

        public DiagramaDatosColeccionHelper(ConfiguracionImpl configuracion, HttpContext httpContext, string uri, string tipo) 
            : base(configuracion, httpContext, uri, tipo)
        {
        }

        public void Ejecutar(string contexto)
        {
            OperacionHelper helper = new OperacionHelper(_configuracion, contexto);
            IList<DiagramaDatos> items = Resolver();
            helper.Ejecutar(items);
        }

        protected override IList<DiagramaDatos> Resolver()
        {
            if (_items == null)
                return _items = RequestBodyHelper.Instancia.ResolverDiagramaDatosColeccion(_httpContext, _tipo);
            else
                return _items;
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
