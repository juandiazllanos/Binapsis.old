using System;
using System.Collections.Generic;
using System.Linq;

namespace Binapsis.Plataforma.Configuracion.Presentacion
{
    class Controlador
    {
        Dictionary<Accion, Secuencia> _secuencias;
        
        public Controlador(Consola consola)
        {
            Consola = consola;
            _secuencias = new Dictionary<Accion, Secuencia>();
        }
        
        public void Agregar(Accion accion, Secuencia secuencia)
        {
            if (!_secuencias.ContainsKey(accion))
                _secuencias.Add(accion, secuencia);
        }

        public void Ejecutar(string accion)
        {
            Ejecutar(ObtenerAccion(accion));
        }

        public void Ejecutar(string accion, Parametros parametros)
        {
            Ejecutar(ObtenerAccion(accion), parametros);
        }

        public void Ejecutar(string accion, IResultado resultado)
        {
            Ejecutar(ObtenerAccion(accion), resultado);
        }

        public void Ejecutar(string accion, Parametros parametros, IResultado resultado)
        {
            Ejecutar(ObtenerAccion(accion), parametros, resultado);
        }

        public void Ejecutar(Accion accion)
        {
            Ejecutar(accion, default(IResultado));
        }

        public void Ejecutar(Accion accion, IResultado resultado)
        {
            Parametros parametros = new Parametros();
            
            parametros.Establecer("type", Consola.Type);
            parametros.Establecer("clave", Consola.ClaveActual);

            Ejecutar(accion, parametros, resultado);
        }

        public void Ejecutar(Accion accion, Parametros parametros)
        {
            Ejecutar(accion, parametros, null);
        }

        public void Ejecutar(Accion accion, Parametros parametros, IResultado resultado)
        {
            if (accion == null) return;

            Notificacion notificacion;

            if (resultado != null)
                notificacion = new NotificacionResultado(Consola, accion, resultado);
            else
                notificacion = new Notificacion(Consola, accion);

            Secuencia secuencia = null;

            if (_secuencias.ContainsKey(accion))
                secuencia = _secuencias[accion];

            if (secuencia != null)
                Ejecutar(_secuencias[accion], parametros, notificacion);
        }
        
        public void Ejecutar(Secuencia secuencia, Parametros parametros, Notificacion notificacion)
        {
            Operacion operacion = new Operacion(secuencia);

            if (parametros == null) parametros = new Parametros();

            operacion.Contexto = Consola;
            operacion.Parametros = parametros;
            operacion.Notificacion = notificacion;

            operacion.Iniciar();
        }

        private Accion ObtenerAccion(string accion)
        {
            return _secuencias.Keys.FirstOrDefault(item => item.Nombre.Equals(accion, StringComparison.OrdinalIgnoreCase));
        }

        private Consola Consola
        {
            get;
        }
    }
}
