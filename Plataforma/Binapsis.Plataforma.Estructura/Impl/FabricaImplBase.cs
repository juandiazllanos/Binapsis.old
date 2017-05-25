namespace Binapsis.Plataforma.Estructura.Impl
{
    public abstract class FabricaImplBase : IFabricaImpl
    {
        IFabricaImpl _fabrica;

        public FabricaImplBase()
            : this(FabricaImpl.Instancia)
        {
        }

        public FabricaImplBase(IFabricaImpl fabrica)
        {
            _fabrica = fabrica;
        }

        public IImplementacion Crear(ITipo tipo)
        {
            return Crear(_fabrica.Crear(tipo));
        }

        public IImplementacion Crear(ITipo tipo, IObjetoDatos propietario)
        {
            return Crear(_fabrica.Crear(tipo, propietario));
        }

        protected abstract IImplementacion Crear(IImplementacion impl);
    }
}
