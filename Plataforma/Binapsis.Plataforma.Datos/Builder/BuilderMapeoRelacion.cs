using Binapsis.Plataforma.Configuracion;
using Binapsis.Plataforma.Datos.Mapeo;
using Binapsis.Plataforma.Estructura;
using System;

namespace Binapsis.Plataforma.Datos.Builder
{
    class BuilderMapeoRelacion : BuilderMapeo
    {
        char[] KEY_SPACE = new char[] { ' ' };

        public BuilderMapeoRelacion(MapeoRelacion mapeoRelacion)
        {
            MapeoRelacion = mapeoRelacion;
        }

        public void Construir(ITipo tipo, IPropiedad propiedad)
        {
            Relacion relacion = Configuracion.ObtenerRelacion(tipo.Uri, tipo.Nombre, propiedad.Nombre);
            Construir(tipo, propiedad, relacion);
        }

        public void Construir(ITipo tipo, IPropiedad propiedad, Relacion relacion)
        {
            MapeoRelacion.Relacion = relacion ?? throw new Exception($"La relación '{tipo.Uri}.{tipo.Nombre}.{propiedad.Nombre}' no existe.");
            MapeoRelacion.Tipo = tipo;
            MapeoRelacion.Propiedad = propiedad;
            
            if (propiedad.Asociacion == Asociacion.Agregacion)
                ConstruirRelacionSecundariaPrincipal();
            else if (propiedad.Asociacion == Asociacion.Composicion)
                ConstruirRelacionPrincipalSecundaria();
            
            ConstruirClaves(relacion);
        }

        private void ConstruirRelacionPrincipalSecundaria()
        {
            ITipo tipoPrincipal = MapeoRelacion.Tipo;
            ITipo tipoSecundario = MapeoRelacion.Propiedad.Tipo;
            
            MapeoRelacion.TablaPrincipal = MapeoCatalogo?.ObtenerMapeoTabla(tipoPrincipal, MapeoRelacion.Relacion.TablaPrincipal);
            MapeoRelacion.TablaSecundaria = MapeoCatalogo?.ObtenerMapeoTabla(tipoSecundario, MapeoRelacion.Relacion.TablaSecundaria);
        }

        private void ConstruirRelacionSecundariaPrincipal()
        {
            ITipo tipoPrincipal = MapeoRelacion.Propiedad.Tipo;
            ITipo tipoSecundario = MapeoRelacion.Tipo;

            MapeoRelacion.TablaPrincipal = MapeoCatalogo?.ObtenerMapeoTabla(tipoPrincipal, MapeoRelacion.Relacion.TablaPrincipal);
            MapeoRelacion.TablaSecundaria = MapeoCatalogo?.ObtenerMapeoTabla(tipoSecundario, MapeoRelacion.Relacion.TablaSecundaria);
        }

        private void ConstruirClaves(Relacion relacion)
        {
            if (relacion == null) return;

            string[] clavePrincipal = relacion.ColumnaPrincipal?.Split(KEY_SPACE, StringSplitOptions.RemoveEmptyEntries);
            string[] claveSecundaria = relacion.ColumnaSecundaria?.Split(KEY_SPACE, StringSplitOptions.RemoveEmptyEntries);

            if (clavePrincipal == null || clavePrincipal == null || clavePrincipal.Length != claveSecundaria.Length) return;

            for (int i = 0; i < clavePrincipal.Length; i++)
                ConstruirClave(clavePrincipal[i], claveSecundaria[i]);
        }
        
        private void ConstruirClave(string columnaPrincipal, string columnaSecundaria)
        {
            Columna columnaItemPrincipal = MapeoRelacion.TablaPrincipal.Tabla.ObtenerColumna(columnaPrincipal);
            Columna columnaItemSecundaria = MapeoRelacion.TablaSecundaria.Tabla.ObtenerColumna(columnaSecundaria);

            // construir la columna en la tabla secundaria
            if (columnaItemSecundaria == null)
            {
                columnaItemSecundaria = MapeoRelacion.TablaSecundaria.Tabla.CrearColumna();
                columnaItemSecundaria.Nombre = columnaSecundaria;
            }

            if (columnaItemSecundaria != null && string.IsNullOrEmpty(columnaItemSecundaria.Propiedad) && 
                MapeoRelacion.Propiedad.Asociacion == Asociacion.Agregacion)
                columnaItemSecundaria.Propiedad = MapeoRelacion.Propiedad.Nombre;
            
            ConstruirClave(columnaItemPrincipal, columnaItemSecundaria);
        }

        private void ConstruirClave(Columna columnaPrincipal, Columna columnaSecundaria)
        {
            MapeoColumna mapeoColumnaPrincipal = MapeoCatalogo.ObtenerMapeoColumna(MapeoRelacion.TablaPrincipal, columnaPrincipal);
            MapeoColumnaClave mapeoColumnaSecundaria = MapeoCatalogo.ObtenerMapeoColumnaClave(MapeoRelacion.TablaSecundaria, columnaSecundaria); 

            ConstruirClave(mapeoColumnaPrincipal, mapeoColumnaSecundaria);
        }

        private void ConstruirClave(MapeoColumna mapeoColumnaPrincipal, MapeoColumnaClave mapeoColumnaSecundaria)
        {
            if (mapeoColumnaPrincipal == null || mapeoColumnaSecundaria == null) return;

            MapeoRelacionClave mapeoRelacionClave = new MapeoRelacionClave(MapeoRelacion);
            
            mapeoRelacionClave.ClavePrincipal = mapeoColumnaPrincipal;
            mapeoRelacionClave.ClaveSecundaria = mapeoColumnaSecundaria;
            // agregar clave a la relacion
            MapeoRelacion.Claves.Add(mapeoRelacionClave);
            // asignar clave al mapeo columna
            mapeoColumnaSecundaria.MapeoRelacionClave = mapeoRelacionClave;
        }

        public MapeoRelacion MapeoRelacion
        {
            get;
        }
        
    }
}
