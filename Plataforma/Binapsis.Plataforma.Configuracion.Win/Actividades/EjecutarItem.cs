using Binapsis.Plataforma.Estructura.Impl;

namespace Binapsis.Plataforma.Configuracion.Win.Actividades
{
    class EjecutarItem : Actividad
    {
        public override void Iniciar()
        {
            IRepositorio repositorio = Controlador.Contexto.Repositorio;
            ObjetoBase propietario = Estado?.Propietario;

            string accion = Controlador.Accion.Nombre;
            string clave = Controlador.Contexto.ElementoPropietario?.Valor;

            if (repositorio == null || propietario == null || Estado == null)
            {
                Cancelar();
                return;
            }
            
            if (accion == "Eliminar" && propietario.GetType() == typeof(Tipo))
                ((Tipo)propietario).RemoverPropiedad((Estado as Propiedad).Nombre);

            repositorio.Establecer(propietario, clave);

            Terminar();
        }
    }
}
