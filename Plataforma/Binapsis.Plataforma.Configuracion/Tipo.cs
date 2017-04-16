using System.Collections.Generic;
using Binapsis.Plataforma.Estructura;
using Binapsis.Plataforma.Estructura.Impl;
using System.Linq;
using System;

namespace Binapsis.Plataforma.Configuracion
{
    public class Tipo : ObjetoBase, ITipo
    {
        public Tipo(IImplementacion  impl)
            : base(impl)
        {

        }
        
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
            }
        }

        public IReadOnlyList<IPropiedad> Propiedades
        {
            get
            {
                return (IReadOnlyList<IPropiedad>)ObtenerColeccion("Propiedades");
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

        public bool ContienePropiedad(string nombre)
        {
            return (ObtenerColeccion("Propiedades").FirstOrDefault((item) => ((IPropiedad)item).Nombre == nombre) != null);
        }

        public IPropiedad CrearPropiedad()
        {
            return (IPropiedad)CrearObjetoDatos("Propiedades");
        }

        public IPropiedad ObtenerPropiedad(int indice)
        {
            return (IPropiedad)ObtenerColeccion("Propiedades")[indice];
        }

        public IPropiedad ObtenerPropiedad(string nombre)
        {
            return (IPropiedad)ObtenerColeccion("Propiedades").FirstOrDefault((item) => item.ObtenerString("Nombre") == nombre);
        }

    }
}
