using System;
using Binapsis.Consola.Definicion;

namespace Binapsis.Consola.Win.Builder
{
    class BuilderConsolaInfo
    {
        public BuilderConsolaInfo(ConsolaInfo consolaInfo)
        {
            ConsolaInfo = consolaInfo;
        }

        public void Construir()
        {
            // crear ensamblados
            ConstruirAssemblies();

            // crear trabajos
            ConstruirTrabajos();

            // crear acciones
            ConstruirAcciones();

            // construir consultas
            ConstruirConsultas();

            // crear contenidos
            ConstruirContenidos();

            // crear modelos
            ConstruirModelos();

            // crear vistas
            ConstruirVistas();
        }

        private void ConstruirAssemblies()
        {            
            ConsolaInfo.Assemblies.Crear("Binapsis.Modelo", "1.0.0.0").
                FileName = "D:\\Desarrollo\\Binapsis\\Modelo\\Binapsis.Modelo\\bin\\debug\\netstandard1.3\\Binapsis.Modelo.dll";
            ConsolaInfo.Assemblies.Crear("Binapsis.Presentacion", "1.0.0.0").
                FileName = "D:\\Desarrollo\\Binapsis\\Presentacion\\Binapsis.Presentacion\\bin\\debug\\Binapsis.Presentacion.dll";
            ConsolaInfo.Assemblies.Crear("Binapsis.Presentacion.Editores.Win", "1.0.0.0").
                FileName = "D:\\Desarrollo\\Binapsis\\Presentacion\\Binapsis.Presentacion.Editores.Win\\bin\\debug\\Binapsis.Presentacion.Editores.Win.dll";
            ConsolaInfo.Assemblies.Crear("Binapsis.Procesos.Actividades", "1.0.0.0").
                FileName = "D:\\Desarrollo\\Binapsis\\Procesos\\Binapsis.Procesos.Actividades\\bin\\debug\\netstandard1.3\\Binapsis.Procesos.Actividades.dll";
        }

        private void ConstruirTrabajos()
        {
            // crear dialogo
            TypeInfo dialogoInfo = ConsolaInfo.Types.Crear("Dialogo", "Binapsis.Presentacion.Editores.Win");

            // trabajo crear
            TrabajoInfo trabajoCrear = ConsolaInfo.Trabajos.Crear("CrearModelo", "Trabajo", "Binapsis.Procesos.Trabajos");
            trabajoCrear.Actividades.Crear("InstanciarModelo", "Binapsis.Procesos.Actividades");
            trabajoCrear.Actividades.Crear("MostrarModelo", "Binapsis.Procesos.Actividades").DialogoInfo = dialogoInfo;
            trabajoCrear.Actividades.Crear("CrearModelo", "Binapsis.Procesos.Actividades");

            trabajoCrear.ActividadInicio = "InstanciarModelo";
            trabajoCrear.Resultados.Crear("OK");

            trabajoCrear.Asociaciones.Crear("OK", "InstanciarModelo", "MostrarModelo");
            trabajoCrear.Asociaciones.Crear("OK", "MostrarModelo", "CrearModelo");

            // trabajo editar
            TrabajoInfo trabajoEditar = ConsolaInfo.Trabajos.Crear("EditarModelo", "Trabajo", "Binapsis.Procesos.Trabajos");
            trabajoEditar.Actividades.Crear("RecuperarModelo", "Binapsis.Procesos.Actividades");
            trabajoEditar.Actividades.Crear("MostrarModelo", "Binapsis.Procesos.Actividades").DialogoInfo = dialogoInfo;
            trabajoEditar.Actividades.Crear("EditarModelo", "Binapsis.Procesos.Actividades");

            trabajoEditar.ActividadInicio = "RecuperarModelo";
            trabajoEditar.Resultados.Crear("OK");

            trabajoEditar.Asociaciones.Crear("OK", "RecuperarModelo", "MostrarModelo");
            trabajoEditar.Asociaciones.Crear("OK", "MostrarModelo", "EditarModelo");

            TrabajoInfo trabajoEliminar = ConsolaInfo.Trabajos.Crear("EliminarModelo", "Trabajo", "Binapsis.Procesos.Trabajos");
            trabajoEliminar.Actividades.Crear("RecuperarModelo", "Binapsis.Procesos.Actividades");
            trabajoEliminar.Actividades.Crear("EliminarModelo", "Binapsis.Procesos.Actividades");

            trabajoEliminar.ActividadInicio = "RecuperarModelo";
            trabajoEliminar.Resultados.Crear("OK");

            trabajoEliminar.Asociaciones.Crear("OK", "RecuperarModelo", "EliminarModelo");
        }

        private void ConstruirAcciones()
        {
            // accion crear
            AccionInfo accionCrear = ConsolaInfo.Acciones.Crear("Crear");
            accionCrear.TrabajoInfo = ConsolaInfo.Trabajos["CrearModelo"];

            // accion editar
            AccionInfo accionEditar = ConsolaInfo.Acciones.Crear("Editar");
            accionEditar.TrabajoInfo = ConsolaInfo.Trabajos["EditarModelo"];

            // accion eliminar
            AccionInfo accionEliminar = ConsolaInfo.Acciones.Crear("Eliminar");
            accionEliminar.TrabajoInfo = ConsolaInfo.Trabajos["EliminarModelo"];
        }

        private void ConstruirConsultas()
        {
            ConsultaInfo consultaDistrito = ConsolaInfo.Consultas.Crear("listarDistrito");
            ConsultaInfo consultaProvincia = ConsolaInfo.Consultas.Crear("listarProvincia");
            ConsultaInfo consultaDepartamento = ConsolaInfo.Consultas.Crear("listarDepartamento");
        }

        private void ConstruirContenidos()
        {
            ContenidoInfo contenidoDistrito = ConsolaInfo.Contenidos.Crear("Distrito", "Grid", "Binapsis.Consola.Win");
            contenidoDistrito.ConsultaInfo = ConsolaInfo.Consultas["listarDistrito"];
            //contenidoDistrito.Columnas.Crear("Codigo").Ancho = 20;
            contenidoDistrito.Columnas.Crear("Nombre").Ancho = 100;

            ContenidoInfo contenidoProvincia = ConsolaInfo.Contenidos.Crear("Provincia", "Grid", "Binapsis.Consola.Win");
            contenidoProvincia.ConsultaInfo = ConsolaInfo.Consultas["listarProvincia"];
            contenidoProvincia.Columnas.Crear("Codigo").Ancho = 20;
            contenidoProvincia.Columnas.Crear("Nombre").Ancho = 100;

            ContenidoInfo contenidoDepartamento = ConsolaInfo.Contenidos.Crear("Departamento", "Grid", "Binapsis.Consola.Win");
            contenidoDepartamento.ConsultaInfo = ConsolaInfo.Consultas["listarDepartamento"];
            contenidoDepartamento.Columnas.Crear("Codigo").Ancho = 20;
            contenidoDepartamento.Columnas.Crear("Nombre").Ancho = 100;
        }

        private void ConstruirModelos()
        {
            // modelo departamento
            ModeloInfo modeloDepartamento = ConsolaInfo.Modelos.Crear("Departamento", "Binapsis.Modelo");
            modeloDepartamento.Acciones.Crear("Crear");
            modeloDepartamento.Acciones.Crear("Editar");
            modeloDepartamento.Acciones.Crear("Eliminar");

            // modelo provinicia
            ModeloInfo modeloProvincia = ConsolaInfo.Modelos.Crear("Provincia", "Binapsis.Modelo");
            modeloProvincia.Acciones.Crear("Crear");
            modeloProvincia.Acciones.Crear("Editar");
            modeloProvincia.Acciones.Crear("Eliminar");

            // modelo distrito
            ModeloInfo modeloDistrito = ConsolaInfo.Modelos.Crear("Distrito", "Binapsis.Modelo");
            modeloDistrito.Acciones.Crear("Crear");
            modeloDistrito.Acciones.Crear("Editar");
            modeloDistrito.Acciones.Crear("Eliminar");
        }

        private void ConstruirVistas()
        {
            VistaInfo vistaDistrito = ConsolaInfo.Vistas.Crear("Distrito", "VistaDistrito", "Binapsis.Presentacion");
        }

        public ConsolaInfo ConsolaInfo
        {
            get;
        }
    }
}
