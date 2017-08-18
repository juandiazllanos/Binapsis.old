using System;
using System.Collections.Generic;
using System.Text;

namespace Binapsis.Plataforma.Estructura.Impl
{
    class BuilderObjetoBase
    {
        public BuilderObjetoBase(ObjetoBase instancia)
        {
            Instancia = instancia;
        }

        public void Construir(ObjetoBase obj)
        {
            IObjetoDatos od = obj;
            ObjetoBase referencia = null;

            //foreach (IPropiedad propiedad in obj.Tipo.Propiedades)
            //{
            //    if (propiedad.Tipo.EsTipoDeDato) continue;

            //    if (propiedad.Asociacion == Asociacion.Agregacion)
            //    {
            //        referencia = od.ObtenerObjetoDatos(propiedad) as ObjetoBase;
            //        impl.EstablecerObjetoDatos(propiedad, referencia);
            //    }
            //    else if (propiedad.Cardinalidad == Cardinalidad.CeroAMuchos)
            //    {

            //    }
            //    else
            //    {
            //        impl = ObtenerImpl(od, propiedad);
            //        if (impl == null) continue;
            //        obj.CrearObjetoDatos(propiedad, impl);
            //        impl.Propietario = instancia;
            //    }
            //}
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
        
        public ObjetoBase Instancia
        {
            get;
        }
    }
}
