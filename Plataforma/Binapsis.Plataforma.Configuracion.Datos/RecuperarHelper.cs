using Binapsis.Plataforma.Datos;
using Binapsis.Plataforma.Estructura;
using System;

namespace Binapsis.Plataforma.Configuracion.Datos
{
    public static class RecuperarHelper
    {
        public static Recuperar CrearComando(IContexto contexto, Type type)
        {
            ITipo tipo = Types.Instancia.Obtener(type);
            if (tipo == null) return null;
            return new Recuperar(contexto, tipo);
        }

        public static Recuperar CrearComando(IContexto contexto, Type type, IPropiedad[] propiedades)
        {
            ITipo tipo = Types.Instancia.Obtener(type);
            return CrearComando(contexto, tipo, propiedades);
        }

        public static Recuperar CrearComando(IContexto contexto, ITipo tipo, IPropiedad[] propiedades)
        {
            if (tipo == null) return null;
            return new Recuperar(contexto, tipo, propiedades);
        }

        public static Recuperar CrearComando(IContexto contexto, string comandoNombre)
        {
            return new Recuperar(contexto, comandoNombre);
        }

        public static Recuperar CrearComando(IContexto contexto, Comando comando)
        {
            return new Recuperar(contexto, comando);
        }
    }
}
