using System;

namespace Binapsis.Plataforma.Estructura.Impl
{
    public  class FabricaImplementacion : IFabrica
    {
        IFabrica _fabrica;

        protected FabricaImplementacion()
        {
            _fabrica = new Fabrica();
        }

        public FabricaImplementacion(IFabrica fabrica)
        {
            _fabrica = fabrica;
        }

        static FabricaImplementacion()
        {
            Instancia = new FabricaImplementacion();
        }

        
        public static FabricaImplementacion Instancia { get; protected set; } 


        public IImplementacion Crear(ITipo tipo)
        {
            return new Implementacion(tipo);
        } 

        public IImplementacion Crear(ITipo tipo, IObjetoDatos propietario)
        {
            return new Implementacion(tipo, propietario);
        }

        protected virtual IImplementacion CrearImplementacion(IImplementacion impl)
        {
            return impl;
        }
        
        protected virtual IObjetoDatos CrearObjetoDatos(IImplementacion impl)
        {
            impl = CrearImplementacion(impl);
            return _fabrica.Crear(impl);
        }
        
        IObjetoDatos IFabrica.Crear(ITipo tipo)
        {
            IImplementacion impl = Crear(tipo);
            return CrearObjetoDatos(impl);
        }

        IObjetoDatos IFabrica.Crear(ITipo tipo, IObjetoDatos propietario)
        {
            IImplementacion impl = Crear(tipo, propietario);
            return CrearObjetoDatos(impl);
        }
                
        IObjetoDatos IFabrica.Crear(IImplementacion impl)
        {
            return CrearObjetoDatos(impl);
        }

    }
}
