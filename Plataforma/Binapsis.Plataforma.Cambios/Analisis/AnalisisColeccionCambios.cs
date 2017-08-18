using Binapsis.Plataforma.Estructura;
using Binapsis.Plataforma.Helper;
using System.Collections.Generic;
using System.Linq;

namespace Binapsis.Plataforma.Cambios.Analisis
{
    class AnalisisColeccionCambios : AnalisisPropiedadCambios
    {
        List<AnalisisObjetoCambios> _items;

        public AnalisisColeccionCambios(AnalisisObjetoCambios aoc, IPropiedad propiedad)
            : base(aoc, propiedad)
        {
            _items = new List<AnalisisObjetoCambios>();
        }

        public override void Resolver()
        {
            Cambio resul = Cambio.Ninguno;

            Construir();

            foreach (AnalisisObjetoCambios aoc in _items)
            {
                aoc.Resolver();

                if (resul == Cambio.Ninguno && aoc.Cambio != Cambio.Ninguno)
                    resul = Cambio.Modificado;
            }

            Cambio = resul;
        }

        private void Construir()
        {
            if (AnalisisObjetoCambios.ClaveHelper == null)
                ConstruirPorIndice();
            else
                ConstruirPorClave(AnalisisObjetoCambios.ClaveHelper);
        }

        private void ConstruirPorClave(IClaveHelper claveHelper)
        {
            IColeccion colNuevo = AnalisisObjetoCambios.ObjetoDatosNuevo.ObtenerColeccion(Propiedad);
            IColeccion colAntiguo = AnalisisObjetoCambios.ObjetoDatosAntiguo.ObtenerColeccion(Propiedad);

            IObjetoDatos itemNuevo;
            IObjetoDatos itemAntiguo;

            List<IObjetoDatos> itemsAntiguo = new List<IObjetoDatos>(colAntiguo);
            int indice = 0;
            
            foreach(IObjetoDatos item in colNuevo)
            {
                itemNuevo = item;
                itemAntiguo = itemsAntiguo.FirstOrDefault(antiguo => claveHelper.ObtenerString(itemNuevo) == claveHelper.ObtenerString(antiguo)); //EqualityHelper.Instancia.Igual(itemNuevo, antiguo, Clave));

                if (itemAntiguo != null) itemsAntiguo.Remove(itemAntiguo);

                CrearItem(itemNuevo, itemAntiguo, indice++);                
            }

            foreach (IObjetoDatos item in itemsAntiguo)
            {
                indice = colAntiguo.Indice(item);
                CrearItem(null, item, indice);
            }
        }

        private void ConstruirPorIndice()
        {
            IColeccion colNuevo = AnalisisObjetoCambios.ObjetoDatosNuevo.ObtenerColeccion(Propiedad);
            IColeccion colAntiguo = AnalisisObjetoCambios.ObjetoDatosAntiguo.ObtenerColeccion(Propiedad);

            int longitud = colNuevo.Longitud > colAntiguo.Longitud ? colNuevo.Longitud : colAntiguo.Longitud;

            IObjetoDatos itemNuevo;
            IObjetoDatos itemAntiguo;

            for (int i = 0; i < longitud; i++)
            {
                itemNuevo = colNuevo.Longitud > i ? colNuevo[i] : null;
                itemAntiguo = colAntiguo.Longitud > i ? colAntiguo[i] : null;

                CrearItem(itemNuevo, itemAntiguo, i);
                //_items.Add(new AnalisisItemCambios(Propiedad.Tipo, AnalisisObjetoCambios, i) { ObjetoDatosNuevo = itemNuevo, ObjetoDatosAntiguo = itemAntiguo });
            }

        }

        private void CrearItem(IObjetoDatos itemNuevo, IObjetoDatos itemAntiguo, int indice)
        {
            AnalisisItemCambios aic = new AnalisisItemCambios(Propiedad.Tipo, AnalisisObjetoCambios, indice);
            aic.ObjetoDatosNuevo = itemNuevo;
            aic.ObjetoDatosAntiguo = itemAntiguo;
            aic.Ruta = $"{AnalisisObjetoCambios.Ruta}/{Propiedad.Nombre}[{indice}]";
            _items.Add(aic);
        }

        //public IPropiedad Clave
        //{
        //    get;
        //}

        public IReadOnlyList<AnalisisObjetoCambios> Coleccion
        {
            get => _items;
        }
    }
}
