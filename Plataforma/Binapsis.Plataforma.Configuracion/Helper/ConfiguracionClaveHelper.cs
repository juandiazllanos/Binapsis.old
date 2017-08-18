using Binapsis.Plataforma.Estructura;
using Binapsis.Plataforma.Helper;
using Binapsis.Plataforma.Helper.Impl;

namespace Binapsis.Plataforma.Configuracion.Helper
{
    public class ConfiguracionClaveHelper : ClaveHelper
    {
        #region Constructores
        private ConfiguracionClaveHelper()
            : base()
        {
        }

        static ConfiguracionClaveHelper()
        {
            Instancia = new ConfiguracionClaveHelper();
        }
        #endregion


        #region Metodos
        internal new void Establecer(ITipo tipo, string propiedad)
        {
            base.Establecer(tipo, propiedad);
        }

        internal new void Establecer(ITipo tipo, IPropiedad propiedad)
        {
            base.Establecer(tipo, propiedad);
        }
        #endregion


        #region Propiedades
        public static ConfiguracionClaveHelper Instancia
        {
            get;
        }
        #endregion

    }
}
