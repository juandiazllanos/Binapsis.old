using Binapsis.Plataforma.Configuracion;
using Binapsis.Plataforma.Datos.Mapeo;
using Binapsis.Plataforma.Estructura;
using System.Linq;

namespace Binapsis.Plataforma.Datos.Builder
{
    class BuilderMapeoTabla : BuilderMapeo
    {
        public BuilderMapeoTabla(MapeoTabla mapeoTabla)
        {
            MapeoTabla = mapeoTabla;
        }

        public void Construir(ITipo tipo, Tabla tabla)
        {
            if (tipo == null) return;

            if (tabla == null)
                tabla = CrearTabla(tipo);

            MapeoTabla.Tipo = tipo;
            MapeoTabla.Tabla = tabla;

            ConstruirColumnas();
        }

        private Tabla CrearTabla(ITipo tipo)
        {
            Tabla tabla = Fabrica.Instancia.Crear<Tabla>();
            tabla.Nombre = tipo.Nombre;
            tabla.TipoAsociado = $"{tipo.Uri}.{tipo.Nombre}";
            return tabla;
        }

        private Columna CrearColumna(IPropiedad propiedad)
        {
            Columna columna = MapeoTabla.Tabla.CrearColumna();
            columna.Nombre = propiedad.Nombre;
            columna.Propiedad = propiedad.Nombre;
            return columna;
        }

        private void ConstruirColumnas()
        {
            // construir mapeo con columna (solo clave primaria)
            var columnas = MapeoTabla.Tabla.Columnas.OfType<Columna>().Where(item => string.IsNullOrEmpty(item.Propiedad) && item.ClavePrimaria);

            foreach (Columna columna in columnas)
                ConstruirColumna(null, columna);

            // construir mapeo con propiedad
            var atributos = MapeoTabla.Tipo.Propiedades.Where(item => item.Tipo.EsTipoDeDato);

            foreach (IPropiedad atributo in atributos)
                ConstruirColumna(atributo);            
        }
        
        private void ConstruirColumna(IPropiedad propiedad)
        {
            Columna columna = MapeoTabla.Tabla.Columnas.FirstOrDefault(item => (item as Columna)?.Propiedad == propiedad.Nombre) as Columna;

            if (columna == null)
                columna = CrearColumna(propiedad);

            ConstruirColumna(propiedad, columna);
        }

        private void ConstruirColumna(IPropiedad propiedad, Columna columna)
        {
            MapeoColumna mapeoColumna = new MapeoColumna(MapeoTabla);
            mapeoColumna.Columna = columna;
            mapeoColumna.Propiedad = propiedad;

            MapeoTabla.Columnas.Add(mapeoColumna);
        }
        
        public MapeoTabla MapeoTabla
        {
            get;
        }
    }
}
