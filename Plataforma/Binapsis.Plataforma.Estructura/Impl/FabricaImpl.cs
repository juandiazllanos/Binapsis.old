namespace Binapsis.Plataforma.Estructura.Impl
{
    internal class FabricaImpl : IFabricaImpl
    {
        static FabricaImpl()
        {
            Instancia = new FabricaImpl();
        }

        public static IFabricaImpl Instancia { get; }

        public IImplementacion Crear(ITipo tipo)
        {
            return new Implementacion(tipo);
        }

        public IImplementacion Crear(ITipo tipo, IObjetoDatos propietario)
        {
            return new Implementacion(tipo, propietario);
        }
    }
}
