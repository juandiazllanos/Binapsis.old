using System;

namespace Binapsis.Plataforma.Estructura.Impl
{
	public class Fabrica : IFabrica
    {
        static Fabrica()
        {
            Instancia = new Fabrica();
        }

        public static IFabrica Instancia { get; } 

        public IObjetoDatos Crear(ITipo tipo)
        {
            return Crear(FabricaImplementacion.Instancia.Crear(tipo));
        }

        public IObjetoDatos Crear(ITipo tipo, IObjetoDatos propietario)
        {
            return Crear(FabricaImplementacion.Instancia.Crear(tipo, propietario));
        }

        public IObjetoDatos Crear(IImplementacion impl)
        {
            return new ObjetoDatos(impl);
        }
                
    }
}