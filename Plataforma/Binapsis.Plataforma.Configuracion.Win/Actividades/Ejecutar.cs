using Binapsis.Plataforma.Estructura.Impl;

namespace Binapsis.Plataforma.Configuracion.Win.Actividades
{
    class Ejecutar : Actividad
    {
        public override void Iniciar()
        {
            IRepositorio repositorio = Controlador.Contexto.Repositorio;
            string accion = Controlador.Accion.Nombre;
            string clave = Controlador.Contexto.ElementoSeleccionado?.Valor;

            if (repositorio == null || 
                (accion == "Eliminar" && Controlador.Contexto.ElementoSeleccionado == null) || 
                (accion != "Eliminar" && Estado == null))
            {
                Cancelar();
                return;
            }

            if (accion == "Crear")
                repositorio.Establecer(Estado);
            else if (accion == "Editar" && !string.IsNullOrEmpty(clave))
                repositorio.Establecer(Estado, clave);
            else if (accion == "Eliminar")
                repositorio.Eliminar(Type, clave);

            Terminar();
        }
        
    }
}
