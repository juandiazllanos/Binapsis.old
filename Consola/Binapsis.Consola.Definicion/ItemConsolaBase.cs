using System;
using System.Collections.Generic;
using System.Text;

namespace Binapsis.Consola.Definicion
{
    public class ItemConsolaBase : DefinicionBase
    {
        internal ItemConsolaBase(ConsolaInfo consolaInfo)
        {
            ConsolaInfo = consolaInfo;
        }

        public ConsolaInfo ConsolaInfo
        {
            get;
        }
    }
}
