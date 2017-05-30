using System.Collections.Generic;
using Binapsis.Plataforma.Estructura;
using System.Linq;

namespace Binapsis.Plataforma.Configuracion
{
    public class Tipo : ConfiguracionBase, ITipo
    {
        public Tipo()
            : base(typeof(Tipo))
        {
        }

        public Tipo(IImplementacion impl) 
            : base(impl)
        {
        }

        //public Tipo(IFabricaImpl impl)
        //    : base(typeof(Tipo), impl)
        //{
        //}

        #region Metodos
        public bool ContienePropiedad(string nombre)
        {
            return (ObtenerColeccion("Propiedades").FirstOrDefault((item) => ((IPropiedad)item).Nombre == nombre) != null);
        }

        public Propiedad CrearPropiedad()
        {
            return (Propiedad)CrearObjetoDatos("Propiedades");
        }

        public Propiedad CrearPropiedad(string nombre)
        {
            Propiedad propiedad = CrearPropiedad();
            propiedad.Nombre = nombre;
            return propiedad;
        }

        public void RemoverPropiedad(string nombre)
        {
            if (!ContienePropiedad(nombre)) return;
            RemoverPropiedad(ObtenerPropiedad(nombre));
        }

        private void RemoverPropiedad(Propiedad propiedad)
        {
            RemoverObjetoDatos("Propiedades", propiedad);
        }

        public Propiedad CrearPropiedad(string nombre, Tipo tipo)
        {
            Propiedad propiedad = CrearPropiedad(nombre);
            propiedad.TipoAsociado = tipo;
            return propiedad;
        }

        public Propiedad CrearPropiedad(string nombre, Tipo tipo, string alias)
        {
            Propiedad propiedad = CrearPropiedad(nombre, tipo);
            propiedad.Alias = alias;
            return propiedad;
        }

        public Propiedad ObtenerPropiedad(int indice)
        {
            return (Propiedad)ObtenerColeccion("Propiedades")[indice];
        }

        public Propiedad ObtenerPropiedad(string nombre)
        {
            return (Propiedad)ObtenerColeccion("Propiedades").FirstOrDefault((item) => item.ObtenerString("Nombre") == nombre);
        }

        private void EstablecerAlias(string valor)
        {
            string alias = string.Empty;

            if (valor.Length == 1)
                alias = valor.Substring(0, 1).ToLower();
            else if (valor.Length > 1)
                alias = valor.Substring(0, 1).ToLower() + valor.Substring(1);

            if (string.IsNullOrEmpty(Alias) || (Alias.Length <= alias.Length && alias.Substring(0, Alias.Length) == Alias))
                Alias = alias;
                
        }
        #endregion


        #region Propiedades
        public string Alias
        {
            get => ObtenerString("Alias");
            set => EstablecerString("Alias", value);
        }

        public Tipo Base
        {
            get => (Tipo)ObtenerObjetoDatos("Base");
            set => EstablecerObjetoDatos("Base", value);
        }

        public bool EsTipoDeDato
        {
            get => ObtenerBoolean("EsTipoDeDato");
            set => EstablecerBoolean("EsTipoDeDato", value);
        }

        public string Nombre
        {
            get => ObtenerString("Nombre");
            set
            { 
                EstablecerString("Nombre", value);
                EstablecerAlias(value);
            }
        }

        public IReadOnlyList<IPropiedad> Propiedades
        {
            get => ObtenerColeccion("Propiedades").Cast<Propiedad>().ToList();            
        }

        public Uri Uri
        {
            get => (Uri)ObtenerObjetoDatos("Uri");
            set => EstablecerObjetoDatos("Uri", value);
        }

        public IPropiedad this[string nombre]
        {
            get => ObtenerPropiedad(nombre);
        }

        public IPropiedad this[int indice]
        {
            get => ObtenerPropiedad(indice);
        }
        #endregion


        #region ITipo
        IPropiedad ITipo.ObtenerPropiedad(string nombre)
        {
            return ObtenerPropiedad(nombre);
        }

        IPropiedad ITipo.ObtenerPropiedad(int indice)
        {
            return ObtenerPropiedad(indice);
        }

        bool ITipo.ContienePropiedad(string nombre)
        {
            return ContienePropiedad(nombre);
        }

        ITipo ITipo.Base
        {
            get => Base;
        }

        string ITipo.Uri
        {
            get => Uri?.Nombre??"";
        }

        string ITipo.Alias
        {
            get => Alias;
        }

        bool ITipo.EsTipoDeDato
        {
            get => EsTipoDeDato;
        }

        string ITipo.Nombre
        {
            get => Nombre;
        }

        IReadOnlyList<IPropiedad> ITipo.Propiedades
        {
            get => Propiedades;
        }

        IPropiedad ITipo.this[string nombre]
        {
            get => this[nombre];
        }

        IPropiedad ITipo.this[int indice]
        {
            get => this[indice];
        }        
        #endregion

    }
}
