using Binapsis.Presentacion.Editores;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Binapsis.Presentacion.MVVM.Mapeo
{
    public class MapeoTipo
    {
        List<MapeoPropiedad> _propiedades;
        List<MapeoComando> _comandos;

        public MapeoTipo()
            : this(true)
        {            
        }

        public MapeoTipo(bool usarReflexion)            
        {            
            _propiedades = new List<MapeoPropiedad>();
            _comandos = new List<MapeoComando>();

            UsarReflexion = usarReflexion;
        }

        public void Establecer(string nombre, IEditor editor)
        {
            Establecer(nombre, editor, null);
        }

        public void Establecer(string nombre, MapeoTipo mapeo)
        {
            Establecer(nombre, null, mapeo);
        }

        public void Establecer(string nombre, IEditor editor, MapeoTipo mapeo)
        {
            Establecer(new MapeoPropiedadDefinicion(nombre, UsarReflexion), editor, mapeo);
        }
        
        public void Establecer(MapeoPropiedadDefinicion propiedad, IEditor editor)
        {
            Establecer(propiedad, editor, null);
        }

        public void Establecer(MapeoPropiedadDefinicion propiedad, MapeoTipo mapeo)
        {
            Establecer(propiedad, null, mapeo);
        }

        public void Establecer(MapeoPropiedadDefinicion propiedad, IEditor editor, MapeoTipo mapeo)
        {
            if (editor == null && mapeo == null) return;

            MapeoPropiedad mapeoPropiedad = null;

            // resolver mapeo anidado
            var resultado = ResolverMapeo(propiedad);
            if (resultado.Item3)
            {
                resultado.Item1.Establecer(resultado.Item2, editor, mapeo);
                return;
            }   

            // crear mapeo
            if (mapeo != null)
                mapeoPropiedad = new MapeoReferencia(this) { Mapeo = mapeo };
            else
                mapeoPropiedad = new MapeoPropiedad(this);

            if (mapeoPropiedad == null) return;

            mapeoPropiedad.Propiedad = propiedad;
            mapeoPropiedad.Editor = editor;

            _propiedades.Add(mapeoPropiedad);
        }


        public void EstablecerComando(IEditorComando invocador, IComando comando)
        {
            EstablecerComando(invocador.Nombre, invocador, comando);
        }

        public void EstablecerComando(string nombre, IEditorComando invocador, IComando comando)
        {
            if (invocador == null || comando == null || string.IsNullOrEmpty(nombre)) return;
            _comandos.Add(new MapeoComando(this, nombre, invocador, comando));
        }

        private bool Existe(string nombre)
        {
            return _propiedades.Exists(item => item.Propiedad.Nombre == nombre);
        }

        private MapeoPropiedad Obtener(string nombre)
        {
            return _propiedades.FirstOrDefault(item => item.Propiedad.Nombre == nombre);
        }

        public Tuple<MapeoTipo, MapeoPropiedadDefinicion, bool> ResolverMapeo(MapeoPropiedadDefinicion propiedad)
        {
            MapeoTipo mapeo = this;
            MapeoPropiedad mapeoItem = null;
            MapeoReferencia mapeoReferencia = null;

            string nombre = propiedad.Nombre;
            string[] pasos = nombre.Split(new char[] { '.', '/' });
            string paso;

            if (pasos.Length == 1) return Tuple.Create(mapeo, propiedad, false);
            
            for(int i = 0; i < pasos.Length -1; i++)
            {
                paso = pasos[i];

                if (!Existe(paso))
                    mapeo.Establecer(new MapeoPropiedadDefinicion(paso, propiedad.UsarReflexion), new MapeoTipo());

                mapeoItem = Obtener(paso);
                if (mapeoItem == null) break;

                mapeoReferencia = (mapeoItem as MapeoReferencia);
                if (mapeoReferencia == null) break;

                mapeo = mapeoReferencia.Mapeo;
            }
                        
            propiedad = new MapeoPropiedadDefinicion( nombre = pasos[pasos.Length - 1], propiedad.UsarReflexion);
            
            return Tuple.Create(mapeo, propiedad, true);
        }

        public IReadOnlyList<MapeoComando> Comandos
        {
            get { return _comandos; }
        }

        public IReadOnlyList<MapeoPropiedad> Propiedades
        {
            get { return _propiedades; }
        }

        public bool UsarReflexion
        {
            get;
        }
    }

}