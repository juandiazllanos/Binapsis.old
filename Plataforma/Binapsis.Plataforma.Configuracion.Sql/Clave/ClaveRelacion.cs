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
            Relacion rel = obj as Relacion;
            if (obj == null) return null;

            return $"{rel.Nombre}";
        }
    }
}
