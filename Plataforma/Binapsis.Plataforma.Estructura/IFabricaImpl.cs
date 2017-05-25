namespace Binapsis.Plataforma.Estructura
{
    public interface IFabricaImpl
    {
        IImplementacion Crear(ITipo tipo);
        IImplementacion Crear(ITipo tipo, IObjetoDatos propietario);
    }
}
