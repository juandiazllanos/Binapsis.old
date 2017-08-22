using Binapsis.Plataforma.Estructura.Impl;
using System.Collections.Generic;

namespace Binapsis.Plataforma.Estructura
{
    class Builder<T> where T : ObjetoBase
    {
        Dictionary<IImplementacion, T> _items;

        public Builder(T obj)
        {
            _items = new Dictionary<IImplementacion, T>();
            Instancia = obj;
        }


        public void Construir(ObjetoBase obj)
        {            
            if (obj == null) return;

            IImplementacion impl = obj.Impl;
            if (impl == null) return;
            
            _items.Add(impl, Instancia);

            Construir(Instancia, impl);
        }


        private void Construir(ObjetoBase obj, IImplementacion impl)
        {
            foreach (IPropiedad propiedad in impl.Tipo.Propiedades)
            {
                if (propiedad.Tipo.EsTipoDeDato) continue;
                Construir(obj, impl, propiedad);
            }
        }

        private void Construir(ObjetoBase obj, IImplementacion impl, IPropiedad propiedad)
        {
            if (propiedad.Cardinalidad == Cardinalidad.CeroAMuchos)
                ConstruirColeccion(obj, propiedad, impl);
            else
                ConstruirReferencia(obj, impl, propiedad);
        }

        private void ConstruirReferencia(ObjetoBase obj, IImplementacion impl, IPropiedad propiedad)
        {
            // obtener referencia valor
            ObjetoBase referencia = impl.ObtenerObjetoDatos(propiedad) as ObjetoBase;
            if (referencia == null) return;

            // obtener impl de referencia
            //Implementacion referenciaImpl = ObtenerImpl(referencia.Impl);

            // asignar propietario a referencia
            //if (propiedad.Asociacion == Asociacion.Composicion)
            //    referenciaImpl.Propietario = obj;

            // crear referencia objeto base
            ObjetoBase instancia = Crear(referencia);
            // establecer 
            //impl.EstablecerObjetoDatos(propiedad, instancia);
            EstablecerObjetoDatos(obj, propiedad, instancia);
        }

        private void ConstruirColeccion(ObjetoBase obj, IPropiedad propiedad, IImplementacion impl)
        {
            IColeccion coleccion = impl.ObtenerColeccion(propiedad);
            
            ObjetoBase item;
            //Implementacion itemImpl;
            ObjetoBase itemObj;

            for (int i = 0; i < coleccion.Longitud; i++)
            {
                item = coleccion[i] as ObjetoBase;
                if (item == null) continue;

                // obtener impl de item
                //itemImpl = ObtenerImpl(item);
                //if (itemImpl == null) continue;
                // asignar propietario a item
                //itemImpl.Propietario = obj;
                // crear nueva abstraccion item
                itemObj = Crear(item);
                // asignar referencia a item                
                //implInterna.EstablecerObjetoDatos(propiedad, i, itemObj);
                EstablecerObjetoDatos(obj, propiedad, itemObj);
            }
        }

        private void EstablecerObjetoDatos(ObjetoBase instancia, IPropiedad propiedad, ObjetoBase valor)
        {
            Implementacion impl = ObtenerImpl(instancia);
            // asignar propietario
            if (propiedad.Asociacion == Asociacion.Composicion)
                impl.Propietario = instancia;
            // establecer valor
            impl.EstablecerObjetoDatos(propiedad, valor);
        }

        private void EstablecerObjetoDatos(ObjetoBase instancia, IPropiedad propiedad, ObjetoBase valor, int indice)
        {
            Implementacion impl = ObtenerImpl(instancia);
            // asignar propietario
            if (propiedad.Asociacion == Asociacion.Composicion)
                impl.Propietario = instancia;
            // establecer valor
            impl.EstablecerObjetoDatos(propiedad, indice, valor);
        }

        private Implementacion ObtenerImpl(IObjetoDatos od)
        {
            IImplementacion impl = (od as ObjetoBase).Impl;

            if (impl != null)
                return ObtenerImpl(impl);
            else
                return null;
        }

        private Implementacion ObtenerImpl(IObjetoDatos od, IPropiedad propiedad)
        {
            IImplementacion impl = (od.ObtenerObjetoDatos(propiedad) as ObjetoBase)?.Impl;

            if (impl != null)
                return ObtenerImpl(impl);
            else
                return null;
        }

        private Implementacion ObtenerImpl(IImplementacion impl)
        {
            Implementacion resul = null;

            while (resul == null && impl != null)
                if (impl is ImplementacionBase implementacionBase)
                    impl = implementacionBase.Impl;
                else if (impl is Implementacion implementacion)
                    resul = implementacion;
                else
                    impl = null;

            return resul;
        }

        private T Crear(ObjetoBase obj)
        {
            if (obj == null) return default(T);
            if (obj is T) return (T)obj;
            
            IImplementacion impl = obj.Impl;
            if (impl == null) return default(T);

            if (_items.ContainsKey(impl)) return _items[impl];

            T instancia = Fabrica.Crear(impl);
            _items.Add(impl, instancia);
                        
            Construir(instancia, impl);

            return instancia;
        }


        #region Propiedades
        public FabricaBase<T> Fabrica
        {
            get;
            set;
        }

        private T Instancia
        {
            get;
        }
        #endregion
    }
}
