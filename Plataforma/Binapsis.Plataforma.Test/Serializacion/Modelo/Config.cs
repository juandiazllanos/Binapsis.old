using Binapsis.Plataforma.Estructura.Impl;
using Binapsis.Plataforma.Estructura;
using Binapsis.Plataforma.Configuracion;
using System;

namespace Binapsis.Plataforma.Test.Serializacion.Modelo
{
    public class Config : ObjetoBase
    {
        //static ITipo _tipo;

        public Config(IImplementacion impl) 
            : base(impl)
        {
        }
               
        
        protected override ObjetoBase CrearObjetoDatos(IImplementacion impl)
        {
            return FabricaConfiguracion.Instancia.Crear(impl);
        }

        public void AgregarTipo(Plataforma.Configuracion.Tipo tipo)
        {
            AgregarObjetoDatos("Tipos", tipo);
        }

        public IColeccion Tipos
        {
            get { return ObtenerColeccion("Tipos"); }
        }
    }
}
