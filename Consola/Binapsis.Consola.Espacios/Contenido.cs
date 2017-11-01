using Binapsis.Consola.Definicion;
using Binapsis.Plataforma.Configuracion;
using Binapsis.Plataforma.Estructura.Impl;
using System;
using System.Collections;
using System.Linq;

namespace Binapsis.Consola.Espacios
{
    public class Contenido
    {
        public Contenido(ContenidoInfo contenidoInfo)
        {
            ContenidoInfo = contenidoInfo;
        }

        public virtual IEnumerable Consultar()
        {
            Coleccion coleccion = new Coleccion();
            ObjetoDatos item = null;
            Tipo tipo = Fabrica.Instancia.Crear<Tipo>();
            
            tipo.Nombre = "Item";            
            tipo.CrearPropiedad("Codigo", Plataforma.Configuracion.Types.Instancia.Obtener(typeof(string)));
            tipo.CrearPropiedad("Nombre", Plataforma.Configuracion.Types.Instancia.Obtener(typeof(string)));

            string chars = "ABDEFGHIJKLMNÑOPQRSTUVWXYZ0123456789";
            Random rnd = new Random();
            
            for(int i = 0; i < 100; i++)
            {
                item = FabricaDatos.Instancia.Crear(tipo);
                item.EstablecerString("Codigo", new string(Enumerable.Repeat(chars, 6).Select(s => s[rnd.Next(s.Length)]).ToArray()));
                item.EstablecerString("Nombre", new string(Enumerable.Repeat(chars, 25).Select(s => s[rnd.Next(s.Length)]).ToArray()));

                coleccion.Agregar(item);
            }

            return coleccion;
        }

        public ContenidoInfo ContenidoInfo
        {
            get;
        }
    }
}
