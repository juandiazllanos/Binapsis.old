using System;
using Binapsis.Consola.Definicion;
using Assembly = System.Reflection.Assembly;
using AssemblyName = System.Reflection.AssemblyName;

namespace Binapsis.Consola.Helpers
{
    public static class TypeInfoHelper
    {
        public static Type ObtenerType(DefinicionTypeInfo definicionTypeInfo)
        {
            return ObtenerType(definicionTypeInfo.TypeInfo);
        }

        public static Type ObtenerType(TypeInfo typeInfo)
        {
            Type type = Type.GetType($"{typeInfo.TypeFullName}, {typeInfo.AssemblyName}");
            return type;
        }

        public static object Crear(DefinicionTypeInfo definicionTypeInfo, params object[] args)
        {
            if (definicionTypeInfo?.TypeInfo != null)
                return Crear(definicionTypeInfo.TypeInfo, args);
            else
                return null;
        }

        public static object Crear(TypeInfo typeInfo, params object[] args)
        {
            Type type = ObtenerType(typeInfo);            
            
            if (type == null) return null;

            if (args == null)
                return Activator.CreateInstance(type);
            else
                return Activator.CreateInstance(type, args);
        }

        //public static Assembly CargarAssembly(TypeInfo typeInfo)
        //{
            
        //    AssemblyInfo assemblyInfo = typeInfo.ConsolaInfo.Assemblies[typeInfo.AssemblyName];
        //    if (assemblyInfo == null) return null;

        //    AssemblyName assemblyName = new AssemblyName(assemblyInfo.ToString());
        //    //{
        //    //    Name = assemblyInfo.AssemblyName,                
        //    //    Version = new Version(assemblyInfo.Version)                
        //    //};
            
        //    return Assembly.Load(assemblyName);
        //}

    }
}
