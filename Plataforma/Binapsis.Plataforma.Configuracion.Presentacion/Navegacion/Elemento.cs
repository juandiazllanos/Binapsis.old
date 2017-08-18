namespace Binapsis.Plataforma.Configuracion.Presentacion.Navegacion
{
    public class Elemento
    {   
        public virtual string Nombre
        {
            get;
            set;
        }

        public Elemento Padre
        {
            get;
            internal set;
        }                
    }
}
