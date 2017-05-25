using Binapsis.Plataforma.Configuracion.Sql.SqlBuilder;
using System;

namespace Binapsis.Plataforma.Configuracion.Sql.Helper
{
    public class HelperUri : HelperBase<Uri>
    {
        public HelperUri(string cadenaConexion) 
            : base(cadenaConexion)
        {
        }

        public override void Actualizar(string clave, Uri obj)
        {
            Escribir(new SqlBuilderActualizarUri(clave, obj));
        }

        public override void Eliminar(Uri obj)
        {
            Escribir(new SqlBuilderEliminarUri(obj));
        }

        public override bool Existe(string clave)
        {
            return Existe(new SqlBuilderSeleccionarUri(clave));
        }

        public override bool Existe(Uri obj)
        {
            return Existe(obj.Nombre);
        }

        public override void Insertar(Uri obj)
        {
            Escribir(new SqlBuilderInsertarUri(obj));
        }

        public override Uri Recuperar(string clave)
        {
            return new HelperRecuperacion(CadenaConexion).RecuperarUri(clave);
        }
    }
}
