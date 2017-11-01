using System;
using System.Collections.Generic;
using System.Text;
using Binapsis.Plataforma.Datos;
using Binapsis.Plataforma.Cambios.Impl;
using Binapsis.Plataforma.Cambios;
using Binapsis.Plataforma.Cambios.Builder;
using Binapsis.Plataforma.Estructura;
using Binapsis.Plataforma.Configuracion.Helper;

namespace Binapsis.Plataforma.Configuracion.Datos
{
    public class Editar : Operacion
    {
        public Editar(IContexto contexto) 
            : this(new ContextoUpdate(contexto))
        {
        }

        private Editar(ContextoUpdate contexto)
            : base(contexto)
        {
            ContextoUpdate = contexto;
        }

        public override void Ejecutar(IObjetoDatos obj)
        {
            throw new NotImplementedException();
        }

        public void Ejecutar(IObjetoDatos obj, string clave)
        {
            IDiagramaDatos dd = new DiagramaDatos(obj.Tipo);
            BuilderDiagramaDatos builder = new BuilderDiagramaDatos(dd);            
            // obtener datos antiguos
            IObjetoDatos antiguo = RecuperarAntiguo(obj.Tipo, clave);
            // construir cambios
            builder.KeyHelper = new ConfiguracionKeyHelper();
            builder.Construir(obj, antiguo);
            // configurar contexto
            ContextoUpdate.Tabla = Configuracion.ObtenerTabla(obj.Tipo.Uri, obj.Tipo.Nombre);
            ContextoUpdate.Clave = clave;
            ContextoUpdate.Antiguo = antiguo;
            
            // ejecutar cambios
            Ejecutar(dd);
        }

        private IObjetoDatos RecuperarAntiguo(ITipo tipo, string clave)
        {
            Recuperar recuperar = new Recuperar(Contexto, tipo);
            recuperar.EstablecerParametro(0, clave);
            return recuperar.EjecutarConsultaSimple();
        }

        private ContextoUpdate ContextoUpdate
        {
            get;
        }
    }
}
