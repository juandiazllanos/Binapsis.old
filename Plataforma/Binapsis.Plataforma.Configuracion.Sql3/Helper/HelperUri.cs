using System;

namespace Binapsis.Plataforma.Configuracion.Sql.Helper
{
    public class HelperUri : HelperBase<Uri>
    {
        public HelperUri(string cadenaConexion) 
            : base(cadenaConexion)
        {
        }

        public override void Actualizar(Uri obj)
        {
            throw new NotImplementedException();
        }

        public override void Eliminar(Uri obj)
        {
            throw new NotImplementedException();
        }

        public override bool Existe(string clave)
        {
            throw new NotImplementedException();
        }

        public override bool Existe(Uri obj)
        {
            throw new NotImplementedException();
        }

        public override void Insertar(Uri obj)
        {
            throw new NotImplementedException();
        }

        public override void Recuperar(Uri obj, string clave)
        {
            throw new NotImplementedException();
        }
    }
}
