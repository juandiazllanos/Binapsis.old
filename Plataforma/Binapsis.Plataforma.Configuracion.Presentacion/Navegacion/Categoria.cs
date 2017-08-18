namespace Binapsis.Plataforma.Configuracion.Presentacion.Navegacion
{
    public class Categoria : Grupo
    {
        public string Descripcion
        {
            get;
            set;
        }

        public override string Nombre
        {
            get => base.Nombre;
            set
            {
                base.Nombre = value;
                Descripcion = value;
            }
        }
    }
}
