using System.Collections.Generic;
using Binapsis.Plataforma.Estructura;
using Binapsis.Plataforma.Estructura.Impl;
using System.Linq;

namespace Binapsis.Plataforma.Configuracion
{
    public class Tipo : ObjetoBase, ITipo
    {
        public Tipo(IImplementacion  impl)
            : base(impl)
        {
        }

        #region Metodos        
        protected override ObjetoBase CrearObjetoDatos(IImplementacion impl)
        {
            return FabricaConfiguracion.Instancia.Crear(impl);
        }

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
            get
            {
                return ObtenerString("Alias");
            }
            set
            {
                EstablecerString("Alias", value);
            }
        }

        public Tipo Base
        {
            get
            {
                return (Tipo)ObtenerObjetoDatos("Base");
            }
            set
            {
                EstablecerObjetoDatos("Base", value);
            }
        }

        public bool EsTipoDeDato
        {
            get
            {
                return ObtenerBoolean("EsTipoDeDato");
            }
            set
            {
                EstablecerBoolean("EsTipoDeDato", value);
            }
        }

        public string Nombre
        {
            get
            {
                return ObtenerString("Nombre");
            }
            set
            {
                EstablecerString("Nombre", value);
                EstablecerAlias(value);
            }
        }

        public IReadOnlyList<IPropiedad> Propiedades
        {
            get
            {
                //return (IReadOnlyList<IPropiedad>)ObtenerColeccion("Propiedades");
                return ObtenerColeccion("Propiedades").Cast<Propiedad>().ToList();
            }
        }

        public Uri Uri
        {
            get
            {
                return (Uri)ObtenerObjetoDatos("Uri");
            }
            set
            {
                EstablecerObjetoDatos("Uri", value);
            }
        }

        public IPropiedad this[string nombre]
        {
            get
            {
                return ObtenerPropiedad(nombre);
            }
        }

        public IPropiedad this[int indice]
        {
            get
            {
                return ObtenerPropiedad(indice);
            }
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
            get
            {
                return Base;
            }
        }

        string ITipo.Uri
        {
            get
            {
                return Uri?.Nombre??"";
            }
        }

        string ITipo.Alias
        {
            get
            {
                return Alias;
            }
        }

        bool ITipo.EsTipoDeDato
        {
            get
            {
                return EsTipoDeDato;
            }
        }

        string ITipo.Nombre
        {
            get
            {
                return Nombre;
            }
        }

        IReadOnlyList<IPropiedad> ITipo.Propiedades
        {
            get
            {
                return Propiedades;                
            }
        }

        IPropiedad ITipo.this[string nombre]
        {
            get
            {
                return this[nombre];
            }
        }

        IPropiedad ITipo.this[int indice]
        {
            get
            {
                return this[indice];
            }
        }        
        #endregion

    }
}
