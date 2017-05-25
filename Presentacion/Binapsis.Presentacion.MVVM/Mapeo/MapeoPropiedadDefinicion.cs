namespace Binapsis.Presentacion.MVVM.Mapeo
{
    public class MapeoPropiedadDefinicion
    {
        public MapeoPropiedadDefinicion(string nombre)
        {
            Nombre = nombre;
        }

        public MapeoPropiedadDefinicion(string nombre, bool usarReflexion)
            : this(nombre)
        {
            UsarReflexion = usarReflexion;
        }

        //public MapeoPropiedadDefinicion(string nombre, string property)
        //    : this(nombre)
        //{
        //    Property = property;
        //}

        public string Nombre
        {
            get;            
        }

        public bool UsarReflexion
        {
            get;
        }

        //public string Property
        //{
        //    get;
        //    set;
        //}
    }
}
