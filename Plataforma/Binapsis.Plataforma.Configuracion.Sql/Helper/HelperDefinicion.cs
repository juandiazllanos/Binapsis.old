using System;
using System.Collections.Generic;
using System.Text;

namespace Binapsis.Plataforma.Configuracion.Sql.Helper
{
    public class HelperDefinicion : HelperBase<Definicion>
    {
        public HelperDefinicion(string cadenaConexion) : base(cadenaConexion)
        {
        }

        public override void Actualizar(string clave, Definicion obj)
        {            
        }

        public override void Eliminar(Definicion obj)
        {            
        }

        public override bool Existe(Definicion obj)
        {
            return true;
        }

        public override bool Existe(string clave)
        {
            return true;
        }

        public override void Insertar(Definicion obj)
        {            
        }

        public override Definicion Recuperar(string clave)
        {
            string[] claves = clave.Split('/');

            if (claves.Length == 2)
                return new HelperRecuperacion(CadenaConexion).RecuperarDefinicion(claves[0], claves[1]);
            else
                return new HelperRecuperacion(CadenaConexion).RecuperarDefinicion(""); ;            
        }
        
    }
}
