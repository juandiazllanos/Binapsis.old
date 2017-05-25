using Binapsis.Plataforma.ServicioConfiguracion.Controladores;
using System;
using System.Configuration;

namespace Binapsis.Plataforma.ServicioConfiguracion
{
    public class Configuracion : IConfiguracion
    {
        public void Establecer(string ruta, string valor)
        {
            IControlador controlador = null;
            
            switch(ruta)
            {
                case "Ensamblado":
                    controlador = new ControladorEnsamblado();
                    break;

                case "Uri":
                    break;

                case "Tipo":
                    break;
            }

            if (controlador == null) return;

            controlador.CadenaConexion = ConfigurationManager.AppSettings["cadenaConexion"];
            controlador.Establecer(valor);            
                
        }

        public string Obtener(string ruta)
        {
            throw new NotImplementedException();
        }
        
    }
}
