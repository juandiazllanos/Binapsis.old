using Binapsis.Plataforma.Estructura;

namespace Binapsis.Plataforma.Configuracion
{
    public class Propiedad : ConfiguracionBase, IPropiedad
    {
        public Propiedad(IImplementacion impl) 
            : base(impl)
        {
        }

        #region Metodos
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

        public Asociacion Asociacion
        {
            get => (Asociacion)ObtenerByte("Asociacion");
            set => EstablecerByte("Asociacion", (byte)value);
        }

        public Cardinalidad Cardinalidad
        {
            get => (Cardinalidad)ObtenerByte("Cardinalidad");
            set => EstablecerByte("Cardinalidad", (byte)value);
        }

        public bool EsColeccion
        {
            get => Cardinalidad >= Cardinalidad.CeroAMuchos;
        }

        public int Indice
        {
            get => ObtenerInteger("Indice");
            set => EstablecerInteger("Indice", value);
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

        public new Tipo Propietario
        {
            get => (Tipo)base.Propietario;
        }

        public object ValorInicial
        {
            get => ObtenerString("ValorInicial");
            set => EstablecerString("ValorInicial", value?.ToString());
        }

        public Tipo TipoAsociado
        {
            get => (Tipo)ObtenerObjetoDatos("Tipo");
            set => EstablecerObjetoDatos("Tipo", value);
        }

        ITipo IPropiedad.Tipo
        {
            get => TipoAsociado;
        }
        #endregion  
    }
}
