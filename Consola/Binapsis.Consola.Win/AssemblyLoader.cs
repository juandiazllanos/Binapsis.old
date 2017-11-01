using Binapsis.Consola.Definicion;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;

namespace Binapsis.Consola.Win
{
    class AssemblyLoader
    {
        ConsolaInfo _consolaInfo;
        Dictionary<string, Assembly> _assemblies = new Dictionary<string, Assembly>();

        public AssemblyLoader(AppDomain domain, ConsolaInfo consolaInfo)
        {
            _consolaInfo = consolaInfo;
            domain.AssemblyResolve += (s, e) => Load(e.Name);
        }

        public Assembly Load(string assemblyName)
        {
            Debug.WriteLine($"Loading Assembly: {assemblyName}");
            //Console.WriteLine($"Loading Assembly: {assemblyName}");

            Assembly assembly = null;

            if (_assemblies.ContainsKey(assemblyName))
                assembly = _assemblies[assemblyName];
            else
                _assemblies.Add(assemblyName, 
                    assembly = Load(_consolaInfo.Assemblies[assemblyName]));

            return assembly;
        }

        private Assembly Load(Definicion.AssemblyInfo assemblyInfo)
        {
            if (assemblyInfo != null)
                return Assembly.LoadFrom(assemblyInfo.FileName);            
            else 
                return null;
        }
    }
}
