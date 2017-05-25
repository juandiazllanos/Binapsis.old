using Binapsis.Plataforma.Configuracion;
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
        static Tipo _tipo;
        static Tipo _tipox;

        static HelperDiagrama()
        {
            Tipo tipo = FabricaConfiguracion.Instancia.CrearTipo();
            tipo.CrearPropiedad("ruta", Types.Instancia.Obtener(typeof(String)));
            BuilderTipo.Construir2(tipo);
            _tipo = tipo;

            tipo = FabricaConfiguracion.Instancia.CrearTipo();
            tipo.CrearPropiedad("ruta", Types.Instancia.Obtener(typeof(string)));
            BuilderTipo.Construir3(tipo);
            _tipox = tipo;

            _tipo.ObtenerPropiedad("ReferenciaObjetoDatos2").TipoAsociado = _tipo;
            _tipox.ObtenerPropiedad("ReferenciaObjetoDatos2").TipoAsociado = _tipo;       

        }
        
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
        
    }
}
