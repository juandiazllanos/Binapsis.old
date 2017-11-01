using Binapsis.Consola.Navegacion;

namespace Binapsis.Consola.Win
{
    public class BuilderNavegador
    {
        public BuilderNavegador(Navegador navegador)
        {
            Navegador = navegador;
        }

        public void Construir()
        {
            Grupo grupoVentas = new Grupo { Nombre = "Ventas" };
                        
            grupoVentas.Elementos.Agregar(new Categoria { Nombre = "Departamento" });
            grupoVentas.Elementos.Agregar(new Categoria { Nombre = "Provincia" });
            grupoVentas.Elementos.Agregar(new Categoria { Nombre = "Distrito" });
            grupoVentas.Elementos.Agregar(new Categoria { Nombre = "Ubigeo" });

            Navegador.Categorias.Agregar(grupoVentas);

            Grupo grupoEdicion = new Grupo { Nombre = "Edición" };

            grupoEdicion.Elementos.Agregar(new Elemento { Nombre = "Crear" });
            grupoEdicion.Elementos.Agregar(new Elemento { Nombre = "Editar" });
            grupoEdicion.Elementos.Agregar(new Elemento { Nombre = "Eliminar" });

            Navegador.Comandos.Agregar(grupoEdicion);
        }

        public Navegador Navegador
        {
            get;
        }
    }
}
