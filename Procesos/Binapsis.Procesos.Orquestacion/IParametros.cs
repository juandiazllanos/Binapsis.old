namespace Binapsis.Procesos.Orquestacion
{
    public interface IParametros
    {
        void Establecer(string nombre, object valor);
        object Obtener(string nombre);
    }
}
