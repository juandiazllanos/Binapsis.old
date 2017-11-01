using System.Collections.Generic;
using System.Linq;
//using Binapsis.Plataforma.Configuracion;
//using Contexto = Binapsis.Plataforma.Configuracion.Contexto;

namespace Binapsis.Plataforma.Configuracion.Datos
{
    public class ConfiguracionRepositorio
    {
        public IList<ConfiguracionBase> _items;

        #region Constructores
        static ConfiguracionRepositorio()
        {
            Instancia = new ConfiguracionRepositorio();
        }

        private ConfiguracionRepositorio()
        {            
            Construir();
        }
        #endregion  


        #region Metodos
        private void Construir()
        {
            _items = new List<ConfiguracionBase>();

            ConstruirTablas();
            ConstruirRelaciones();
            ConstruirTipos();
            ConstruirComandos();
        }

        private void ConstruirTipos()
        {
            _items.Add(Types.Instancia.Obtener(typeof(Ensamblado)));
            _items.Add(Types.Instancia.Obtener(typeof(Uri)));
            _items.Add(Types.Instancia.Obtener(typeof(Tipo)));
            _items.Add(Types.Instancia.Obtener(typeof(Propiedad)));

            _items.Add(Types.Instancia.Obtener(typeof(Contexto)));
            _items.Add(Types.Instancia.Obtener(typeof(Conexion)));
            _items.Add(Types.Instancia.Obtener(typeof(Tabla)));
            _items.Add(Types.Instancia.Obtener(typeof(Columna)));
            _items.Add(Types.Instancia.Obtener(typeof(Relacion)));

            _items.Add(Types.Instancia.Obtener(typeof(Comando)));
        }
        

        private void ConstruirTablas()
        {
            Tabla ensamblado = Fabrica.Instancia.Crear<Tabla>();
            ensamblado.Nombre = "Ensamblado";
            ensamblado.TipoAsociado = typeof(Ensamblado).FullName;
            ensamblado.CrearColumna("PK_Ensamblado", "", true);

            Tabla uri = Fabrica.Instancia.Crear<Tabla>();
            uri.Nombre = "Uri";
            uri.TipoAsociado = typeof(Uri).FullName;
            uri.CrearColumna("PK_Uri", "", true);

            Tabla tipo = Fabrica.Instancia.Crear<Tabla>();
            tipo.Nombre = "Tipo";
            tipo.TipoAsociado = typeof(Tipo).FullName;
            tipo.CrearColumna("PK_Tipo", "", true);

            Tabla propiedad = Fabrica.Instancia.Crear<Tabla>();
            propiedad.Nombre = "Propiedad";
            propiedad.TipoAsociado = typeof(Propiedad).FullName;
            propiedad.CrearColumna("PK_Propiedad", "", true);

            Tabla tabla = Fabrica.Instancia.Crear<Tabla>();
            tabla.Nombre = "Tabla";
            tabla.TipoAsociado = typeof(Tabla).FullName;
            tabla.CrearColumna("PK_Tabla", "", true);

            Tabla columna = Fabrica.Instancia.Crear<Tabla>();
            columna.Nombre = "Columna";
            columna.TipoAsociado = typeof(Columna).FullName;
            columna.CrearColumna("PK_Columna", "", true);

            Tabla relacion = Fabrica.Instancia.Crear<Tabla>();
            relacion.Nombre = "Relacion";
            relacion.TipoAsociado = typeof(Relacion).FullName;
            relacion.CrearColumna("PK_Relacion", "", true);

            Tabla contexto = Fabrica.Instancia.Crear<Tabla>();
            contexto.Nombre = "Contexto";
            contexto.TipoAsociado = typeof(Contexto).FullName;
            contexto.CrearColumna("PK_Contexto", "", true);

            Tabla conexion = Fabrica.Instancia.Crear<Tabla>();
            conexion.Nombre = "Conexion";
            conexion.TipoAsociado = typeof(Conexion).FullName;
            conexion.CrearColumna("PK_Conexion", "", true);

            Tabla comando = Fabrica.Instancia.Crear<Tabla>();
            comando.Nombre = "Comando";
            comando.TipoAsociado = typeof(Comando).FullName;
            comando.CrearColumna("PK_Comando", "", true);

            Tabla parametro = Fabrica.Instancia.Crear<Tabla>();
            parametro.Nombre = "Parametro";
            parametro.TipoAsociado = typeof(Parametro).FullName;
            parametro.CrearColumna("PK_Parametro", "", true);

            Tabla resultadoDescriptor = Fabrica.Instancia.Crear<Tabla>();
            resultadoDescriptor.Nombre = "ResultadoDescriptor";
            resultadoDescriptor.TipoAsociado = typeof(ResultadoDescriptor).FullName;
            resultadoDescriptor.CrearColumna("PK_ResultadoDescriptor", "", true);

            _items.Add(ensamblado);
            _items.Add(uri);
            _items.Add(tipo);
            _items.Add(propiedad);

            _items.Add(contexto);

            _items.Add(conexion);
            _items.Add(tabla);
            _items.Add(columna);
            _items.Add(relacion);
            _items.Add(comando);
            _items.Add(parametro);
            _items.Add(resultadoDescriptor);

        }

        private void ConstruirRelaciones()
        {
            // Uri => Ensamblado
            Relacion uriEnsamblado = Fabrica.Instancia.Crear<Relacion>();
            uriEnsamblado.TipoAsociado = typeof(Uri).FullName;
            uriEnsamblado.Propiedad = "Ensamblado";
            uriEnsamblado.TablaSecundaria = "Uri";
            uriEnsamblado.ColumnaSecundaria = "FK_Ensamblado";
            uriEnsamblado.TablaPrincipal = "Ensamblado";
            uriEnsamblado.ColumnaPrincipal = "PK_Ensamblado";
            
            // Tipo => Uri
            Relacion tipoUri = Fabrica.Instancia.Crear<Relacion>();
            tipoUri.TipoAsociado = typeof(Tipo).FullName;
            tipoUri.Propiedad = "Uri";
            tipoUri.TablaSecundaria = "Tipo";
            tipoUri.ColumnaSecundaria = "FK_Uri";
            tipoUri.TablaPrincipal = "Uri";
            tipoUri.ColumnaPrincipal = "PK_Uri";

            // Tipo => TipoBase
            Relacion tipoTipoBase = Fabrica.Instancia.Crear<Relacion>();
            tipoTipoBase.TipoAsociado = typeof(Tipo).FullName;
            tipoTipoBase.Propiedad = "Base";
            tipoTipoBase.TablaSecundaria = "Tipo";
            tipoTipoBase.ColumnaSecundaria = "FK_Tipo_Base";
            tipoTipoBase.TablaPrincipal = "Tipo";
            tipoTipoBase.ColumnaPrincipal = "PK_Tipo";

            // Propiedad => TipoPropietario
            Relacion propiedadTipoPropietario = Fabrica.Instancia.Crear<Relacion>();
            propiedadTipoPropietario.TipoAsociado = typeof(Tipo).FullName;
            propiedadTipoPropietario.Propiedad = "Propiedades";
            propiedadTipoPropietario.TablaSecundaria = "Propiedad";
            propiedadTipoPropietario.ColumnaSecundaria = "FK_Tipo_Propietario";
            propiedadTipoPropietario.TablaPrincipal = "Tipo";
            propiedadTipoPropietario.ColumnaPrincipal = "PK_Tipo";

            // Propiedad => TipoTipo
            Relacion propiedadTipoTipo = Fabrica.Instancia.Crear<Relacion>();
            propiedadTipoTipo.TipoAsociado = typeof(Propiedad).FullName;
            propiedadTipoTipo.Propiedad = "Tipo";
            propiedadTipoTipo.TablaSecundaria = "Propiedad";
            propiedadTipoTipo.ColumnaSecundaria = "FK_Tipo_Tipo";
            propiedadTipoTipo.TablaPrincipal = "Tipo";
            propiedadTipoTipo.ColumnaPrincipal = "PK_Tipo";

            // Columna => Tabla
            Relacion columnaTabla = Fabrica.Instancia.Crear<Relacion>();
            columnaTabla.TipoAsociado = typeof(Tabla).FullName;
            columnaTabla.Propiedad = "Columnas";
            columnaTabla.TablaSecundaria = "Columna";
            columnaTabla.ColumnaSecundaria = "FK_Tabla";
            columnaTabla.TablaPrincipal = "Tabla";
            columnaTabla.ColumnaPrincipal = "PK_Tabla";

            // Parametro => Comando
            Relacion parametroComando = Fabrica.Instancia.Crear<Relacion>();
            parametroComando.TipoAsociado = typeof(Comando).FullName;
            parametroComando.Propiedad = "Parametros";
            parametroComando.TablaSecundaria = "Parametro";
            parametroComando.ColumnaSecundaria = "FK_Comando";
            parametroComando.TablaPrincipal = "Comando";            
            parametroComando.ColumnaPrincipal = "PK_Comando";

            // ResultadoDescriptor => Comando
            Relacion resultadoDescriptorComando = Fabrica.Instancia.Crear<Relacion>();
            resultadoDescriptorComando.TipoAsociado = typeof(Comando).FullName;
            resultadoDescriptorComando.Propiedad = "ResultadoDescriptores";
            resultadoDescriptorComando.TablaSecundaria = "ResultadoDescriptor";
            resultadoDescriptorComando.ColumnaSecundaria = "FK_Comando";
            resultadoDescriptorComando.TablaPrincipal = "Comando";
            resultadoDescriptorComando.ColumnaPrincipal = "PK_Comando";
            

            _items.Add(uriEnsamblado);
            _items.Add(tipoUri);
            _items.Add(tipoTipoBase);
            _items.Add(propiedadTipoPropietario);
            _items.Add(propiedadTipoTipo);
            _items.Add(columnaTabla);
            _items.Add(parametroComando);
            _items.Add(resultadoDescriptorComando);

        }

        private void ConstruirComandos()
        {
            // listar ensamblado
            Comando listarEnsamblado = Fabrica.Instancia.Crear<Comando>();
            listarEnsamblado.Nombre = "listarEnsamblado";
            listarEnsamblado.Sql = "SELECT PK_Ensamblado as Clave, Nombre FROM Ensamblado";
            listarEnsamblado.ComandoTipo = ComandoTipo.QUERY;

            listarEnsamblado.CrearResultadoDescriptor("Clave", typeof(string));
            listarEnsamblado.CrearResultadoDescriptor("Nombre", typeof(string));

            // listar ensamblado por nombre
            Comando listarEnsambladoPorNombre = Fabrica.Instancia.Crear<Comando>();
            listarEnsambladoPorNombre.Nombre = "listarEnsambladoPorNombre";
            listarEnsambladoPorNombre.Sql = "SELECT PK_Ensamblado as Clave, Nombre FROM Ensamblado WHERE Nombre LIKE @nombre";
            listarEnsambladoPorNombre.ComandoTipo = ComandoTipo.QUERY;

            listarEnsambladoPorNombre.CrearParametro("nombre", typeof(string), 250);
            listarEnsambladoPorNombre.CrearResultadoDescriptor("Clave", typeof(string));
            listarEnsambladoPorNombre.CrearResultadoDescriptor("Nombre", typeof(string));


            // listar uri
            Comando listarUri = Fabrica.Instancia.Crear<Comando>();
            listarUri.Nombre = "listarUri";
            listarUri.Sql = "SELECT PK_Uri as Clave, Nombre FROM Uri";
            listarUri.ComandoTipo = ComandoTipo.QUERY;
            listarUri.CrearResultadoDescriptor("Clave", typeof(string));
            listarUri.CrearResultadoDescriptor("Nombre", typeof(string));

            // listar uri por ensamblado
            Comando listarUriPorEnsamblado = Fabrica.Instancia.Crear<Comando>();
            listarUriPorEnsamblado.Nombre = "listarUriPorEnsamblado";
            listarUriPorEnsamblado.Sql = "SELECT PK_Uri as Clave, Nombre FROM Uri WHERE FK_Ensamblado = @Ensamblado";
            listarUriPorEnsamblado.ComandoTipo = ComandoTipo.QUERY;            
            listarUriPorEnsamblado.CrearResultadoDescriptor("Clave", typeof(string));
            listarUriPorEnsamblado.CrearResultadoDescriptor("Nombre", typeof(string));
            listarUriPorEnsamblado.CrearParametro("Ensamblado", typeof(string), 250);

            // listar uri por nombre
            Comando listarUriPorNombre = Fabrica.Instancia.Crear<Comando>();
            listarUriPorNombre.Nombre = "listarUriPorNombre";
            listarUriPorNombre.Sql = "SELECT PK_Uri as Clave, Nombre FROM Uri WHERE Nombre LIKE @nombre";
            listarUriPorNombre.ComandoTipo = ComandoTipo.QUERY;
            listarUriPorNombre.CrearResultadoDescriptor("Clave", typeof(string));
            listarUriPorNombre.CrearResultadoDescriptor("Nombre", typeof(string));
            listarUriPorNombre.CrearParametro("nombre", typeof(string), 250);


            // listar tipo
            Comando listarTipo = Fabrica.Instancia.Crear<Comando>();
            listarTipo.Nombre = "listarTipo";
            listarTipo.Sql = "SELECT PK_Tipo as Clave, Nombre FROM Tipo";
            listarTipo.ComandoTipo = ComandoTipo.QUERY;            
            listarTipo.CrearResultadoDescriptor("Clave", typeof(string));
            listarTipo.CrearResultadoDescriptor("Nombre", typeof(string));

            // listar tipo por uri
            Comando listarTipoPorUri = Fabrica.Instancia.Crear<Comando>();
            listarTipoPorUri.Nombre = "listarTipoPorUri";
            listarTipoPorUri.Sql = "SELECT PK_Tipo as Clave, Nombre FROM Tipo WHERE FK_Uri = @Uri";
            listarTipoPorUri.ComandoTipo = ComandoTipo.QUERY;
            listarTipoPorUri.CrearParametro("Uri", typeof(string), 250);
            listarTipoPorUri.CrearResultadoDescriptor("Clave", typeof(string));
            listarTipoPorUri.CrearResultadoDescriptor("Nombre", typeof(string));

            // listar tipo por nombre 
            Comando listarTipoPorNombre = Fabrica.Instancia.Crear<Comando>();
            listarTipoPorNombre.Nombre = "listarTipoPorNombre";
            listarTipoPorNombre.Sql = "SELECT PK_Tipo as Clave, Nombre FROM Tipo WHERE Nombre LIKE @nombre";
            listarTipoPorNombre.ComandoTipo = ComandoTipo.QUERY;
            listarTipoPorNombre.CrearResultadoDescriptor("Clave", typeof(string));
            listarTipoPorNombre.CrearResultadoDescriptor("Nombre", typeof(string));
            listarTipoPorNombre.CrearParametro("nombre", typeof(string), 250);


            // listar propiedad
            Comando listarPropiedad = Fabrica.Instancia.Crear<Comando>();
            listarPropiedad.Nombre = "listarPropiedad";
            listarPropiedad.Sql = "SELECT PK_Propiedad as Clave, Nombre FROM Propiedad";
            listarPropiedad.ComandoTipo = ComandoTipo.QUERY;
            listarPropiedad.CrearResultadoDescriptor("Clave", typeof(string));
            listarPropiedad.CrearResultadoDescriptor("Nombre", typeof(string));

            // listar propiedad por tipo
            Comando listarPropiedadPorTipo = Fabrica.Instancia.Crear<Comando>();
            listarPropiedadPorTipo.Nombre = "listarPropiedadPorTipo";
            listarPropiedadPorTipo.Sql = "SELECT PK_Propiedad as Clave, Nombre FROM Propiedad WHERE FK_Tipo_Propietario = @Tipo";
            listarPropiedadPorTipo.ComandoTipo = ComandoTipo.QUERY;
            listarPropiedadPorTipo.CrearParametro("Tipo", typeof(string), 250);
            listarPropiedadPorTipo.CrearResultadoDescriptor("Clave", typeof(string));
            listarPropiedadPorTipo.CrearResultadoDescriptor("Nombre", typeof(string));

            // listar propiedad por nombre 
            Comando listarPropiedadPorNombre = Fabrica.Instancia.Crear<Comando>();
            listarPropiedadPorNombre.Nombre = "listarPropiedadPorNombre";
            listarPropiedadPorNombre.Sql = "SELECT PK_Propiedad as Clave, Nombre FROM Propiedad WHERE Nombre LIKE @nombre";
            listarPropiedadPorNombre.ComandoTipo = ComandoTipo.QUERY;
            listarPropiedadPorNombre.CrearResultadoDescriptor("Clave", typeof(string));
            listarPropiedadPorNombre.CrearResultadoDescriptor("Nombre", typeof(string));
            listarPropiedadPorNombre.CrearParametro("nombre", typeof(string), 250);

            // listar contexto
            Comando listarContexto = Fabrica.Instancia.Crear<Comando>();
            listarContexto.Nombre = "listarContexto";
            listarContexto.Sql = "SELECT PK_Contexto as Clave, Nombre FROM Contexto";
            listarContexto.ComandoTipo = ComandoTipo.QUERY;
            listarContexto.CrearResultadoDescriptor("Clave", typeof(string));
            listarContexto.CrearResultadoDescriptor("Nombre", typeof(string));
            
            // listar conexion
            Comando listarConexion = Fabrica.Instancia.Crear<Comando>();
            listarConexion.Nombre = "listarConexion";
            listarConexion.Sql = "SELECT PK_Conexion as Clave, Nombre FROM Conexion";
            listarConexion.ComandoTipo = ComandoTipo.QUERY;
            listarConexion.CrearResultadoDescriptor("Clave", typeof(string));
            listarConexion.CrearResultadoDescriptor("Nombre", typeof(string));

            // listar conexion
            Comando listarConexionPorNombre = Fabrica.Instancia.Crear<Comando>();
            listarConexionPorNombre.Nombre = "listarConexionPorNombre";
            listarConexionPorNombre.Sql = "SELECT PK_Conexion as Clave, Nombre FROM Conexion WHERE Nombre LIKE @nombre";
            listarConexionPorNombre.ComandoTipo = ComandoTipo.QUERY;
            listarConexionPorNombre.CrearResultadoDescriptor("Clave", typeof(string));
            listarConexionPorNombre.CrearResultadoDescriptor("Nombre", typeof(string));
            listarConexionPorNombre.CrearParametro("nombre", typeof(string), 250);


            // listar tabla
            Comando listarTabla = Fabrica.Instancia.Crear<Comando>();
            listarTabla.Nombre = "listarTabla";
            listarTabla.Sql = "SELECT PK_Tabla as Clave, Nombre FROM Tabla";
            listarTabla.ComandoTipo = ComandoTipo.QUERY;
            listarTabla.CrearResultadoDescriptor("Clave", typeof(string));
            listarTabla.CrearResultadoDescriptor("Nombre", typeof(string));
            
            // listar tabla por nombre 
            Comando listarTablaPorNombre = Fabrica.Instancia.Crear<Comando>();
            listarTablaPorNombre.Nombre = "listarTablaPorNombre";
            listarTablaPorNombre.Sql = "SELECT PK_Tabla as Clave, Nombre FROM Tabla WHERE Nombre LIKE @nombre";
            listarTablaPorNombre.ComandoTipo = ComandoTipo.QUERY;
            listarTablaPorNombre.CrearResultadoDescriptor("Clave", typeof(string));
            listarTablaPorNombre.CrearResultadoDescriptor("Nombre", typeof(string));
            listarTablaPorNombre.CrearParametro("nombre", typeof(string), 250);


            // listar columna
            Comando listarColumna = Fabrica.Instancia.Crear<Comando>();
            listarColumna.Nombre = "listarColumna";
            listarColumna.Sql = "SELECT PK_Columna as Clave, Nombre FROM Columna";
            listarColumna.ComandoTipo = ComandoTipo.QUERY;
            listarColumna.CrearResultadoDescriptor("Clave", typeof(string));
            listarColumna.CrearResultadoDescriptor("Nombre", typeof(string));

            // listar columna por tabla
            Comando listarColumnaPorTabla = Fabrica.Instancia.Crear<Comando>();
            listarColumnaPorTabla.Nombre = "listarColumnaPorTabla";
            listarColumnaPorTabla.Sql = "SELECT PK_Columna as Clave, Nombre FROM Columna WHERE FK_Tabla = @Tabla";
            listarColumnaPorTabla.ComandoTipo = ComandoTipo.QUERY;
            listarColumnaPorTabla.CrearParametro("Tabla", typeof(string), 250);
            listarColumnaPorTabla.CrearResultadoDescriptor("Clave", typeof(string));
            listarColumnaPorTabla.CrearResultadoDescriptor("Nombre", typeof(string));

            // listar columna por nombre 
            Comando listarColumnaPorNombre = Fabrica.Instancia.Crear<Comando>();
            listarColumnaPorNombre.Nombre = "listarColumnaPorNombre";
            listarColumnaPorNombre.Sql = "SELECT PK_Columna as Clave, Nombre FROM Columna WHERE Nombre LIKE @nombre";
            listarColumnaPorNombre.ComandoTipo = ComandoTipo.QUERY;
            listarColumnaPorNombre.CrearResultadoDescriptor("Clave", typeof(string));
            listarColumnaPorNombre.CrearResultadoDescriptor("Nombre", typeof(string));
            listarColumnaPorNombre.CrearParametro("nombre", typeof(string), 250);


            // listar relacion
            Comando listarRelacion = Fabrica.Instancia.Crear<Comando>();
            listarRelacion.Nombre = "listarRelacion";
            listarRelacion.Sql = "SELECT PK_Relacion as Clave, Nombre FROM Relacion";
            listarRelacion.ComandoTipo = ComandoTipo.QUERY;
            listarRelacion.CrearResultadoDescriptor("Clave", typeof(string));
            listarRelacion.CrearResultadoDescriptor("Nombre", typeof(string));
            
            // listar relacion por nombre 
            Comando listarRelacionPorNombre = Fabrica.Instancia.Crear<Comando>();
            listarRelacionPorNombre.Nombre = "listarRelacionPorNombre";
            listarRelacionPorNombre.Sql = "SELECT PK_Relacion as Clave, Nombre FROM Relacion WHERE Nombre LIKE @nombre";
            listarRelacionPorNombre.ComandoTipo = ComandoTipo.QUERY;
            listarRelacionPorNombre.CrearResultadoDescriptor("Clave", typeof(string));
            listarRelacionPorNombre.CrearResultadoDescriptor("Nombre", typeof(string));
            listarRelacionPorNombre.CrearParametro("nombre", typeof(string), 250);

            // listar comando
            Comando listarComando = Fabrica.Instancia.Crear<Comando>();
            listarComando.Nombre = "listarComando";
            listarComando.Sql = "SELECT PK_Comando as Clave, Nombre FROM Comando";
            listarComando.CrearResultadoDescriptor("Clave", typeof(string));
            listarComando.CrearResultadoDescriptor("Nombre", typeof(string));

            // listar parametro por comando
            Comando listarParametroPorComando = Fabrica.Instancia.Crear<Comando>();
            listarParametroPorComando.Nombre = "listarParametroPorComando";
            listarParametroPorComando.Sql = "SELECT PK_Parametro as Clave, Nombre FROM Parametro WHERE FK_Comando = @Comando";
            listarParametroPorComando.ComandoTipo = ComandoTipo.QUERY;
            listarParametroPorComando.CrearResultadoDescriptor("Clave", typeof(string));
            listarParametroPorComando.CrearResultadoDescriptor("Nombre", typeof(string));
            listarParametroPorComando.CrearParametro("Comando", typeof(string), 250);

            // listar resultado descriptor por comando
            Comando listarResultadoDescriptorPorComando = Fabrica.Instancia.Crear<Comando>();
            listarResultadoDescriptorPorComando.Nombre = "listarResultadoDescriptorPorComando";
            listarResultadoDescriptorPorComando.Sql = "SELECT PK_ResultadoDescriptor as Clave, Nombre FROM ResultadoDescriptor WHERE FK_Comando = @Comando";
            listarResultadoDescriptorPorComando.ComandoTipo = ComandoTipo.QUERY;
            listarResultadoDescriptorPorComando.CrearResultadoDescriptor("Clave", typeof(string));
            listarResultadoDescriptorPorComando.CrearResultadoDescriptor("Nombre", typeof(string));
            listarResultadoDescriptorPorComando.CrearParametro("Comando", typeof(string), 250);


            // agregar comandos
            _items.Add(listarEnsamblado);
            _items.Add(listarEnsambladoPorNombre);

            _items.Add(listarUri);
            _items.Add(listarUriPorEnsamblado);
            _items.Add(listarUriPorNombre);

            _items.Add(listarTipo);
            _items.Add(listarTipoPorUri);
            _items.Add(listarTipoPorNombre);

            _items.Add(listarPropiedad);
            _items.Add(listarPropiedadPorTipo);
            _items.Add(listarPropiedadPorNombre);

            _items.Add(listarContexto);

            _items.Add(listarConexion);
            _items.Add(listarConexionPorNombre);

            _items.Add(listarTabla);
            _items.Add(listarTablaPorNombre);

            _items.Add(listarColumna);
            _items.Add(listarColumnaPorTabla);
            _items.Add(listarColumnaPorNombre);

            _items.Add(listarRelacion);
            _items.Add(listarRelacionPorNombre);

            _items.Add(listarComando);
            _items.Add(listarParametroPorComando);
            _items.Add(listarResultadoDescriptorPorComando);

        }
        #endregion


        #region Propiedades
        public static ConfiguracionRepositorio Instancia
        {
            get;
        }

        public IEnumerable<Comando> Comandos
        {
            get => _items.OfType<Comando>();
        }
        
        public IEnumerable<Relacion> Relaciones
        {
            get => _items.OfType<Relacion>();
        }

        public IEnumerable<Tabla> Tablas
        {
            get => _items.OfType<Tabla>();
        }

        public IEnumerable<Tipo> Tipos
        {
            get => _items.OfType<Tipo>();
        }
        #endregion

    }
}
