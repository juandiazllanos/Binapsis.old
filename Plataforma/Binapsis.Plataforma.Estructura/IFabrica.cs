namespace Binapsis.Plataforma.Estructura
{
    public interface IFabrica  
    {        
		IObjetoDatos Crear(ITipo tipo);
        IObjetoDatos Crear(ITipo tipo, IObjetoDatos propietario);
    }
}