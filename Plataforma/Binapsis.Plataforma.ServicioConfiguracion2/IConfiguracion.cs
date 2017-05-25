using System.ServiceModel;

namespace Binapsis.Plataforma.ServicioConfiguracion
{
    [ServiceContract]
    public interface IConfiguracion
    {
        [OperationContract]
        string Obtener(string ruta);

        [OperationContract]
        void Establecer(string ruta, string valor);
    }
}