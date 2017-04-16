using System;
using Binapsis.Plataforma.Estructura;

namespace Binapsis.Plataforma.Historial.Interno
{
	internal class HistorialComando
    {
		protected HistorialEstado _estado;
        
		public HistorialComando(HistorialEstado estado)
        {
            _estado = estado;
		}

        public virtual void Deshacer()
        {
           
        }
        
		public virtual void Deshacer(IImplementacion impl, IPropiedad propiedad, bool valor)
        {
            
		}

		public virtual void Deshacer(IImplementacion impl, IPropiedad propiedad, byte valor)
        {

		}
        
		public virtual void Deshacer(IImplementacion impl, IPropiedad propiedad, char valor)
        {

		}
        
		public virtual void Deshacer(IImplementacion impl, IPropiedad propiedad, DateTime valor)
        {

		}
        
		public virtual void Deshacer(IImplementacion impl, IPropiedad propiedad, decimal valor)
        {

		}
        
		public virtual void Deshacer(IImplementacion impl, IPropiedad propiedad, double valor)
        {

		}
        
		public virtual void Deshacer(IImplementacion impl, IPropiedad propiedad, float valor)
        {

		}
        
		public virtual void Deshacer(IImplementacion impl, IPropiedad propiedad, int valor)
        {

		}
        
		public virtual void Deshacer(IImplementacion impl, IPropiedad propiedad, long valor)
        {

		}
        
		public virtual void Deshacer(IImplementacion impl, IPropiedad propiedad, object valor)
        {

		}
        
		public virtual void Deshacer(IImplementacion impl, IPropiedad propiedad, IObjetoDatos valor)
        {

		}

        public virtual void Deshacer(IImplementacion impl, IPropiedad propiedad, IObjetoDatos valor, int indice)
        {

        }

        public virtual void Deshacer(IImplementacion impl, IPropiedad propiedad, sbyte valor)
        {

		}
        
		public virtual void Deshacer(IImplementacion impl, IPropiedad propiedad, short valor)
        {

		}
        
		public virtual void Deshacer(IImplementacion impl, IPropiedad propiedad, string valor)
        {

		}

        public virtual void Deshacer(IImplementacion impl, IPropiedad propiedad, uint valor)
        {

        }

        public virtual void Deshacer(IImplementacion impl, IPropiedad propiedad, ulong valor)
        {

		}
        
		public virtual void Deshacer(IImplementacion impl, IPropiedad propiedad, ushort valor)
        {

		}
        
    }

}