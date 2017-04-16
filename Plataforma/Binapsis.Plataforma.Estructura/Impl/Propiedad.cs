using System;

namespace Binapsis.Plataforma.Estructura.Impl
{
	public class Propiedad : IPropiedad
    {
		public Propiedad()
        {
            Asociacion = Asociacion.Ninguna;
            Cardinalidad = Cardinalidad.Cero;
		}
        
		public string Alias { get; set; }
        
		public Asociacion Asociacion { get; set; }
		
		public Cardinalidad Cardinalidad { get; set; }

        public bool EsColeccion { get { return Cardinalidad >= Cardinalidad.Muchos; } }

        public int Indice { get; set; }

		public string Nombre { get; set; }
        
		public ITipo Tipo { get; set; }
		
		public object ValorInicial { get; set; }
	}
}