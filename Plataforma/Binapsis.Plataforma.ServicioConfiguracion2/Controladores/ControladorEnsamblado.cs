using Binapsis.Plataforma.Configuracion;
using Binapsis.Plataforma.Configuracion.Serializacion;
using Binapsis.Plataforma.Configuracion.Sql;
using Binapsis.Plataforma.Configuracion.Sql.Helper;
using Binapsis.Plataforma.Estructura.Impl;
using System;

namespace Binapsis.Plataforma.ServicioConfiguracion.Controladores
{
    public class ControladorEnsamblado : ControladorBase
    {
        public override void Establecer(string valor)
        {
            IDeserializador helper = new DeserializacionXml<Ensamblado>();
            IHelper sql = new HelperEnsamblado(CadenaConexion);
            ObjetoBase instancia = null;
            
            helper.Deserializar(valor);
            instancia = helper.Objeto;            

            if (sql.Existe(instancia))
                sql.Actualizar(instancia);
            else
                sql.Insertar(instancia);
            
        }

        public override string Obtener(string consulta)
        {
            throw new NotImplementedException();
        }
    }
}
