using Binapsis.Plataforma.Estructura.Impl;
using Binapsis.Plataforma.Estructura;
using System;

namespace Binapsis.Plataforma.Configuracion
{
    public class Propiedad : ObjetoBase, IPropiedad
    {
        public Propiedad(IImplementacion impl) 
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

        public Asociacion Asociacion
        {
            get
            {
                return (Asociacion)ObtenerByte("Asociacion");
            }
            set
            {
                EstablecerByte("Asociacion", (byte)value);
            }
        }

        public Cardinalidad Cardinalidad
        {
            get
            {
                return (Cardinalidad)ObtenerByte("Cardinalidad");
            }
            set
            {
                EstablecerByte("Cardinalidad", (byte)value);
            }
        }

        public bool EsColeccion
        {
            get
            {
                return Cardinalidad >= Cardinalidad.Muchos;
            }
        }

        public int Indice
        {
            get
            {
                return ObtenerInteger("Indice");
            }
            set
            {
                EstablecerInteger("Indice", value);
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

        public object ValorInicial
        {
            get
            {
                return ObtenerString("ValorInicial");
            }
            set
            {
                EstablecerString("ValorInicial", value.ToString());
            }
        }

        public Tipo TipoAsociado
        {
            get
            {
                return (Tipo)ObtenerObjetoDatos("Tipo");
            }
            set
            {
                EstablecerObjetoDatos("Tipo", value);
            }
        }

        ITipo IPropiedad.Tipo
        {
            get
            {
                return TipoAsociado;
            }
        }
        
    }
}
