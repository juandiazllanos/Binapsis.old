using System;

namespace Binapsis.Consola.Definicion
{
    public abstract class ColeccionTypeInfo<T> : ColeccionBase<T> where T : DefinicionTypeInfo
    {
        ConsolaInfo _consolaInfo;

        public ColeccionTypeInfo(ConsolaInfo consolaInfo)
        {
            _consolaInfo = consolaInfo;
        }

        public T Crear(Type type)
        {
            return Crear(type.FullName);
        }

        public T Crear(string nombre, Type type)
        {
            TypeInfo typeInfo = _consolaInfo.Types.Crear(type);
            return Crear(nombre, typeInfo);
        }

        public T Crear(string typeName, string assemblyName)
        {
            return Crear(typeName, typeName, assemblyName);
        }

        public T Crear(string nombre, string typeName, string assemblyName)
        {
            return Crear(nombre, typeName, assemblyName, $"{assemblyName}.{typeName}");
        }
        
        public T Crear(string nombre, string typeName, string assemblyName, string typeFullName)
        {
            TypeInfo typeInfo = _consolaInfo.Types.Crear(typeFullName, assemblyName, typeFullName);
            return Crear(nombre, typeInfo);
        }

        public T Crear(string nombre, TypeInfo typeInfo)
        {
            T instancia = Crear(nombre);
            instancia.TypeInfo = typeInfo;
            Agregar(instancia);
            return Obtener(nombre);
        }

        protected ConsolaInfo ConsolaInfo
        {
            get => _consolaInfo;
        }

    }
}
