using Binapsis.Plataforma.Estructura;
using Binapsis.Plataforma.Estructura.Helpers;
using Binapsis.Plataforma.Estructura.Impl;
using Binapsis.Plataforma.Test.Builders;
using System;
using System.Linq;

namespace Binapsis.Plataforma.Test.Serializacion.Helpers
{
    static class HelperDiagrama
    {
        static ITipo _tipo;
        static ITipo _tipox;

        static HelperDiagrama()
        {
            Tipo tipo = new Tipo();
            tipo.AgregarPropiedad(new Propiedad { Nombre = "ruta", Tipo = Primarios.String });
            BuilderTipo.Construir2(tipo);
            _tipo = tipo;

            tipo = new Tipo();
            tipo.AgregarPropiedad(new Propiedad { Nombre = "ruta", Tipo = Primarios.String });
            BuilderTipo.Construir3(tipo);
            _tipox = tipo;

            ((Propiedad)_tipo.ObtenerPropiedad("ReferenciaObjetoDatos2")).Tipo = _tipo;
            ((Propiedad)_tipox.ObtenerPropiedad("ReferenciaObjetoDatos2")).Tipo = _tipo;
            //((Propiedad)_tipo.ObtenerPropiedad("ReferenciaObjetoDatosItem2")).Tipo = _tipo;

        }

        //public static void ConstruirTipo(Tipo tipo)
        //{
        //    tipo.AgregarPropiedad(new Propiedad { Nombre = "ruta", Tipo = Primarios.String });
        //    BuilderTipo.Construir(tipo);
        //    //tipo.Nombre = "ObjetoDatos";
        //    //tipo.Alias = "objetoDatos";
        //    //tipo.Uri = "Binapsis.Plataforma.Estructura";

        //    //tipo.AgregarPropiedad(new Propiedad { Nombre = "ruta", Tipo = Primarios.String });
        //    //tipo.AgregarPropiedad(new Propiedad { Nombre = "atributoBoolean", Tipo = Primarios.Boolean });
        //    //tipo.AgregarPropiedad(new Propiedad { Nombre = "atributoByte", Tipo = Primarios.Byte });
        //    //tipo.AgregarPropiedad(new Propiedad { Nombre = "atributoChar", Tipo = Primarios.Char });
        //    //tipo.AgregarPropiedad(new Propiedad { Nombre = "atributoDateTime", Tipo = Primarios.DateTime });
        //    //tipo.AgregarPropiedad(new Propiedad { Nombre = "atributoDecimal", Tipo = Primarios.Decimal });
        //    //tipo.AgregarPropiedad(new Propiedad { Nombre = "atributoDouble", Tipo = Primarios.Double });
        //    //tipo.AgregarPropiedad(new Propiedad { Nombre = "atributoFloat", Tipo = Primarios.Float });
        //    //tipo.AgregarPropiedad(new Propiedad { Nombre = "atributoInteger", Tipo = Primarios.Integer });
        //    //tipo.AgregarPropiedad(new Propiedad { Nombre = "atributoLong", Tipo = Primarios.Long });
        //    //tipo.AgregarPropiedad(new Propiedad { Nombre = "atributoSByte", Tipo = Primarios.SByte });
        //    //tipo.AgregarPropiedad(new Propiedad { Nombre = "atributoShort", Tipo = Primarios.Short });
        //    //tipo.AgregarPropiedad(new Propiedad { Nombre = "atributoString", Tipo = Primarios.String });
        //    //tipo.AgregarPropiedad(new Propiedad { Nombre = "atributoUInteger", Tipo = Primarios.UInteger });
        //    //tipo.AgregarPropiedad(new Propiedad { Nombre = "atributoULong", Tipo = Primarios.ULong });
        //    //tipo.AgregarPropiedad(new Propiedad { Nombre = "atributoUShort", Tipo = Primarios.UShort });
            
        //}

        //public static void ConstruirTipo2(Tipo tipo)
        //{
        //    tipo.Nombre = "ObjetoDatos2";
        //    tipo.Alias = "objetoDatos2";
        //    tipo.Uri = "Binapsis.Plataforma.Estructura";

        //    tipo.AgregarPropiedad(new Propiedad { Nombre = "ruta", Tipo = Primarios.String });
        //    tipo.AgregarPropiedad(new Propiedad { Nombre = "ReferenciaObjetoDatos", Tipo = tipo, Cardinalidad = Cardinalidad.Uno, Asociacion = Asociacion.Composicion });
        //    tipo.AgregarPropiedad(new Propiedad { Nombre = "ReferenciaObjetoDatos2", Tipo = tipo, Cardinalidad = Cardinalidad.Cero_Uno, Asociacion = Asociacion.Agregacion });            
        //}

        //public static void ConstruirTipoX(Tipo tipo)
        //{
        //    ConstruirTipo(tipo);
            
        //    //tipo.AgregarPropiedad(new Propiedad { Nombre = "ReferenciaObjetoDatos", Tipo = tipo, Asociacion = Asociacion.Composicion, Cardinalidad = Cardinalidad.Uno });            
        //    //tipo.AgregarPropiedad(new Propiedad { Nombre = "ReferenciaObjetoDatosItem", Tipo = tipo, Asociacion = Asociacion.Composicion, Cardinalidad = Cardinalidad.Cero_Muchos });
        //    tipo.AgregarPropiedad(new Propiedad { Nombre = "ReferenciaObjetoDatos2", Tipo = _tipo2, Asociacion = Asociacion.Agregacion, Cardinalidad = Cardinalidad.Uno });
        //    tipo.AgregarPropiedad(new Propiedad { Nombre = "ReferenciaObjetoDatosItem2", Tipo = tipo, Asociacion = Asociacion.Agregacion, Cardinalidad = Cardinalidad.Uno });

        //}

        public static IObjetoDatos CrearObjetoDatos()
        {
            return Helper.Crear(_tipo);            
        }

        public static IObjetoDatos CrearObjetoDatosX()
        {
            return Helper.Crear(_tipox);
        }

        public static void ConstruirObjetoDatos(IObjetoDatos od)
        {
            if (od.Tipo == _tipo)
                Test.Helper.Construir(od);
            else if (od.Tipo == _tipox)
                Test.Helper.Construir(od, 2, 5);
        }

        public static void EstablecerAtributoRuta(IObjetoDatos od)
        {
            EstablecerAtributoRuta("", od);
        }

        private static void EstablecerAtributoRuta(string ruta, IObjetoDatos od)
        {
            if (od == null) return;

            if (od.Tipo.ContienePropiedad("ruta"))
                od.EstablecerString("ruta", ruta);

            foreach (IPropiedad referencia in od.Tipo.Propiedades.Where((item) => !item.Tipo.EsTipoDeDato))
                if (referencia.EsColeccion)
                    EstablecerAtributoRuta(string.Format("{0}/{1}", ruta, referencia.Nombre), od.ObtenerColeccion(referencia));
                else
                    EstablecerAtributoRuta(string.Format("{0}/{1}", ruta, referencia.Nombre), od.ObtenerObjetoDatos(referencia));
            
        }

        private static void EstablecerAtributoRuta(string ruta, IColeccion coleccion)
        {
            for (int i = 0; i < coleccion.Longitud; i++)
                EstablecerAtributoRuta(string.Format("{0}[{1}]", ruta, i), coleccion[i]);
        }

        //public static IObjetoDatos ConstruirObjetoDatos(ITipo tipo, int nivel)
        //{
        //    IObjetoDatos od = Fabrica.Instancia.Crear(tipo);
        //    EstablecerValoresPorTipoPorIndice(od);

        //    ConstruirObjetoDatosComplejo(od, nivel);

        //    return od;
        //}

        //public static IObjetoDatos ConstruirObjetoDatosComplejo(int nivel = 0)
        //{
        //    IObjetoDatos od = ConstruirObjetoDatos(ConstruirTipoComplejo(), nivel);
        //    return od;
        //}

        //public static IObjetoDatos ConstruirObjetoDatosComplejo(IObjetoDatos od, int nivel)
        //{
        //    IObjetoDatos refod = od.CrearObjetoDatos("ReferenciaObjetoDatos");
        //    refod.Establecer("ruta", string.Format("{0}/{1}", od.ObtenerString("ruta"), "ReferenciaObjetoDatos"));
        //    EstablecerValoresPorTipoPorIndice(refod);

        //    if (nivel > 0)
        //        ConstruirObjetoDatosComplejo(refod, nivel - 1);

        //    for (int i = 1; i <= 3; i++)
        //    {
        //        refod = od.CrearObjetoDatos("ReferenciaObjetoDatosItem");
        //        refod.Establecer("ruta", string.Format("{0}/{1}[{2}]", od.ObtenerString("ruta"), "ReferenciaObjetoDatosItem", i - 1));
        //        EstablecerValoresPorTipoPorIndice(refod);
        //        if (nivel > 0)
        //            ConstruirObjetoDatosComplejo(refod, nivel - 1);
        //    }

        //    return od;
        //}

        //public static void EstablecerValoresPorIndice(IObjetoDatos od)
        //{
        //    bool valorBoolean = true;
        //    byte valorByte = byte.MaxValue;
        //    char valorChar = char.MaxValue;
        //    DateTime valorDateTime = DateTime.MaxValue;
        //    decimal valorDecimal = decimal.MaxValue;
        //    double valorDouble = double.MaxValue;
        //    float valorFloat = float.MaxValue;
        //    int valorInteger = int.MaxValue;
        //    long valorLong = long.MaxValue;
        //    sbyte valorSByte = sbyte.MaxValue;
        //    short valorShort = short.MaxValue;
        //    string valorString = "abcdefghijklmnoprstuvwxyz";
        //    uint valorUInteger = uint.MaxValue;
        //    ulong valorULong = ulong.MaxValue;
        //    ushort valorUShort = ushort.MaxValue;

        //    od.Establecer(0, valorBoolean);
        //    od.Establecer(1, valorByte);
        //    od.Establecer(2, valorChar);
        //    od.Establecer(3, valorDateTime);
        //    od.Establecer(4, valorDecimal);
        //    od.Establecer(5, valorDouble);
        //    od.Establecer(6, valorFloat);
        //    od.Establecer(7, valorInteger);
        //    od.Establecer(8, valorLong);
        //    od.Establecer(9, valorSByte);
        //    od.Establecer(10, valorShort);
        //    od.Establecer(11, valorString);
        //    od.Establecer(12, valorUInteger);
        //    od.Establecer(13, valorULong);
        //    od.Establecer(14, valorUShort);
        //}

        //public static void EstablecerValoresPorNombre(IObjetoDatos od)
        //{
        //    bool valorBoolean = true;
        //    byte valorByte = byte.MaxValue;
        //    char valorChar = char.MaxValue;
        //    DateTime valorDateTime = DateTime.MaxValue;
        //    decimal valorDecimal = decimal.MaxValue;
        //    double valorDouble = double.MaxValue;
        //    float valorFloat = float.MaxValue;
        //    int valorInteger = int.MaxValue;
        //    long valorLong = long.MaxValue;
        //    sbyte valorSByte = sbyte.MaxValue;
        //    short valorShort = short.MaxValue;
        //    string valorString = "abcdefghijklmnoprstuvwxyz";
        //    uint valorUInteger = uint.MaxValue;
        //    ulong valorULong = ulong.MaxValue;
        //    ushort valorUShort = ushort.MaxValue;

        //    od.Establecer("atributoBoolean", valorBoolean);
        //    od.Establecer("atributoByte", valorByte);
        //    od.Establecer("atributoChar", valorChar);
        //    od.Establecer("atributoDateTime", valorDateTime);
        //    od.Establecer("atributoDecimal", valorDecimal);
        //    od.Establecer("atributoDouble", valorDouble);
        //    od.Establecer("atributoFloat", valorFloat);
        //    od.Establecer("atributoInteger", valorInteger);
        //    od.Establecer("atributoLong", valorLong);
        //    od.Establecer("atributoSByte", valorSByte);
        //    od.Establecer("atributoShort", valorShort);
        //    od.Establecer("atributoString", valorString);
        //    od.Establecer("atributoUInteger", valorUInteger);
        //    od.Establecer("atributoULong", valorULong);
        //    od.Establecer("atributoUShort", valorUShort);
        //}

        //public static void EstablecerValoresPorTipoPorIndice(IObjetoDatos od)
        //{
        //    bool valorBoolean = true;
        //    byte valorByte = byte.MaxValue;
        //    char valorChar = char.MaxValue;
        //    DateTime valorDateTime = DateTime.MaxValue;
        //    decimal valorDecimal = decimal.MaxValue;
        //    double valorDouble = double.MaxValue;
        //    float valorFloat = float.MaxValue;
        //    int valorInteger = int.MaxValue;
        //    long valorLong = long.MaxValue;
        //    sbyte valorSByte = sbyte.MaxValue;
        //    short valorShort = short.MaxValue;
        //    string valorString = "abcdefghijklmnopqrstuvwxyz";
        //    uint valorUInteger = uint.MaxValue;
        //    ulong valorULong = ulong.MaxValue;
        //    ushort valorUShort = ushort.MaxValue;

        //    od.EstablecerBoolean(0, valorBoolean);
        //    od.EstablecerByte(1, valorByte);
        //    od.EstablecerChar(2, valorChar);
        //    od.EstablecerDateTime(3, valorDateTime);
        //    od.EstablecerDecimal(4, valorDecimal);
        //    od.EstablecerDouble(5, valorDouble);
        //    od.EstablecerFloat(6, valorFloat);
        //    od.EstablecerInteger(7, valorInteger);
        //    od.EstablecerLong(8, valorLong);
        //    od.EstablecerSByte(9, valorSByte);
        //    od.EstablecerShort(10, valorShort);
        //    od.EstablecerString(11, valorString);
        //    od.EstablecerUInteger(12, valorUInteger);
        //    od.EstablecerULong(13, valorULong);
        //    od.EstablecerUShort(14, valorUShort);

        //}

        //public static void EstablecerValoresPorTipoPorNombre(IObjetoDatos od)
        //{
        //    bool valorBoolean = true;
        //    byte valorByte = byte.MaxValue;
        //    char valorChar = char.MaxValue;
        //    DateTime valorDateTime = DateTime.MaxValue;
        //    decimal valorDecimal = decimal.MaxValue;
        //    double valorDouble = double.MaxValue;
        //    float valorFloat = float.MaxValue;
        //    int valorInteger = int.MaxValue;
        //    long valorLong = long.MaxValue;
        //    sbyte valorSByte = sbyte.MaxValue;
        //    short valorShort = short.MaxValue;
        //    string valorString = "abcdefghijklmnoprstuvwxyz";
        //    uint valorUInteger = uint.MaxValue;
        //    ulong valorULong = ulong.MaxValue;
        //    ushort valorUShort = ushort.MaxValue;

        //    od.EstablecerBoolean("atributoBoolean", valorBoolean);
        //    od.EstablecerByte("atributoByte", valorByte);
        //    od.EstablecerChar("atributoChar", valorChar);
        //    od.EstablecerDateTime("atributoDateTime", valorDateTime);
        //    od.EstablecerDecimal("atributoDecimal", valorDecimal);
        //    od.EstablecerDouble("atributoDouble", valorDouble);
        //    od.EstablecerFloat("atributoFloat", valorFloat);
        //    od.EstablecerInteger("atributoInteger", valorInteger);
        //    od.EstablecerLong("atributoLong", valorLong);
        //    od.EstablecerSByte("atributoSByte", valorSByte);
        //    od.EstablecerShort("atributoShort", valorShort);
        //    od.EstablecerString("atributoString", valorString);
        //    od.EstablecerUInteger("atributoUInteger", valorUInteger);
        //    od.EstablecerULong("atributoULong", valorULong);
        //    od.EstablecerUShort("atributoUShort", valorUShort);

        //}

    }
}
