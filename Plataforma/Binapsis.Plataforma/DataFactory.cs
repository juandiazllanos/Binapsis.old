using Binapsis.Plataforma.Configuracion;
using Binapsis.Plataforma.Estructura;
using Binapsis.Plataforma.Helper;
using Binapsis.Plataforma.Historial;
using Binapsis.Plataforma.Notificaciones.Impl;

using System;

namespace Binapsis.Plataforma
{
    public class DataFactory : IFabrica, IDataFactory
    {
        IFabricaImpl _fabricaImpl; 

        #region Constructores
        public DataFactory()
        {
            _fabricaImpl = new FabricaNotificacion(new FabricaHistorial());
        }

        public DataFactory(IFabricaImpl fabricaImpl)
        {
            _fabricaImpl = fabricaImpl;
        }
        #endregion


        #region Metodos        
        public T Crear<T>() where T : EntidadBase
        {
            return (T)Crear(typeof(T));
        }
        
        public EntidadBase Crear(Type type)
        {
            Tipo tipo = (HelperProvider.TypeHelper as TypeHelper).Obtener(type);

            if (tipo != null)
                return Crear(tipo);
            else 
                return null;
        }
        
        public EntidadBase Crear(Tipo tipo)
        {
            IImplementacion impl = _fabricaImpl.Crear(tipo);
            return Crear(impl);
        }
        
        public EntidadBase Crear(IImplementacion impl)
        {
            Type type = (HelperProvider.TypeHelper as TypeHelper).ObtenerType(impl.Tipo as Tipo);
            return Instanciar(type, impl);
        }

        private EntidadBase Instanciar(Type type, IImplementacion impl)
        {
            EntidadBase instancia = Activator.CreateInstance(type, impl) as EntidadBase;
            return instancia;
        }
        #endregion

        #region Clase estatica
        //public static Fabrica Instancia
        //{
        //    get;
        //    set;
        //}        
        #endregion


        #region IFabrica
        IObjetoDatos IFabrica.Crear(ITipo tipo)
        {
            if (tipo is Tipo tipoItem)
                return Crear(tipoItem);
            else
                return null;
        }

        IObjetoDatos IFabrica.Crear(ITipo tipo, IObjetoDatos propietario)
        {
            //if (tipo is Tipo tipoItem && propietario is EntidadBase propietarioItem)
            //    return Crear(tipoItem, propietarioItem);
            //else
                return null;
        }
        #endregion


        #region IDataFactory
        IObjetoDatos IDataFactory.Create(Type type)
        {
            return Crear(type);
        }

        IObjetoDatos IDataFactory.Create(ITipo tipo)
        {
            return Crear(tipo as Tipo);
        }

        IObjetoDatos IDataFactory.Create(string uri, string tipo)
        {
            return null;
        }
        #endregion
    }
}
