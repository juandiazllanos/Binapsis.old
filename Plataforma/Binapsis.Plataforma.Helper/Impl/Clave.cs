using Binapsis.Plataforma.Estructura;

namespace Binapsis.Plataforma.Helper.Impl
{
    class Clave : IClave
    {
        #region Constructores
        public Clave(IObjetoDatos od, IPropiedad propiedad)
        {
            ObjetoDatos = od;
            Propiedad = propiedad;
        }
        #endregion


        #region Metodos        
        public override bool Equals(object obj)
        {
            return Equals(obj as IClave);
        }

        public bool Equals(IClave other)
        {
            if (other != null && 
                ObjetoDatos?.Tipo != null && 
                ObjetoDatos?.Tipo.Nombre == other.ObjetoDatos?.Tipo.Nombre && 
                Propiedad != null && 
                Propiedad.Nombre == other.Propiedad.Nombre)
                return EqualityHelper.Instancia.Igual(ObjetoDatos, other.ObjetoDatos, Propiedad);
            else
                return false;
        }

        public override string ToString()
        {
            if (Propiedad == null) return null;

            if (Propiedad.Tipo.EsTipoDeDato)
                return ObjetoDatos?.Obtener(Propiedad).ToString();
            else
                return ClaveHelper.ObtenerString(ObjetoDatos?.ObtenerObjetoDatos(Propiedad));

        }
        #endregion


        #region Propiedades
        public IObjetoDatos ObjetoDatos
        {
            get;
        }

        public IPropiedad Propiedad
        {
            get;
        }

        internal ClaveHelper ClaveHelper
        {
            get;
            set;
        }
        #endregion
    }
}
