namespace Binapsis.Plataforma.Estructura.Impl.Extension
{
    public static class Extension
    {
        public static IImplementacion Implementacion (this ObjetoBase objetoBase)
        {
            return objetoBase.Impl;
        }

        public static IImplementacion Implementacion (this ImplementacionBase impl)
        {
            return impl.Impl;
        }
    }
}
