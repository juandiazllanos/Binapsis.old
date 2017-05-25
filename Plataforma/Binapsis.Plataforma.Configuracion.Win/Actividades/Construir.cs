using Binapsis.Plataforma.Estructura.Impl;
using System.Linq;
using System.Reflection;

namespace Binapsis.Plataforma.Configuracion.Win.Actividades
{
    class Construir : Actividad
    {
        public override void Iniciar()
        {
            ObjetoBase propietario = RecuperarPropietario();

            if (Estado == null)
            {
                Cancelar();
                return;
            }

            if (propietario != null)
                EstablecerPropietario(Estado, propietario);

            Terminar();
        }

        private ObjetoBase RecuperarPropietario()
        {
            if (Controlador.Contexto.ElementoPropietario == Controlador.Contexto.ElementoRoot) return null;

            IRepositorio repositorio = Controlador.Contexto.Repositorio;
            IElemento elemento = Controlador.Contexto.ElementoPropietario;

            if (elemento == null) return null;
            return repositorio.Obtener(elemento.Type, elemento.Valor);            
        }

        private void EstablecerPropietario(ObjetoBase obj, ObjetoBase valor)
        {
            if (obj == null || valor == null) return;

            PropertyInfo property = obj.GetType().GetProperties().FirstOrDefault(item => item.PropertyType == valor.GetType());
            if (property == null) return;
            property.SetValue(obj, valor);
        }
    }
}
