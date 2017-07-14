using Binapsis.Plataforma.Cambios;
using Binapsis.Plataforma.Estructura;
using Binapsis.Plataforma.Datos.Mapeo;
using Binapsis.Plataforma.Datos.Builder;
using System.Collections;

namespace Binapsis.Plataforma.Datos.Impl
{
    public class DAS : IDAS
    {
        public DAS(IConfiguracion configuracion, IContexto contexto)
        {
            Configuracion = configuracion;
            Contexto = contexto;

            MapeoCatalogo = new MapeoCatalogo();
            MapeoCatalogo.Configuracion = configuracion;
        }

        public void AplicarCambios(IDiagramaDatos dd)
        {
            try
            {
                // iniciar transaccion
                Contexto.IniciarTransaccion();
                // ejecutar comando
                AplicarCambios(dd.ObjetoDatos, dd.ResumenCambios);
                // confirmar transaccion
                Contexto.TerminarTransaccion();
            }
            catch
            {
                // descartar transaccion
                Contexto.DeshacerTransaccion();
                throw;
            }
        }

        public void AplicarCambios(IList datos)
        {
            try
            {
                // iniciar transaccion
                Contexto.IniciarTransaccion();
                // ejecutar comando
                foreach(IDiagramaDatos dd in datos)
                    AplicarCambios(dd.ObjetoDatos, dd.ResumenCambios);
                // confirmar transaccion
                Contexto.TerminarTransaccion();
            }
            catch
            {
                // descartar transaccion
                Contexto.DeshacerTransaccion();
                throw;
            }
        }

        public void AplicarCambios(IObjetoDatos od)
        {
            
        }
            
        private void AplicarCambios(IObjetoDatos od, IResumenCambios resumen)
        {
            // construir cambios
            Operacion.Cambios cambios = new Operacion.Cambios();
            BuilderCambios builder = new BuilderCambios(cambios);

            builder.Contexto = Contexto;
            builder.MapeoCatalogo = MapeoCatalogo;
            builder.ObjetoDatos = od;
            builder.ResumenCambios = resumen;

            builder.Construir();

            // construir operacion
            Operacion.AplicarCambios aplicarCambios = new Operacion.AplicarCambios();

            aplicarCambios.Contexto = Contexto;
            aplicarCambios.Cambios = cambios;
            aplicarCambios.ObjetoDatos = od;
            
            // ejecutar operacion
            aplicarCambios.Ejecutar();                         
        }
        
        public IConfiguracion Configuracion
        {
            get;
        }

        public IContexto Contexto
        {
            get;
        }

        private MapeoCatalogo MapeoCatalogo
        {
            get;
        }
                
    }
}
