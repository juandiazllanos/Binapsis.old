using Binapsis.Plataforma.Configuracion;
using Binapsis.Plataforma.Datos.Mapeo;
using Binapsis.Plataforma.Estructura;
using System;

namespace Binapsis.Plataforma.Datos.Impl
{
    public class ComandoLectura : ComandoTabla
    {
        internal ComandoLectura(Comando comando, MapeoTabla mapeoTabla) 
            : base(comando, mapeoTabla)
        {
        }

        public override IColeccion EjecutarConsulta()
        {
            return base.EjecutarConsulta();
        }

        public void EstablecerParametro(IPropiedad propiedad, object valor)
        {
            Columna columna = MapeoTabla?.ObtenerColumna(propiedad);
            if (columna == null) throw new Exception($"La propiedad '{propiedad.Nombre}' no tiene una columna asociada.");

            EstablecerParametro(columna, valor);
        }

        public void EstablecerParametro(Columna columna, object valor)
        {
            if (columna == null) return;
            EstablecerParametro(columna.Nombre, valor);
        }
        
    }

    
}
