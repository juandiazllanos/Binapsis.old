namespace Binapsis.Plataforma.Configuracion.Sql.Clave
{
    class ClaveConexion : ClaveBase
    {
        public ClaveConexion(ConfiguracionBase obj) 
            : base(obj)
        {
        }

        public override string CrearClave(ConfiguracionBase obj)
        {
            return (obj as Conexion)?.Nombre;
        }
    }
}
