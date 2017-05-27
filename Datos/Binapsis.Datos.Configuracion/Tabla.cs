using System;
using Binapsis.Plataforma.Estructura;
using Binapsis.Plataforma.Estructura.Impl;

namespace Binapsis.Datos.Configuracion
{
	public class Tabla : ObjetoBase
    {
        public Tabla()
            : this(FabricaImpl.Instancia)
        {
        }

        public Tabla(IFabricaImpl impl)
            : base(impl.Crear(Types.Instancia.Obtener(typeof(Tabla))))
        {
        }

        protected override ObjetoBase CrearObjetoDatos(IImplementacion impl)
        {
            return Fabrica.Instancia.Crear(impl);
        }

        public IColeccion Columnas
        {
            get => ObtenerColeccion("Columnas");
        }

        public string Nombre
        {
            get => ObtenerString("Nombre");
            set => EstablecerString("Nombre", value);
		}

    }
}