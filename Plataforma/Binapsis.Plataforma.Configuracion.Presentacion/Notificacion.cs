using Binapsis.Plataforma.Configuracion.Presentacion.Navegacion;
using System;

namespace Binapsis.Plataforma.Configuracion.Presentacion
{
    class Notificacion
    {
        public Notificacion(Consola consola, Accion accion)
        {
            Consola = consola;
            Accion = accion;
        }

        public virtual void Iniciar(Operacion operacion)
        {
            Type type = operacion.Parametros["type"] as Type;
            Elemento elemento = operacion.Parametros["clave"] as Elemento;

            Consola.NotificarIniciar(Accion, type, elemento);
        }

        public virtual void Terminar(Operacion operacion)
        {
            Type type = operacion.Parametros["type"] as Type;
            Elemento elemento = operacion.Parametros["clave"] as Elemento;
            string resultado = operacion.Resultado;

            Consola.NotificarTerminar(Accion, type, elemento, resultado);
        }

        private Consola Consola
        {
            get;
        }

        private Accion Accion
        {
            get;
        }
        
    }
}
