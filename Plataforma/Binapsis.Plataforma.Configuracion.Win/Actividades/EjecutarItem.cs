namespace Binapsis.Plataforma.Configuracion.Win.Actividades
{
    class EjecutarItem : Actividad
    {
        public override void Iniciar()
        {
            IRepositorio repositorio = Controlador.Contexto.Repositorio;
            ConfiguracionBase propietario = (ConfiguracionBase)Estado?.Propietario;

            string accion = Controlador.Accion.Nombre;
            string clave = Controlador.Contexto.ElementoPropietario?.Valor;

            if (repositorio == null || propietario == null || Estado == null)
            {
                Cancelar();
                return;
            }
            
            if (accion == "Eliminar" && propietario.GetType() == typeof(Tipo))
                ((Tipo)propietario).RemoverPropiedad((Estado as Propiedad).Nombre);

            else if (accion == "Eliminar" && propietario.GetType() == typeof(Tabla))
                ((Tabla)propietario).RemoverColumna((Estado as Columna).Nombre);

            repositorio.Establecer(propietario, clave);

            Terminar();
        }
    }
}
