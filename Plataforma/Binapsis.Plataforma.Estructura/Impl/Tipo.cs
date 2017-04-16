using System;
using System.Collections.Generic;
using System.Linq;

namespace Binapsis.Plataforma.Estructura.Impl
{
    public class Tipo : ITipo
    {

        private List<IPropiedad> propiedades;

		public Tipo()
        {
            propiedades = new List<IPropiedad>();
		}
        
		public string Alias { get; set; }

		public ITipo Base { get; set; }

		public bool EsTipoDeDato { get; set; }

		public string Nombre { get; set; }

        public string Uri { get; set; }

        public IReadOnlyList<IPropiedad> Propiedades
        {
            get
            {
                return propiedades; 
            }
        }

        public IPropiedad this[string nombre]
        {
            get
            {
                return ObtenerPropiedad(nombre);
            }
        }

        public IPropiedad this[int indice]
        {
            get
            {
                return ObtenerPropiedad(indice);
            }
        }

        public void AgregarPropiedad(IPropiedad propiedad)
        {
            if  (!propiedades.Any(item => item.Nombre == propiedad.Nombre))
            {
                ((Propiedad)propiedad).Indice = propiedades.Count;
                propiedades.Add(propiedad);                
            }            
        }

        public void RemoverPropiedad(IPropiedad propiedad)
        {
            if (propiedades.Contains(propiedad))
            {
                propiedades.Remove(propiedad);
            }
        }

        public bool ContienePropiedad(string nombre)
        {
            return propiedades.Exists((item) => item.Nombre == nombre);
        }

        public IPropiedad ObtenerPropiedad(string nombre)
        {
            return propiedades.FirstOrDefault(item => item.Nombre == nombre); 
		}
        
		public IPropiedad ObtenerPropiedad(int indice)
        {
			return propiedades[indice];
		}

    }    
} 