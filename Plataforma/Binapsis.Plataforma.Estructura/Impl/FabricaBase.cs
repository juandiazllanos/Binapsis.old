using System.Diagnostics;

namespace Binapsis.Plataforma.Estructura.Impl
{
    public abstract class FabricaBase<T> : IFabrica where T : ObjetoBase 
    {
        IFabricaImpl _fabrica;

        public FabricaBase()
            : this(FabricaImpl.Instancia)
        {            
        }

        public FabricaBase(IFabricaImpl fabrica)
        {
            _fabrica = fabrica;
        }

        public abstract T Crear(IImplementacion impl);
        
        public virtual T Crear(ITipo tipo)
        {
            return Crear(_fabrica.Crear(tipo));
        }

        public virtual T Crear(ITipo tipo, T propietario)
        {
            return Crear(_fabrica.Crear(tipo, propietario));
        }

        protected virtual T Crear(ObjetoBase obj) 
        {            
            if (obj == null) return default(T);

            // obtener implementacion
            IImplementacion impl = obj.Impl;
            // crear instancia
            T instancia = Crear(impl);
            // construir instancia
            Builder<T> builder = new Builder<T>(instancia);
            builder.Fabrica = this;
            builder.Construir(obj);

            return instancia;

            //if (obj == null) return default(T);
            //if (obj is T) return (T)obj;
            
            //Implementacion impl = ObtenerImpl(obj.Impl);
            //if (impl == null) return default(T);

            //T instancia = Crear(impl);

            //Construir(instancia, impl);            

            //return instancia;
        }

        //private void Construir(ObjetoBase obj, Implementacion impl)
        //{
        //    foreach (IPropiedad propiedad in impl.Tipo.Propiedades)
        //    {
        //        if (propiedad.Tipo.EsTipoDeDato) continue;
        //        Construir(obj, impl, propiedad);
        //    }
        //}

        //private void Construir(ObjetoBase obj, Implementacion impl, IPropiedad propiedad)
        //{
        //    if (propiedad.Cardinalidad == Cardinalidad.CeroAMuchos)
        //        ConstruirColeccion(obj, propiedad, impl);
        //    else
        //        ConstruirReferencia(obj, impl, propiedad);
        //}

        //private void ConstruirReferencia(ObjetoBase obj, Implementacion impl, IPropiedad propiedad)
        //{
        //    // obtener referencia valor
        //    ObjetoBase referencia = impl.ObtenerObjetoDatos(propiedad) as ObjetoBase;
        //    if (referencia == null) return;

        //    // obtener impl de referencia
        //    Implementacion referenciaImpl = ObtenerImpl(referencia.Impl);

        //    // asignar propietario a referencia
        //    if (propiedad.Asociacion == Asociacion.Composicion)
        //        referenciaImpl.Propietario = obj;

        //    // crear referencia objeto base
        //    ObjetoBase instancia = Crear(referencia);
        //    // establecer 
        //    impl.EstablecerObjetoDatos(propiedad, instancia);
        //}

        //private void ConstruirColeccion(ObjetoBase obj, IPropiedad propiedad, Implementacion impl)
        //{
        //    IColeccion coleccion = impl.ObtenerColeccion(propiedad);

        //    ObjetoBase item;
        //    Implementacion itemImpl;
        //    ObjetoBase itemObj;

        //    for(int i = 0; i < coleccion.Longitud; i++)
        //    {
        //        item = coleccion[i] as ObjetoBase;
        //        if (item == null) continue;

        //        // obtener impl de item
        //        itemImpl = ObtenerImpl(item);
        //        if (itemImpl == null) continue;
        //        // asignar propietario a item
        //        itemImpl.Propietario = obj;
        //        // crear nueva abstraccion item
        //        itemObj = Crear(item);
        //        // asignar referencia a item
        //        impl.EstablecerObjetoDatos(propiedad, i, itemObj);
        //    }
        //}

        //private Implementacion ObtenerImpl(IObjetoDatos od)
        //{
        //    IImplementacion impl = (od as ObjetoBase).Impl;

        //    if (impl != null)
        //        return ObtenerImpl(impl);
        //    else
        //        return null;
        //}

        //private Implementacion ObtenerImpl(IObjetoDatos od, IPropiedad propiedad)
        //{
        //    IImplementacion impl = (od.ObtenerObjetoDatos(propiedad) as ObjetoBase)?.Impl;

        //    if (impl != null)
        //        return ObtenerImpl(impl);
        //    else
        //        return null;
        //}

        //private Implementacion ObtenerImpl(IImplementacion impl)
        //{
        //    Implementacion resul = null;

        //    while (resul == null && impl != null)
        //        if (impl is ImplementacionBase implementacionBase)
        //            impl = implementacionBase.Impl;
        //        else if (impl is Implementacion implementacion)
        //            resul = implementacion;
        //        else
        //            impl = null;
                
        //    return resul;
        //}

        #region IFabrica
        IObjetoDatos IFabrica.Crear(ITipo tipo)
        {
            return Crear(tipo);
        }

        IObjetoDatos IFabrica.Crear(ITipo tipo, IObjetoDatos propietario)
        {
            return Crear(tipo, (T)propietario);
        }
        #endregion

    }
}
