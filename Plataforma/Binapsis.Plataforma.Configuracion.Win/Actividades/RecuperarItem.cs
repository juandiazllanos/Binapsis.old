using Binapsis.Plataforma.Estructura.Impl;

namespace Binapsis.Plataforma.Configuracion.Win.Actividades
{
    class RecuperarItem : Actividad
    {
        public override void Iniciar()
        {            
            IElemento elementoSeleccionado = Controlador.Contexto.ElementoSeleccionado;
            ObjetoBase propietario = Estado;
            
            if (propietario == null || elementoSeleccionado == null)
            {
                Cancelar();
                return;
            }

            string[] nombre = elementoSeleccionado.Valor.Split(new char[] { '.', '/' });

            if (propietario.GetType() == typeof(Tipo))
                Estado = ((Tipo)propietario).ObtenerPropiedad(nombre[nombre.GetUpperBound(0)]);

            else if (propietario.GetType() == typeof(Tabla))
                Estado = ((Tabla)propietario).ObtenerColumna(nombre[nombre.GetUpperBound(0)]);

            Terminar();
        }
    }
}
