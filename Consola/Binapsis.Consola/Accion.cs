using Binapsis.Consola.Definicion;
using Binapsis.Consola.Estructura;
using Binapsis.Consola.Helpers;
using Binapsis.Procesos.Trabajos;
using System;

namespace Binapsis.Consola
{
    public class Accion 
    {
        public Accion(Pagina pagina, AccionInfo accionInfo)             
        {
            AccionInfo = accionInfo;
            Pagina = pagina;
        }

        public void Ejecutar()
        {
            try
            {
                if (AccionInfo.TrabajoInfo != null)
                    Ejecutar(AccionInfo.TrabajoInfo);
                else if (AccionInfo.ControladorInfo != null)
                    Ejecutar(AccionInfo.ControladorInfo);
            }
            catch(Exception error)
            {

            }

            // actualizar pagina
            try
            {
                Pagina.Controller.Mostrar();
            }
            catch (Exception error)
            {

            }
        }

        private void Ejecutar(TrabajoInfo trabajoInfo)
        {
            Modelo modelo = Pagina.CrearModelo();
            Trabajo trabajo = TypeInfoHelper.Crear(trabajoInfo.TypeInfo, trabajoInfo) as Trabajo;
            Type type = TypeInfoHelper.ObtenerType(modelo.ModeloInfo);

            BuilderTrabajo builder = new BuilderTrabajo(trabajo);
            builder.Construir();
                        
            trabajo.Parametros.Establecer("modelo", modelo.Objeto);
            trabajo.Parametros.Establecer("modeloInfo", modelo.ModeloInfo);
            trabajo.Parametros.Establecer("type", type);
            
            trabajo.Ejecutar();
        }

        private void Ejecutar(ControladorInfo controladorInfo)
        {

        }

        #region Propiedades
        public AccionInfo AccionInfo
        {
            get;
        }

        public Modelo Modelo
        {
            get;
            set;
        }

        public Pagina Pagina
        {
            get;
        }
        #endregion
    }
}
