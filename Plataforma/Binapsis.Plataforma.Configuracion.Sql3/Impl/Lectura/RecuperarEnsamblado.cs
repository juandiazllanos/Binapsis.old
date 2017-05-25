using System;
using Binapsis.Plataforma.Estructura;
using Binapsis.Plataforma.Configuracion.Sql.Comandos;

namespace Binapsis.Plataforma.Configuracion.Sql.Impl.Lectura
{
    internal class RecuperarEnsamblado : ComandoLectura
    {
        Ensamblado _ensamblado;

        private RecuperarEnsamblado()
        {
            ComandoSql = "Select top 1 Nombre From Ensamblado";            
        }

        public RecuperarEnsamblado(Ensamblado ensamblado, string nombre)
            : this()
        {
            ComandoSql += string.Format(" Where Nombre='{0}'", nombre);
            _ensamblado = ensamblado;
        }

        protected override IObjetoDatos Leer()
        {
            _ensamblado.Nombre = Convert.ToString(Obtener(0));
            return _ensamblado;
        }
    }
}
