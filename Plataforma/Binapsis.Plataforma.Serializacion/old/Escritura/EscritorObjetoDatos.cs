using Binapsis.Plataforma.Estructura;
using System.Collections.Generic;
using System.Linq;
using System;

namespace Binapsis.Plataforma.Serializacion.Escritura
{
	internal class EscritorObjetoDatos : IMetodoEscritura
    {
		IEscritor _escritor;
		IObjetoDatos _od;
        IEnumerable<IPropiedad> _propiedades;

		public EscritorObjetoDatos(IEscritor escritor, IObjetoDatos od)
        {
            _escritor = escritor;
            _od = od;

            _propiedades = from propiedad in _od.Tipo.Propiedades
                           where propiedad.Tipo.EsTipoDeDato && _od.Establecido(propiedad)
                           select propiedad;
		}
        
		void IMetodoEscritura.Escribir()
        {
            foreach (IPropiedad propiedad in _propiedades)
                Escribir(propiedad);
		}

        private void Escribir(IPropiedad propiedad)
        {
            EscritorAtributo.Escribir(_escritor, _od, propiedad);
        }

        public int Longitud { get { return _propiedades.Count(); } }
	}

}