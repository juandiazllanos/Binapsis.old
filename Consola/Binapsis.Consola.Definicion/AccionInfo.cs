using System.Collections.Generic;
using System.Linq;

namespace Binapsis.Consola.Definicion
{
    public class AccionInfo : ItemConsolaBase
    {
        List<AccionModeloInfo> _items = new List<AccionModeloInfo>();

        internal AccionInfo(ConsolaInfo consolaInfo) 
            : base(consolaInfo)
        {
        }

        #region Metodos
        public void Agregar(ModeloInfo modeloInfo)
        {
            AccionModeloInfo accionModeloInfo = new AccionModeloInfo { AccionInfo = this, ModeloInfo = modeloInfo };
            Agregar(accionModeloInfo);
        }

        public void Agregar(AccionModeloInfo accionModeloInfo)
        {
            if (!Existe(accionModeloInfo.ModeloInfo))
                _items.Add(accionModeloInfo);
        }

        public bool Existe(ModeloInfo modeloInfo)
        {
            return _items.Exists(item => item.ModeloInfo == modeloInfo);
        }

        public AccionModeloInfo Obtener(ModeloInfo modeloInfo)
        {
            return _items.FirstOrDefault(item => item.ModeloInfo == modeloInfo);
        }
        #endregion


        #region Propiedades
        public ControladorInfo ControladorInfo
        {
            get;
            set;
        }

        public IEnumerable<AccionModeloInfo> Modelos
        {
            get => _items;
        }
        
        public TrabajoInfo TrabajoInfo
        {
            get;
            set;
        }
        #endregion
    }
}
