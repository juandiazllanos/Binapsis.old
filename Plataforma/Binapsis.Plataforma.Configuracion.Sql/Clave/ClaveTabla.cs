namespace Binapsis.Plataforma.Configuracion.Sql.Clave
{
    class ClaveTabla : ClaveBase
    {
        public ClaveTabla(ConfiguracionBase obj) 
            : base(obj)
        {
        }

        public override string CrearClave(ConfiguracionBase obj)
        {
            return (obj as Tabla)?.Nombre;
        }
    }
}
