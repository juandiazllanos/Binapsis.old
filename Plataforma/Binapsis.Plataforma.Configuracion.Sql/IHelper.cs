namespace Binapsis.Plataforma.Configuracion.Sql
{
    public interface IHelper
    {
        void Actualizar(string clave, ConfiguracionBase obj);
        bool Existe(ConfiguracionBase obj);
        bool Existe(string clave);
        void Eliminar(ConfiguracionBase obj);
        void Insertar(ConfiguracionBase obj);        
        ConfiguracionBase Recuperar(string clave);
    }
}
