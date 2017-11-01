using System;
using Binapsis.Plataforma.Estructura;

namespace Binapsis.Plataforma.Helper.Impl
{
    public class KeyHelper : IKeyHelper
    {
        #region Constructores
        static KeyHelper()
        {
            Instancia = new KeyHelper();
        }
        #endregion


        #region Metodos
        public virtual IKey GetKey(IObjetoDatos od)
        {
            if (od == null) return null;

            KeyObjetoDatos key = new KeyObjetoDatos(GetProperty(od.Tipo), od, this);

            if (IsKeyValid(key))
                return key;
            else
                return null;
        }

        public virtual IPropiedad[] GetProperty(ITipo tipo)
        {
            if (tipo != null && tipo.ContienePropiedad("Id"))
                return new IPropiedad[] { tipo["Id"] };
            else
                return null;
        }

        private bool IsKeyValid(IKey key)
        {
            if (key == null) return false;

            bool isValid = false;

            for (int i = 0; i < key.Longitud; i++)
                if (!(isValid = (key.Values[i] != null && 
                    !DefaultValueHelper.Instancia.IsDefaultValue(key.Properties[i], key.Values[i]))))
                    break;

            return isValid;
        }
        #endregion


        #region Estatico
        public static KeyHelper Instancia
        {
            get;            
        }
        #endregion


        #region IKeyHelper
        IKey IKeyHelper.GetKey(IObjetoDatos od)
        {
            return GetKey(od);
        }

        IPropiedad[] IKeyHelper.GetProperty(ITipo tipo)
        {
            return GetProperty(tipo);
        }
        #endregion
    }

    public class Key : IKey
    {
        protected int _longitud;
        protected IPropiedad[] _properties;        
        protected object[] _values;
        
        public Key(IPropiedad[] properties)
        {
            if (properties.Length == 0) return;

            _properties = properties;
            _values = new object[properties.Length];

            _longitud = properties.Length;
        }

        public virtual void SetValue(string propiedad, object value)
        {
            for (int i = 0; i < _longitud; i++)
                if (propiedad == _properties[i].Nombre)
                {
                    _values[i] = value;
                    break;
                }   
        }

        int IKey.Longitud
        {
            get => _longitud;
        }

        IPropiedad[] IKey.Properties
        {
            get => _properties;
        }

        object[] IKey.Values
        {
            get => _values;
        }

        bool IEquatable<IKey>.Equals(IKey other)
        {
            if (other == null) return false;

            bool isEqual = (_longitud == other.Longitud);

            if (!isEqual) return isEqual;

            for (int i = 0; i < _longitud; i++)
                if (!(isEqual = (
                    _properties[i].Nombre.Equals(other.Properties[i].Nombre) &&
                    _values[i].Equals(other.Values[i])
                    )))
                    break;

            return isEqual;
        }

        public override string ToString()
        {
            return string.Join(" ", _values);
        }
    }

    class KeyObjetoDatos : Key
    {
        IObjetoDatos _od;
        //IPropiedad[] _properties;
        IKeyHelper _helper;
        //object[] _values;
        //int _longitud;
        
        internal KeyObjetoDatos(IPropiedad[] properties, IObjetoDatos od, IKeyHelper helper)
            : base(properties)
        {
            //_longitud = properties?.Length ?? 0;

            if (_longitud == 0 || od == null) return;

            _helper = helper;

            _od = od;
            //_properties = properties;
            //_values = new object[_longitud];

            for (int i = 0; i < _longitud; i++) 
                _values[i] = Resolver(_od, _properties[i]);            
        }

        protected virtual object Resolver(IObjetoDatos od, IPropiedad propiedad)
        {
            if (propiedad.Tipo.EsTipoDeDato)
                return od.Obtener(propiedad);

            if (propiedad.EsColeccion) return null;

            IKey key = _helper?.GetKey(od.ObtenerObjetoDatos(propiedad));

            if (key?.Longitud == 1)
                return key.Values[0];
            else
                return key;
        }

        //public bool Equals(IKey other)
        //{
        //    if (other == null) return false;

        //    bool isEqual = (_longitud == other.Longitud);

        //    if (!isEqual) return isEqual;

        //    for (int i = 0; i < _longitud; i++)
        //        if (!(isEqual = (
        //            Properties[i].Nombre.Equals(other.Properties[i].Nombre) && 
        //            Values[i].Equals(other.Values[i])
        //            )))
        //            break;

        //    return isEqual;
        //}

        //public override string ToString()
        //{
        //    return string.Join(" ", _values);
        //}

        //public int Longitud
        //{
        //    get => _longitud;
        //}

        //public IPropiedad[] Properties
        //{
        //    get => _properties;
        //}

        //public object[] Values
        //{
        //    get => _values;
        //}

    }
}
