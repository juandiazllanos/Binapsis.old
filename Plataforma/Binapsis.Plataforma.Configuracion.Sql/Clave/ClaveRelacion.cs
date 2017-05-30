namespace Binapsis.Plataforma.Configuracion.Sql.Clave
{
    class ClaveRelacion : ClaveBase
    {
        public ClaveRelacion(ConfiguracionBase obj) 
            : base(obj)
        {
        }

        public override string CrearClave(ConfiguracionBase obj)
        {
            return (obj as Relacion)?.Nombre;
        }
    }
}
