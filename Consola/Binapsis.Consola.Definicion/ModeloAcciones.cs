using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Binapsis.Consola.Definicion
{
    public class ModeloAcciones : IEnumerable<AccionModeloInfo>
    {
        List<AccionModeloInfo> _items = new List<AccionModeloInfo>();
        ConsolaInfo _consolaInfo;
        ModeloInfo _modeloInfo;

        internal ModeloAcciones(ConsolaInfo consolaInfo, ModeloInfo modeloInfo)
        {
            _consolaInfo = consolaInfo;
            _modeloInfo = modeloInfo;
        }

        public AccionModeloInfo Crear(string nombre)
        {
            return Crear(nombre, null, null);
        }

        public AccionModeloInfo Crear(string nombre, TrabajoInfo trabajoInfo)
        {
            return Crear(nombre, trabajoInfo, null);
        }

        public AccionModeloInfo Crear(string nombre, ControladorInfo controladorInfo)
        {
            return Crear(nombre, null, controladorInfo);
        }

        public AccionModeloInfo Crear(string nombre, TrabajoInfo trabajoInfo, ControladorInfo controladorInfo)
        {
            AccionModeloInfo accionModeloInfo = Obtener(nombre);
            AccionInfo accionInfo;

            if (accionModeloInfo == null && (accionInfo = _consolaInfo.Acciones[nombre]) != null)
                _items.Add(accionModeloInfo = new AccionModeloInfo
                {
                    AccionInfo = accionInfo,
                    ModeloInfo = _modeloInfo,
                    ControladorInfo = controladorInfo,
                    TrabajoInfo = trabajoInfo
                });

            return accionModeloInfo;
        }

        public AccionModeloInfo Obtener(string nombre)
        {
            return _items.FirstOrDefault(item => item.AccionInfo.Nombre == nombre);
        }

        public AccionModeloInfo this[string nombre]
        {
            get => Obtener(nombre);
        }

        IEnumerator<AccionModeloInfo> IEnumerable<AccionModeloInfo>.GetEnumerator()
        {
            return _items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _items.GetEnumerator();
        }
    }
}
