using System;
using System.Reflection;

namespace Binapsis.Consola.Definicion
{
    public class Types : ColeccionBase<TypeInfo>
    {
        ConsolaInfo _consolaInfo;

        public Types(ConsolaInfo consolaInfo)
        {
            _consolaInfo = consolaInfo;
        }

        protected override TypeInfo Instanciar(string nombre)
        {
            return new TypeInfo(_consolaInfo) { Nombre = nombre };
        }

        public TypeInfo Crear(Type type)
        {
            return Crear(type.Name, type);
        }

        public TypeInfo Crear(string nombre, Type type)
        {
            return Crear(nombre, type.GetTypeInfo().Assembly.GetName().ToString(), type.FullName);
        }

        public TypeInfo Crear(string nombre, string assemblyName)
        {
            return Crear(nombre, assemblyName, $"{assemblyName}.{nombre}");
        }

        public TypeInfo Crear(string nombre, string assemblyName, string typeFullName)
        {
            TypeInfo typeInfo = Crear(nombre);
            typeInfo.AssemblyName = assemblyName;
            typeInfo.TypeFullName = typeFullName;
            return typeInfo;
        }
    }
}
