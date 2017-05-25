using Binapsis.Plataforma.Estructura.Impl;

namespace Binapsis.Plataforma.Configuracion.Sql
{
    public interface IHelper
    {
        void Actualizar(string clave, ObjetoBase obj);
        bool Existe(ObjetoBase obj);
        bool Existe(string clave);
        void Eliminar(ObjetoBase obj);
        void Insertar(ObjetoBase obj);        
        ObjetoBase Recuperar(string clave);
    }
}
