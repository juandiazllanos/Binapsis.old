namespace Binapsis.Plataforma.Estructura.Impl
{
    public abstract class FabricaBase<T> : IFabrica where T : IObjetoDatos 
    {
        IFabricaImpl _fabrica;

        public FabricaBase()
            : this(FabricaImpl.Instancia)
        {            
        }

        public FabricaBase(IFabricaImpl fabrica)
        {
            _fabrica = fabrica;
        }

        public abstract T Crear(IImplementacion impl);
        
        public virtual T Crear(ITipo tipo)
        {
            return Crear(_fabrica.Crear(tipo));
        }

        public virtual T Crear(ITipo tipo, T propietario)
        {
            return Crear(_fabrica.Crear(tipo, propietario));
        }

        #region IFabrica
        IObjetoDatos IFabrica.Crear(ITipo tipo)
        {
            return Crear(tipo);
        }

        IObjetoDatos IFabrica.Crear(ITipo tipo, IObjetoDatos propietario)
        {
            return Crear(tipo, (T)propietario);
        }
        #endregion

    }
}
