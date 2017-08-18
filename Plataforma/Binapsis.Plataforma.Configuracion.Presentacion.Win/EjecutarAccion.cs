using Binapsis.Plataforma.Configuracion.Presentacion.Navegacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Binapsis.Plataforma.Configuracion.Presentacion.Win
{
    class EjecutarAccion
    {
        public EjecutarAccion(Main main, Consola consola, string accion)
        {
            Main = main;
            Consola = consola;
            Accion = accion;
        }

        public void Ejecutar(IResultado resultado)
        {
            Nodo nodo = Consola.NodoActual;
            Clave clave = Consola.ClaveActual;            
            Type type = Consola.Type;
            string accion = Accion;

            if (nodo == null) return;

            Parametros parametros = new Parametros();
            NodoInfo info = new NodoInfo(Consola, nodo);

            if (info.Elemento is CategoriaItem categoriaItem)
            {
                parametros["propiedad"] = categoriaItem.Propiedad;
                parametros["claveItem"] = clave;
                parametros["typeItem"] = type;

                info = new NodoInfo(Consola, nodo.Padre as Nodo);
                clave = info.Elemento as Clave;

                info = new NodoInfo(Consola, info.Nodo?.Padre as Nodo);
                type = info.Type;

                accion += "Item";
            }

            parametros["type"] = type;
            parametros["clave"] = clave;

            Consola.Ejecutar(accion, parametros, resultado);
        }

        private string Accion
        {
            get;
        }

        private Consola Consola
        {
            get;
        }

        private Main Main
        {
            get;
        }
    }
}
