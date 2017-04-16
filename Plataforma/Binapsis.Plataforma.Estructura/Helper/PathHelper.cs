using System;
using System.Linq;
using Binapsis.Plataforma.Estructura.Impl;

namespace Binapsis.Plataforma.Estructura.Helpers
{
    static class PathHelper
    {
        public static bool ComprobarRuta(ref string ruta)
        {
            return (ruta.IndexOfAny(new char[] { '/', '.', '[' }) > 0);
        }

        private static void Resolver(IObjetoDatos od, string ruta, out IObjetoDatos referencia, out IPropiedad propiedad)
        {
            string[] pasos = ruta.Split('/');
            int longitud = pasos.GetLength(0);
            int i = 0;

            // referencia inicial
            referencia = od;

            // resolver referencia (se resuelve la primera referencia[i])
            do
            {
                referencia = ResolverReferencia(referencia, pasos[i]);
                if (referencia == null) break;
                i++;
            }
            while (i < (longitud - 1));

            // resolver propiedad
            if (referencia != null && longitud > 1)
                propiedad = referencia.Tipo.ObtenerPropiedad(pasos[longitud - 1]);
            else
                propiedad = null;
        }

        private static IObjetoDatos ResolverReferencia(IObjetoDatos od, string ruta)
        {
            IObjetoDatos referencia = default(IObjetoDatos);
            IPropiedad propiedad = null;
            string[] pasos = ruta.Split(new char[] { '.', '[', ']' });
            int indice;

            propiedad = od.Tipo.ObtenerPropiedad(pasos[0]);

            if (pasos.Length == 1)
            {
                referencia = od.ObtenerObjetoDatos(propiedad);
            }
            else if (int.TryParse(pasos[1], out indice))
            {
                referencia = od.ObtenerColeccion(propiedad)[indice];
            }
            else
            {
                referencia = ResolverReferencia(od, propiedad, pasos[1]); 
            }
            
            return referencia;
        }

        private static IObjetoDatos ResolverReferencia(IObjetoDatos od, IPropiedad propiedad, string parametro)
        {
            IObjetoDatos referencia = null;
            string[] pasos = parametro.Split(new char[] { '=' });

            if (pasos.GetLength(0) > 1)
            {
                var filtro = from item in od.ObtenerColeccion(propiedad)
                             where referencia.Obtener(pasos[0]).ToString().Equals(pasos[1])
                             select item;

                referencia = filtro.FirstOrDefault();
            }            

            return referencia;
        }


        internal static IObjetoDatos CrearObjetoDatos(IObjetoDatos od, string ruta)
        {
            IObjetoDatos referencia;
            IPropiedad propiedad;

            Resolver(od, ruta, out referencia, out propiedad);

            if (referencia != null && propiedad != null)
            {
                return referencia.CrearObjetoDatos(propiedad);
            }
            else
            {
                return null;
            }
        }


        internal static void RemoverObjetoDatos(IObjetoDatos od, string ruta, IObjetoDatos item)
        {
            IObjetoDatos referencia;
            IPropiedad propiedad;

            Resolver(od, ruta, out referencia, out propiedad);

            if (referencia != null && propiedad != null)
            {
                referencia.RemoverObjetoDatos(propiedad, item);
            }            
        }

        public static bool Establecido(IObjetoDatos od, string ruta)
        {
            IObjetoDatos referencia;
            IPropiedad propiedad;
            bool valor = default(bool);

            Resolver(od, ruta, out referencia, out propiedad);

            if (referencia != null && propiedad != null)
            {
                valor = referencia.Establecido(propiedad);
            }

            return valor;
        }

        public static void Establecer(IObjetoDatos od, string ruta, object valor)
        {
            IObjetoDatos referencia;
            IPropiedad propiedad;

            Resolver(od, ruta, out referencia, out propiedad);

            if (referencia != null && propiedad != null)
            {
                referencia.Establecer(propiedad, valor);
            }
        }

        public static void EstablecerBoolean(IObjetoDatos od, string ruta, bool valor)
        {
            IObjetoDatos referencia;
            IPropiedad propiedad;

            Resolver(od, ruta, out referencia, out propiedad);

            if (referencia != null && propiedad != null)
            {
                referencia.EstablecerBoolean(propiedad, valor);
            }
        }
        
        public static void EstablecerByte(IObjetoDatos od, string ruta, byte valor)
        {
            IObjetoDatos referencia;
            IPropiedad propiedad;

            Resolver(od, ruta, out referencia, out propiedad);

            if (referencia != null && propiedad != null)
            {
                referencia.EstablecerByte(propiedad, valor);
            }
        }
        
        public static void EstablecerChar(IObjetoDatos od, string ruta, char valor)
        {
            IObjetoDatos referencia;
            IPropiedad propiedad;

            Resolver(od, ruta, out referencia, out propiedad);

            if (referencia != null && propiedad != null)
            {
                referencia.EstablecerChar(propiedad, valor);
            }
        }

        public static void EstablecerDateTime(IObjetoDatos od, string ruta, DateTime valor)
        {
            IObjetoDatos referencia;
            IPropiedad propiedad;

            Resolver(od, ruta, out referencia, out propiedad);

            if (referencia != null && propiedad != null)
            {
                referencia.EstablecerDateTime(propiedad, valor);
            }
        }

        public static void EstablecerDecimal(IObjetoDatos od, string ruta, decimal valor)
        {
            IObjetoDatos referencia;
            IPropiedad propiedad;

            Resolver(od, ruta, out referencia, out propiedad);

            if (referencia != null && propiedad != null)
            {
                referencia.EstablecerDecimal(propiedad, valor);
            }
        }

        public static void EstablecerDouble(IObjetoDatos od, string ruta, double valor)
        {
            IObjetoDatos referencia;
            IPropiedad propiedad;

            Resolver(od, ruta, out referencia, out propiedad);

            if (referencia != null && propiedad != null)
            {
                referencia.EstablecerDouble(propiedad, valor);
            }
        }

        public static void EstablecerFloat(IObjetoDatos od, string ruta, float valor)
        {
            IObjetoDatos referencia;
            IPropiedad propiedad;

            Resolver(od, ruta, out referencia, out propiedad);

            if (referencia != null && propiedad != null)
            {
                referencia.EstablecerFloat(propiedad, valor);
            }
        }

        public static void EstablecerInteger(IObjetoDatos od, string ruta, int valor)
        {
            IObjetoDatos referencia;
            IPropiedad propiedad;

            Resolver(od, ruta, out referencia, out propiedad);

            if (referencia != null && propiedad != null)
            {
                referencia.EstablecerInteger(propiedad, valor);
            }
        }

        public static void EstablecerLong(IObjetoDatos od, string ruta, long valor)
        {
            IObjetoDatos referencia;
            IPropiedad propiedad;

            Resolver(od, ruta, out referencia, out propiedad);

            if (referencia != null && propiedad != null)
            {
                referencia.EstablecerLong(propiedad, valor);
            }
        }

        public static void EstablecerObject(IObjetoDatos od, string ruta, object valor)
        {
            IObjetoDatos referencia;
            IPropiedad propiedad;

            Resolver(od, ruta, out referencia, out propiedad);

            if (referencia != null && propiedad != null)
            {
                referencia.EstablecerObject(propiedad, valor);
            }
        }

        public static void EstablecerObjetoDatos(IObjetoDatos od, string ruta, IObjetoDatos valor)
        {
            IObjetoDatos referencia;
            IPropiedad propiedad;

            Resolver(od, ruta, out referencia, out propiedad);

            if (referencia != null && propiedad != null)
            {
                referencia.EstablecerObjetoDatos(propiedad, valor);
            }
        }

        public static void EstablecerObjetoDatos(IObjetoDatos od, string ruta, int indice, IObjetoDatos item)
        {

        }

        public static void EstablecerSByte(IObjetoDatos od, string ruta, sbyte valor)
        {
            IObjetoDatos referencia;
            IPropiedad propiedad;

            Resolver(od, ruta, out referencia, out propiedad);

            if (referencia != null && propiedad != null)
            {
                referencia.EstablecerSByte(propiedad, valor);
            }
        }

        public static void EstablecerShort(IObjetoDatos od, string ruta, short valor)
        {
            IObjetoDatos referencia;
            IPropiedad propiedad;

            Resolver(od, ruta, out referencia, out propiedad);

            if (referencia != null && propiedad != null)
            {
                referencia.EstablecerShort(propiedad, valor);
            }
        }

        public static void EstablecerString(IObjetoDatos od, string ruta, string valor)
        {
            IObjetoDatos referencia;
            IPropiedad propiedad;

            Resolver(od, ruta, out referencia, out propiedad);

            if (referencia != null && propiedad != null)
            {
                referencia.EstablecerString(propiedad, valor);
            }
        }

        public static void EstablecerUInteger(IObjetoDatos od, string ruta, uint valor)
        {
            IObjetoDatos referencia;
            IPropiedad propiedad;

            Resolver(od, ruta, out referencia, out propiedad);

            if (referencia != null && propiedad != null)
            {
                referencia.EstablecerUInteger(propiedad, valor);
            }
        }

        public static void EstablecerULong(IObjetoDatos od, string ruta, ulong valor)
        {
            IObjetoDatos referencia;
            IPropiedad propiedad;

            Resolver(od, ruta, out referencia, out propiedad);

            if (referencia != null && propiedad != null)
            {
                referencia.EstablecerULong(propiedad, valor);
            }
        }

        public static void EstablecerUShort(IObjetoDatos od, string ruta, ushort valor)
        {
            IObjetoDatos referencia;
            IPropiedad propiedad;

            Resolver(od, ruta, out referencia, out propiedad);

            if (referencia != null && propiedad != null)
            {
                referencia.EstablecerUShort(propiedad, valor);
            }
        }

        public static object Obtener(IObjetoDatos od, string ruta)
        {
            IObjetoDatos referencia;
            IPropiedad propiedad;
            object valor = default(object);

            Resolver(od, ruta, out referencia, out propiedad);

            if (referencia != null && propiedad != null)
            {
                valor =  referencia.Obtener(propiedad);
            }

            return valor;
        }

        public static bool ObtenerBoolean(IObjetoDatos od, string ruta)
        {
            IObjetoDatos referencia;
            IPropiedad propiedad;
            bool valor = default(bool);

            Resolver(od, ruta, out referencia, out propiedad);

            if (referencia != null && propiedad != null)
            {
                valor = referencia.ObtenerBoolean(propiedad);
            }

            return valor;
        }

        public static byte ObtenerByte(IObjetoDatos od, string ruta)
        {
            IObjetoDatos referencia;
            IPropiedad propiedad;
            byte valor = default(byte);

            Resolver(od, ruta, out referencia, out propiedad);

            if (referencia != null && propiedad != null)
            {
                valor = referencia.ObtenerByte(propiedad);
            }

            return valor;
        }

        public static char ObtenerChar(IObjetoDatos od, string ruta)
        {
            IObjetoDatos referencia;
            IPropiedad propiedad;
            char valor = default(char);

            Resolver(od, ruta, out referencia, out propiedad);

            if (referencia != null && propiedad != null)
            {
                valor = referencia.ObtenerChar(propiedad);
            }

            return valor;
        }

        public static IColeccion ObtenerColeccion(IObjetoDatos od, string ruta)
        {
            IObjetoDatos referencia;
            IPropiedad propiedad;
            IColeccion valor = null;

            Resolver(od, ruta, out referencia, out propiedad);

            if (referencia != null && propiedad != null)
            {
                valor = referencia.ObtenerColeccion(propiedad);
            }

            return valor;
        }

        public static DateTime ObtenerDateTime(IObjetoDatos od, string ruta)
        {
            IObjetoDatos referencia;
            IPropiedad propiedad;
            DateTime valor = default(DateTime);

            Resolver(od, ruta, out referencia, out propiedad);

            if (referencia != null && propiedad != null)
            {
                valor = referencia.ObtenerDateTime(propiedad);
            }

            return valor;
        }

        public static decimal ObtenerDecimal(IObjetoDatos od, string ruta)
        {
            IObjetoDatos referencia;
            IPropiedad propiedad;
            decimal valor = default(decimal);

            Resolver(od, ruta, out referencia, out propiedad);

            if (referencia != null && propiedad != null)
            {
                valor = referencia.ObtenerDecimal(propiedad);
            }

            return valor;
        }

        public static double ObtenerDouble(IObjetoDatos od, string ruta)
        {
            IObjetoDatos referencia;
            IPropiedad propiedad;
            double valor = default(double);

            Resolver(od, ruta, out referencia, out propiedad);

            if (referencia != null && propiedad != null)
            {
                valor = referencia.ObtenerDouble(propiedad);
            }

            return valor;
        }

        public static float ObtenerFloat(IObjetoDatos od, string ruta)
        {
            IObjetoDatos referencia;
            IPropiedad propiedad;
            float valor = default(float);

            Resolver(od, ruta, out referencia, out propiedad);

            if (referencia != null && propiedad != null)
            {
                valor = referencia.ObtenerFloat(propiedad);
            }

            return valor;
        }

        public static int ObtenerInteger(IObjetoDatos od, string ruta)
        {
            IObjetoDatos referencia;
            IPropiedad propiedad;
            int valor = default(int);

            Resolver(od, ruta, out referencia, out propiedad);

            if (referencia != null && propiedad != null)
            {
                valor = referencia.ObtenerInteger(propiedad);
            }

            return valor;
        }

        public static long ObtenerLong(IObjetoDatos od, string ruta)
        {
            IObjetoDatos referencia;
            IPropiedad propiedad;
            long valor = default(long);

            Resolver(od, ruta, out referencia, out propiedad);

            if (referencia != null && propiedad != null)
            {
                valor = referencia.ObtenerLong(propiedad);
            }

            return valor;
        }

        public static object ObtenerObject(IObjetoDatos od, string ruta)
        {
            IObjetoDatos referencia;
            IPropiedad propiedad;
            object valor = default(object);

            Resolver(od, ruta, out referencia, out propiedad);

            if (referencia != null && propiedad != null)
            {
                valor = referencia.ObtenerObject(propiedad);
            }

            return valor;
        }

        public static IObjetoDatos ObtenerObjetoDatos(IObjetoDatos od, string ruta)
        {
            IObjetoDatos referencia;
            IPropiedad propiedad;
            //ObjetoDatos valor = default(ObjetoDatos);

            Resolver(od, ruta, out referencia, out propiedad);

            if (referencia != null && propiedad != null)
            {
                referencia = referencia.ObtenerObjetoDatos(propiedad);
            }

            return referencia;
        }

        public static IObjetoDatos ObtenerObjetoDatos(IObjetoDatos od, string ruta, int indice)
        {
            return null;
        }

        public static sbyte ObtenerSByte(IObjetoDatos od, string ruta)
        {
            IObjetoDatos referencia;
            IPropiedad propiedad;
            sbyte valor = default(sbyte);

            Resolver(od, ruta, out referencia, out propiedad);

            if (referencia != null && propiedad != null)
            {
                valor = referencia.ObtenerSByte(propiedad);
            }

            return valor;
        }

        public static short ObtenerShort(IObjetoDatos od, string ruta)
        {
            IObjetoDatos referencia;
            IPropiedad propiedad;
            short valor = default(short);

            Resolver(od, ruta, out referencia, out propiedad);

            if (referencia != null && propiedad != null)
            {
                valor = referencia.ObtenerShort(propiedad);
            }

            return valor;
        }

        public static string ObtenerString(IObjetoDatos od, string ruta)
        {
            IObjetoDatos referencia;
            IPropiedad propiedad;
            
            Resolver(od, ruta, out referencia, out propiedad);

            return (referencia != null && propiedad != null ? referencia.ObtenerString(propiedad) : default(string));
        }

        public static uint ObtenerUInteger(IObjetoDatos od, string ruta)
        {
            IObjetoDatos referencia;
            IPropiedad propiedad;
            uint valor = default(uint);

            Resolver(od, ruta, out referencia, out propiedad);

            if (referencia != null && propiedad != null)
            {
                valor = referencia.ObtenerUInteger(propiedad);
            }

            return valor;
        }

        public static ulong ObtenerULong(IObjetoDatos od, string ruta)
        {
            IObjetoDatos referencia;
            IPropiedad propiedad;
            ulong valor = default(ulong);

            Resolver(od, ruta, out referencia, out propiedad);

            if (referencia != null && propiedad != null)
            {
                valor = referencia.ObtenerULong(propiedad);
            }

            return valor;
        }

        public static ushort ObtenerUShort(IObjetoDatos od, string ruta)
        {
            IObjetoDatos referencia;
            IPropiedad propiedad;
            ushort valor = default(ushort);

            Resolver(od, ruta, out referencia, out propiedad);

            if (referencia != null && propiedad != null)
            {
                valor = referencia.ObtenerUShort(propiedad);
            }

            return valor;
        }

    }
}
