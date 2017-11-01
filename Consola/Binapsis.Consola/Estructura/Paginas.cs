using Binapsis.Consola.Definicion;
using Binapsis.Consola.Navegacion;

namespace Binapsis.Consola.Estructura
{
    public class Paginas : ColeccionMain<Categoria, Pagina>
    {
        public Paginas(Main main) 
            : base(main)
        {
        }
        
        protected override Pagina Instanciar(Categoria elemento)
        {
            ContenidoInfo contenidoInfo = Main.ConsolaInfo.Contenidos.Obtener(elemento.Nombre);
            ModeloInfo modeloInfo = Main.ConsolaInfo.Modelos.Obtener(elemento.Nombre);

            Pagina pagina = new Pagina(Main, elemento)
            {
                ContenidoInfo = contenidoInfo,
                ModeloInfo = modeloInfo
            };

            // construir acciones
            foreach (AccionModeloInfo ami in modeloInfo.Acciones)
                pagina.Acciones.Crear(ami.AccionInfo);

            return pagina;
        }
    }
}
