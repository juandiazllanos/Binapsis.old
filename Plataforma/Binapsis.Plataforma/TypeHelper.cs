using Binapsis.Plataforma.AgenteConfiguracion;
using Binapsis.Plataforma.Configuracion;
using Binapsis.Plataforma.Estructura;
using Binapsis.Plataforma.Helper;

using System;

namespace Binapsis.Plataforma
{
    public class TypeHelper : ITypeHelper
    {        

        #region Metodos
        public Tipo Obtener(string uri, string nombre)
        {
            return HelperConfig.ObtenerTipo(uri, nombre);
        }

        public Tipo Obtener(Type type)
        {
            return Obtener(type.Namespace, type.Name);
        }

        public Type ObtenerType(Tipo tipo)
        {
            if (tipo != null)
                return ObtenerType(tipo.Uri.Ensamblado.Nombre, tipo.Uri.Nombre, tipo.Nombre);
            else
                return null;
        }
                
        private Type ObtenerType(string ensamblado, string espacioNombres, string nombre)
        {
            return Type.GetType($"{espacioNombres}.{nombre}, {ensamblado}");
        }
        #endregion


        #region ITypeHelper
        ITipo ITypeHelper.Definir(IObjetoDatos tipo)
        {
            throw new NotImplementedException();
        }

        ITipo ITypeHelper.Obtener(string uri, string nombre)
        {
            return Obtener(uri, nombre);
        }

        ITipo ITypeHelper.Obtener(Type type)
        {
            return Obtener(type);
        }
        #endregion
    }
}
