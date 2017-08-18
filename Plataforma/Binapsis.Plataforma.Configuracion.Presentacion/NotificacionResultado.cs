using System;
using System.Collections.Generic;
using System.Text;

namespace Binapsis.Plataforma.Configuracion.Presentacion
{
    class NotificacionResultado : Notificacion
    {
        public NotificacionResultado(Consola consola, Accion accion, IResultado resultado) 
            : base(consola, accion)
        {
            Resultado = resultado;
        }

        public override void Terminar(Operacion operacion)
        {
            base.Terminar(operacion);

            if (operacion.Resultado == Actividad.RESULTADO_OK)
                Resultado.OK();
            else if (operacion.Resultado == Actividad.RESULTADO_CANCEL)
                Resultado.Cancelar();
        }

        private IResultado Resultado
        {
            get;
        }
    }
}
