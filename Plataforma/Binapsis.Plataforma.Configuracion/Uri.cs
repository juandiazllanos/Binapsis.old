using Binapsis.Plataforma.Estructura.Impl;
using Binapsis.Plataforma.Estructura;
using System;

namespace Binapsis.Plataforma.Configuracion
{
    public class Uri : ObjetoBase
    {
        public Uri(IImplementacion impl) 
            : base(impl)
        {
        }

        protected override ObjetoBase CrearObjetoDatos(IImplementacion impl)
        {
            return FabricaConfiguracion.Instancia.Crear(impl);
        }

        public Ensamblado Ensamblado
        {
            get
            {
                return (Ensamblado)ObtenerObjetoDatos("Ensamblado");
            }
            set
            {
                EstablecerObjetoDatos("Ensamblado", value);
            }
        }

        public string Nombre
        {
            get
            {
                return ObtenerString("Nombre");
            }
            set
            {
                EstablecerString("Nombre", value);
            }
        }
    }
}
