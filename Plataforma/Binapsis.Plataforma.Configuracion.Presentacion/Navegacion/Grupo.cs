namespace Binapsis.Plataforma.Configuracion.Presentacion.Navegacion
{
    public class Grupo : Elemento
    {
        public Grupo()
        {
            Grupos = new Grupos(this);
        }

        public Grupos Grupos
        {
            get;
        }
    }
}
