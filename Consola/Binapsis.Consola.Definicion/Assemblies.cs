using System.Collections;
using System.Collections.Generic;

namespace Binapsis.Consola.Definicion
{
    public class Assemblies : IEnumerable<AssemblyInfo>
    {
        Dictionary<string, AssemblyInfo> _items = new Dictionary<string, AssemblyInfo>();
        ConsolaInfo _consolaInfo;

        public Assemblies(ConsolaInfo consolaInfo)
        {
            _consolaInfo = consolaInfo;
        }

        #region Metodos
        public AssemblyInfo Crear(string assemblyName)
        {
            return Crear(assemblyName, null);
        }

        public AssemblyInfo Crear(string assemblyName, string version)
        {
            return Crear(assemblyName, version, null);
        }

        public AssemblyInfo Crear(string assemblyName, string version, string keyToken)
        {
            return Crear(assemblyName, version, keyToken, null);
        }

        public AssemblyInfo Crear(string assemblyName, string version, string keyToken, string culture)
        {
            AssemblyInfo assemblyInfo = Obtener(assemblyName);

            if (assemblyInfo == null)
                _items.Add(assemblyName, assemblyInfo = new AssemblyInfo(_consolaInfo)
                {
                    AssemblyName = assemblyName,
                    Culture = culture,
                    KeyToken = keyToken,
                    Version = version
                });

            return assemblyInfo;
        }

        public bool Existe(string assemblyName)
        {
            return _items.ContainsKey(assemblyName);
        }

        public AssemblyInfo Obtener(string assemblyName)
        {
            if (_items.ContainsKey(assemblyName))
                return _items[assemblyName];
            else
                return null;
        }
        #endregion


        #region Propiedades
        public AssemblyInfo this[string assemblyName]
        {
            get => Obtener(assemblyName);
        }
        #endregion


        #region IEnumerable
        IEnumerator<AssemblyInfo> IEnumerable<AssemblyInfo>.GetEnumerator()
        {
            return _items.Values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _items.Values.GetEnumerator();
        }
        #endregion
    }
}
