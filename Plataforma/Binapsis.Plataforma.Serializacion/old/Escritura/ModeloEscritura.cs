using Binapsis.Plataforma.Estructura;
using System;
using System.Collections.Generic;

namespace Binapsis.Plataforma.Serializacion.Escritura
{
	internal class ModeloEscritura : IMetodoEscritura, IModeloEscritura
    {
		private List<IObjetoDatos> _od;
		private Identidad _stack;
		private IEscritor _escritor;

        public ModeloEscritura(IEscritor escritor, IObjetoDatos od)
        {
            _escritor = escritor;
            _stack = new Identidad();
            _od = new List<IObjetoDatos>() { od };            
        }

        #region IModelo        
        IMetodoEscritura IModeloEscritura.Crear(IObjetoDatos od)
        {
            return Crear(od);
        }

        IMetodoEscritura IModeloEscritura.Crear(IObjetoDatos propietario, IPropiedad propiedad)
        {
            return Crear(propietario, propiedad, 0);
        }

        IMetodoEscritura IModeloEscritura.Crear(IObjetoDatos propietario, IPropiedad propiedad, int indice)
        {
            return Crear(propietario, propiedad, indice);
        }
        #endregion

        #region IMetodo
        void IMetodoEscritura.Escribir()
        {
            Escribir();
        }
        #endregion
        
        private IMetodoEscritura Crear(IObjetoDatos od)
        {
            IMetodoEscritura metodo;
            IMetodoEscritura metodood;
            int refid = _stack.Obtener(od);

            metodood = new MetodoEscrituraObjetoDatos(this, _escritor, od, refid);
            metodo = new MetodoEscrituraTipo(this, _escritor, metodood, od, refid);

            return metodo;
        }
        
        private IMetodoEscritura Crear(IObjetoDatos propietario, IPropiedad propiedad, int indice)
        {
            IMetodoEscritura metodo;
            IObjetoDatos od;
            int refid;
            int propietarioid;

            if (propiedad.Cardinalidad >= Cardinalidad.Muchos)
                od = propietario.ObtenerColeccion(propiedad)[indice];
            else 
                od = propietario.ObtenerObjetoDatos(propiedad);

            refid = _stack.Obtener(od);
            propietarioid = _stack.Obtener(propietario);

            if (propiedad.Asociacion == Asociacion.Composicion)
            {
                metodo = new MetodoEscrituraReferencia(this, _escritor, od, refid, propietarioid, propiedad);
            }                
            else
            {
                metodo = new MetodoEscrituraAsociacion(this, _escritor, propietarioid, propiedad, refid);
                _od.Add(od);
            }                

            return metodo;
        }

        private void Escribir()
        {
            IMetodoEscritura metodo;
            int i = 0;

            while(i <= (_od.Count - 1))
            {
                metodo = Crear(_od[i]);
                metodo.Escribir();

                i++;
            }
        }
        
    }

}