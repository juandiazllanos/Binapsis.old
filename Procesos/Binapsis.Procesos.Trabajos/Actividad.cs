using Binapsis.Consola.Definicion;
using Binapsis.Procesos.Orquestacion;
using System;

namespace Binapsis.Procesos.Trabajos
{
    public abstract class Actividad : Comando, IActividad
    {
        protected const string RESULTADO_OK = "OK";
        protected const string RESULTADO_CANCEL = "CANCEL";
        protected const string RESULTADO_ERROR = "ERROR";

        public Actividad(ActividadInfo actividadInfo)
        {
            ActividadInfo = actividadInfo;
        }

        #region Metodos
        public override sealed void Ejecutar()
        {
            try
            {
                Iniciar();
                EjecutarActividad();                
            }
            catch(Exception error)
            {
                ControlarError(error);
            }
            finally
            {
                Terminar();
            }
        }

        public abstract void EjecutarActividad();
        
        protected virtual void Iniciar()
        {
            //Resultado = RESULTADO_OK;
        }

        protected virtual void Terminar()
        {
            if (string.IsNullOrEmpty(Resultado))
                Resultado = RESULTADO_OK;
        }

        protected virtual void Cancelar()
        {
            Resultado = RESULTADO_CANCEL;
        }

        protected virtual void ControlarError(Exception error)
        {
            Resultado = RESULTADO_ERROR;
        }
        #endregion


        #region Propiedades
        public ActividadInfo ActividadInfo
        {
            get;
        }

        public virtual string Resultado
        {
            get;
            protected set;
        }
        #endregion
    }
}
