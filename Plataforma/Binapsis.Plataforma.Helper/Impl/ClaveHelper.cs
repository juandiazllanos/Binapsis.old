using System.Collections.Generic;
using Binapsis.Plataforma.Estructura;

namespace Binapsis.Plataforma.Helper.Impl
{
    public class ClaveHelper : IClaveHelper
    {
        Dictionary<string, List<string>> _claves;

        #region Constructores
        protected ClaveHelper()
        {
            _claves = new Dictionary<string, List<string>>();
        }        
        #endregion


        #region Metodos
        public IEnumerable<IClave> Obtener(IObjetoDatos od)
        {   
            List<string> propiedades = null;
            string claveTipo = $"{od.Tipo.Uri}.{od.Tipo.Nombre}";

            // obtener propiedades clave
            if (od != null && _claves.ContainsKey(claveTipo))
                propiedades = _claves[claveTipo];

            if (propiedades == null) return System.Linq.Enumerable.Empty<IClave>();

            // construir claves
            List<Clave> claves = new List<Clave>();
            
            foreach (string propiedad in propiedades)
                claves.Add(new Clave(od, od.Tipo.ObtenerPropiedad(propiedad)) { ClaveHelper = this });

            return claves;
        }
        
        public string ObtenerString(IObjetoDatos od)
        {
            return string.Join(", ", Obtener(od));
        }

        protected internal virtual void Establecer(ITipo tipo, string propiedad)
        {
            Establecer(tipo, tipo?.ObtenerPropiedad(propiedad));
        }

        protected internal virtual void Establecer(ITipo tipo, IPropiedad propiedad)
        {
            if (tipo == null || propiedad == null) return;

            List<string> claveItem;
            string claveTipo = $"{tipo.Uri}.{tipo.Nombre}";

            if (_claves.ContainsKey(claveTipo))
                claveItem = _claves[claveTipo];
            else
                _claves.Add(claveTipo, claveItem = new List<string>());

            if (!claveItem.Contains(propiedad.Nombre))
                claveItem.Add(propiedad.Nombre);
        }
        #endregion


        #region Propiedades
        //public static ClaveHelper Instancia
        //{
        //    get;
        //}
        #endregion

    }
}
