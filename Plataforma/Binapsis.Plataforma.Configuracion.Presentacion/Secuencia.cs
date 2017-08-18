using System;
using System.Collections.Generic;

namespace Binapsis.Plataforma.Configuracion.Presentacion
{
    public class Secuencia
    {
        Dictionary<string, Type> _actividades;
        Dictionary<string, Asociacion> _asociaciones;

        const string ASSEMBLY_ACTIVIDAD = "Binapsis.Plataforma.Configuracion.Presentacion";

        public Secuencia()
        {
            _actividades = new Dictionary<string, Type>();
            _asociaciones = new Dictionary<string, Asociacion>();
        }

        public void Agregar(string nombre)
        {
            Agregar(nombre, $"{ASSEMBLY_ACTIVIDAD}.Actividades.{nombre}");
        }

        public void Agregar(string nombre, string type)
        {
            Agregar(nombre, type, ASSEMBLY_ACTIVIDAD);
        }

        public void Agregar(string nombre, string type, string assembly)
        {
            Type typeInstancia = Type.GetType($"{type}, {ASSEMBLY_ACTIVIDAD}");
            Agregar(nombre, typeInstancia);
        }

        public void Agregar(string nombre, Type type)
        {
            if (_actividades.ContainsKey(nombre) || type == null) return;
            _actividades.Add(nombre, type);

            if (Inicio == null) Inicio = nombre;
        }

        public void Asociar(string actividad1, string actividad2)
        {
            Asociar(actividad1, actividad2, Actividad.RESULTADO_OK);
        }

        public void Asociar(string actividad1, string actividad2, string clave)
        {
            if (!_asociaciones.ContainsKey(actividad1))
                _asociaciones.Add(actividad1, new Asociacion());

            _asociaciones[actividad1].Agregar(clave, actividad2);
        }

        public Type Obtener(string nombre)
        {
            if (_actividades.ContainsKey(nombre))
                return _actividades[nombre];
            else
                return null;
        }

        public string Siguiente(string nombre, string clave)
        {
            if (_asociaciones.ContainsKey(nombre))
                return _asociaciones[nombre].Obtener(clave);
            else
                return null;
        }

        public string Inicio
        {
            get;
            set;
        }
    }
}
