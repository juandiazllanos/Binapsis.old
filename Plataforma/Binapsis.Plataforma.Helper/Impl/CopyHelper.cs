using Binapsis.Plataforma.Estructura;
using Binapsis.Plataforma.Estructura.Impl;

namespace Binapsis.Plataforma.Helper.Impl
{
    public class CopyHelper : ICopyHelper
    {
        IFabrica _fabrica;

        public CopyHelper()
            : this(FabricaDatos.Instancia)
        {
        }

        public CopyHelper(IFabrica fabrica)
        {
            _fabrica = fabrica;
        }

        public IObjetoDatos Copiar(IObjetoDatos od)
        {
            if (od == null) return null;

            // instanciar copia
            IObjetoDatos copia = _fabrica.Crear(od.Tipo);
            // copiar original
            Copiar(od, copia);            

            return copia;
        }


        public IObjetoDatos CopiarSuperficial(IObjetoDatos od)
        {
            if (od == null) return null;

            // instanciar copia
            IObjetoDatos copia = _fabrica.Crear(od.Tipo);
            // copiar original
            CopiarSuperficial(od, copia);

            return copia;
        }

        public void Copiar(IObjetoDatos original, IObjetoDatos copia)
        {
            Copiar(original, copia, false);
        }

        public void CopiarSuperficial(IObjetoDatos original, IObjetoDatos copia)
        {
            Copiar(original, copia, true);
        }

        private void Copiar(IObjetoDatos original, IObjetoDatos copia, bool superficial)
        {
            foreach (IPropiedad propiedad in original.Tipo.Propiedades)
                Copiar(original, copia, propiedad, superficial);
        }

        private void Copiar(IObjetoDatos original, IObjetoDatos copia, IPropiedad propiedad, bool superficial)
        {
            if (propiedad.Tipo.EsTipoDeDato)
                CopiarAtributo(original, copia, propiedad);
            else if (!superficial)
                CopiarReferencia(original, copia, propiedad);
        }

        private void CopiarColeccion(IObjetoDatos original, IObjetoDatos copia, IPropiedad propiedad)
        {
            IColeccion coleccion = original.ObtenerColeccion(propiedad);

            foreach (IObjetoDatos item in coleccion)
                Copiar(item, copia.CrearObjetoDatos(propiedad));
        }

        private void CopiarReferencia(IObjetoDatos original, IObjetoDatos copia, IPropiedad propiedad)
        {
            if (propiedad.Tipo.EsTipoDeDato || !original.Establecido(propiedad)) return;

            if (propiedad.Cardinalidad == Cardinalidad.CeroAMuchos)
                CopiarColeccion(original, copia, propiedad);
            else if (propiedad.Asociacion == Asociacion.Composicion && original.Establecido(propiedad))
                Copiar(original.ObtenerObjetoDatos(propiedad), copia.CrearObjetoDatos(propiedad));
            else
                copia.EstablecerObjetoDatos(propiedad, original.ObtenerObjetoDatos(propiedad));
        }


        private void CopiarAtributo(IObjetoDatos original, IObjetoDatos copia, IPropiedad propiedad)
        {
            if (!propiedad.Tipo.EsTipoDeDato || !original.Establecido(propiedad)) return;
                        
            switch(propiedad.Tipo.Nombre)
            {
                case "Boolean":
                    copia.EstablecerBoolean(propiedad, original.ObtenerBoolean(propiedad));
                    break;

                case "Byte":
                    copia.EstablecerByte(propiedad, original.ObtenerByte(propiedad));
                    break;

                case "Char":
                    copia.EstablecerChar(propiedad, original.ObtenerChar(propiedad));
                    break;

                case "DateTime":
                    copia.EstablecerDateTime(propiedad, original.ObtenerDateTime(propiedad));
                    break;

                case "Decimal":
                    copia.EstablecerDecimal(propiedad,  original.ObtenerDecimal(propiedad));
                    break;

                case "Int16":
                    copia.EstablecerShort(propiedad,  original.ObtenerShort(propiedad));
                    break;

                case "Double":
                    copia.EstablecerDouble(propiedad,  original.ObtenerDouble(propiedad));
                    break;

                case "Int32":
                    copia.EstablecerInteger(propiedad,  original.ObtenerInteger(propiedad));
                    break;

                case "Int64":
                    copia.EstablecerLong(propiedad,  original.ObtenerLong(propiedad));
                    break;

                case "SByte":
                    copia.EstablecerSByte(propiedad,  original.ObtenerSByte(propiedad));
                    break;

                case "Single":
                    copia.EstablecerFloat(propiedad,  original.ObtenerFloat(propiedad));
                    break;

                case "String":
                    copia.EstablecerString(propiedad,  original.ObtenerString(propiedad));
                    break;

                case "UInt16":
                    copia.EstablecerUShort(propiedad,  original.ObtenerUShort(propiedad));
                    break;

                case "UInt32":
                    copia.EstablecerUInteger(propiedad,  original.ObtenerUInteger(propiedad));
                    break;

                case "UInt64":
                    copia.EstablecerULong(propiedad,  original.ObtenerULong(propiedad));
                    break;

            }
        }

    }
}
