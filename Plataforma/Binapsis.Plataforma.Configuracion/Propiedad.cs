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

        protected override ObjetoBase CrearObjetoDatos(IImplementacion impl)
        {
            return FabricaConfiguracion.Instancia.Crear(impl);
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
                EstablecerAlias(value);
            }
        }

        public new Tipo Propietario
        {
            get
            {
                return (Tipo)base.Propietario;
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
