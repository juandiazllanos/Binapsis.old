using Binapsis.Presentacion.MVVM;
using System;
using Binapsis.Plataforma.Estructura;
using Binapsis.Presentacion.Editores;
using System.Reflection;

namespace Binapsis.Plataforma.Configuracion.Presentacion.Win.Comandos
{
    class SeleccionarReferencia : IComando
    {
        public SeleccionarReferencia(string propiedad, IEditorAtributo editor, string consulta)
        {
            Editor = editor;
            Propiedad = propiedad;
            Consulta = consulta;            
        }

        public void Ejecutar(IObjetoDatos od)
        {
            if (od == null) return;

            //IPropiedad propiedad = od.Tipo.ObtenerPropiedad(Propiedad);
            //if (propiedad == null) return;

            PropertyInfo property = od.GetType().GetProperty(Propiedad);
            if (property == null) return;

            Parametros parametros = new Parametros();
            parametros["consulta"] = Consulta;
            parametros["type"] = property.PropertyType;
            parametros["nombre"] = $"{Editor.Valor}%";

            Entorno.Consola.Ejecutar("Seleccionar", parametros, null);

            IObjetoDatos instancia = parametros["instancia"] as IObjetoDatos;
            if (instancia == null) return;

            //od.EstablecerObjetoDatos(propiedad, instancia);
            property.SetValue(od, instancia);
        }

        private string Consulta
        {
            get;
        }

        public IEditorAtributo Editor
        {
            get;
        }

        public string Propiedad
        {
            get;
        }        
    }
}
