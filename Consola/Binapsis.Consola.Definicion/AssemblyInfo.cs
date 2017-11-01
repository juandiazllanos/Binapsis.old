using System.Text;

namespace Binapsis.Consola.Definicion
{
    public class AssemblyInfo : ItemConsolaBase
    {
        internal AssemblyInfo(ConsolaInfo consolaInfo) 
            : base(consolaInfo)
        {
        }

        public string AssemblyName
        {
            get;
            set;
        }

        public string Culture
        {
            get;
            set;
        }

        public string FileName
        {
            get;
            set;
        }

        public string KeyToken
        {
            get;
            set;
        }

        public string Version
        {
            get;
            set;
        }

        public override string ToString()
        {
            StringBuilder assembly = new StringBuilder(AssemblyName);

            if (Version != null)
                assembly.Append($", Version={Version}");

            if (Culture != null)
                assembly.Append($", Culture={Culture}");

            if (KeyToken != null)
                assembly.Append($", PublicKeyToken={KeyToken}");

            return assembly.ToString();
        }

    }
}
