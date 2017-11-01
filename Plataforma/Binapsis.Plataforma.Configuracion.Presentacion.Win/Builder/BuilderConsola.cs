using Binapsis.Plataforma.Configuracion.Presentacion.Win.Actividades;
using Binapsis.Plataforma.Configuracion.Presentacion.Win.Builder;
using Binapsis.Plataforma.Configuracion.Presentacion.Navegacion;

namespace Binapsis.Plataforma.Configuracion.Presentacion.Win
{
    class BuilderConsola
    {
        public BuilderConsola(Consola consola)
        {
            Consola = consola;
        }

        public void Construir()
        {
            ConstruirAcciones();
            ConstruirFabricas();
            ConstruirGrupos();
            ConstruirConsultas();
            ConstruirTipos();
        }

        private void ConstruirTipos()
        {
            Consola.Agregar("Ensamblado", typeof(Ensamblado));
            Consola.Agregar("Uri", typeof(Uri));
            Consola.Agregar("Tipo", typeof(Tipo));
            Consola.Agregar("Propiedad", typeof(Propiedad));
            Consola.Agregar("Contexto", typeof(Contexto));
            Consola.Agregar("Conexion", typeof(Conexion));
            Consola.Agregar("Tabla", typeof(Tabla));
            Consola.Agregar("Columna", typeof(Columna));
            Consola.Agregar("Relacion", typeof(Relacion));
            Consola.Agregar("Comando", typeof(Comando));
        }

        private void ConstruirConsultas()
        {
            Consola.Agregar("Ensamblado", "listarEnsamblado");
            Consola.Agregar("Uri", "listarUriPorEnsamblado");
            Consola.Agregar("Tipo", "listarTipoPorUri");
            Consola.Agregar("Propiedad", "listarPropiedadPorTipo");
            Consola.Agregar("Contexto", "listarContexto");
            Consola.Agregar("Conexion", "listarConexion");
            Consola.Agregar("Tabla", "listarTabla");
            Consola.Agregar("Columna", "listarColumnaPorTabla");
            Consola.Agregar("Relacion", "listarRelacion");
            Consola.Agregar("Comando", "listarComando");
            Consola.Agregar("Parametro", "listarParametroPorComando");
            Consola.Agregar("ResultadoDescriptor", "listarResultadoDescriptorPorComando");
        }

        private void ConstruirGrupos()
        {
            Categoria categoria;
            Grupo grupo = new Grupo { Nombre = "Configuración" };            
            grupo.Grupos.Agregar(categoria = new Categoria { Nombre = "Ensamblado" });
            categoria.Grupos.Agregar(categoria = new Categoria { Nombre = "Uri" });
            categoria.Grupos.Agregar(categoria = new Categoria { Nombre = "Tipo" });
            categoria.Grupos.Agregar(categoria = new CategoriaItem("Propiedades") { Nombre = "Propiedad" });

            grupo.Grupos.Agregar(categoria = new Categoria { Nombre = "Contexto"});
            grupo.Grupos.Agregar(categoria = new Categoria { Nombre = "Conexion", Descripcion = "Conexión" });
            grupo.Grupos.Agregar(categoria = new Categoria { Nombre = "Tabla" });
            categoria.Grupos.Agregar(categoria = new CategoriaItem("Columnas") { Nombre = "Columna" });
            grupo.Grupos.Agregar(categoria = new Categoria { Nombre = "Relacion", Descripcion = "Relación" });
            grupo.Grupos.Agregar(categoria = new Categoria { Nombre = "Comando" });
            categoria.Grupos.Agregar(new CategoriaItem("Parametros") { Nombre = "Parametro" });
            categoria.Grupos.Agregar(new CategoriaItem("ResultadoDescriptores") { Nombre = "ResultadoDescriptor", Descripcion = "Resultado" });

            Consola.Navegador.Grupos.Agregar(grupo);
        }

        private void ConstruirFabricas()
        {
            Consola.Agregar("entidad", ControladorEntidad.Instancia);
            Consola.Agregar("actividad", new ControladorActividad());

            Consola.Agregar("vistaEntidad", new ControladorVistaEntidad());
            Consola.Agregar("vistaSeleccionar", new ControladorVistaSeleccionar());            
        }
        
        private void ConstruirAcciones()
        {
            ConstruirAccion("Crear", new BuilderSecuenciaCrear());
            ConstruirAccion("Editar", new BuilderSecuenciaEditar());
            ConstruirAccion("Eliminar", new BuilderSecuenciaEliminar());

            ConstruirAccion("CrearItem", new BuilderSecuenciaCrearItem());
            ConstruirAccion("EditarItem", new BuilderSecuenciaEditarItem());
            ConstruirAccion("EliminarItem", new BuilderSecuenciaEliminarItem());

            // actualizar
            Secuencia secuencia = new Secuencia();
            secuencia.Agregar("Actualizar", typeof(Actualizar));

            Accion accion = new Accion { Nombre = "Actualizar" };

            Consola.Agregar(accion, secuencia);

            // seleccionar
            secuencia = new Secuencia();
            secuencia.Agregar("Seleccionar");
            secuencia.Agregar("Recuperar");
            secuencia.Asociar("Seleccionar", "Recuperar");

            accion = new Accion { Nombre = "Seleccionar" };

            Consola.Agregar(accion, secuencia);
            
        }

        private void ConstruirAccion(string nombre, BuilderSecuencia builder)
        {
            Accion accion = new Accion() { Nombre = nombre };
            Secuencia secuencia = new Secuencia();

            builder.Secuencia = secuencia;
            builder.Construir();

            Consola.Agregar(accion, secuencia);
        }
        
        public Consola Consola
        {
            get;
        }

    }
}
