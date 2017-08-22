using Binapsis.Plataforma.Configuracion;
using Binapsis.Plataforma.Estructura;
using System;
using System.Collections.Generic;
using System.Linq;
using EspacioNombre = Binapsis.Plataforma.Configuracion.Uri;

namespace Binapsis.Plataforma.Test.Datos.Impl
{
    class ConfiguracionRepositorio
    {
        List<ConfiguracionBase> _items;
        string _espacioNombre = "Binapsis.Plataforma.Test.Modelo";

        static ConfiguracionRepositorio()
        {
            Instancia = new ConfiguracionRepositorio();
        }

        private ConfiguracionRepositorio()
        {
            // instanciar cache 
            _items = new List<ConfiguracionBase>();

            Construir();
        }

        private void Construir()
        {
            // construir tipos
            ConstruirTipos();
            // construir tablas
            ConstruirTablas();
            // construir relaciones
            ConstruirRelaciones();
            // construir comandos
            ConstruirComandos();
        }

        private void ConstruirComandos()
        {
            Comando crearId = Fabrica.Instancia.Crear<Comando>();
            crearId.Nombre = "CrearId";
            crearId.Sql = "usp_CrearId";
            crearId.ComandoTipo = ComandoTipo.PROCEDURE;

            crearId.CrearParametro("clave", typeof(string), 250);
            crearId.CrearParametro("id", typeof(int), "OUT");

            _items.Add(crearId);
        }

        private void ConstruirTipos()
        {
            Fabrica fabrica = Fabrica.Instancia;
            Types types = Types.Instancia;

            Ensamblado ensamblado = fabrica.Crear<Ensamblado>();
            EspacioNombre espacioNombre = fabrica.Crear<EspacioNombre>();

            ensamblado.Nombre = "Binapsis.Plataforma.Test";

            espacioNombre.Ensamblado = ensamblado;
            espacioNombre.Nombre = _espacioNombre;

            // departamento
            Tipo tipoDepartamento = fabrica.Crear<Tipo>();
            tipoDepartamento.Uri = espacioNombre;
            tipoDepartamento.Nombre = "Departamento";

            tipoDepartamento.CrearPropiedad("Id", types.Obtener(typeof(int)), "id");
            tipoDepartamento.CrearPropiedad("Nombre", types.Obtener(typeof(string)), "nombre");

            // provincia
            Tipo tipoProvincia = fabrica.Crear<Tipo>();
            tipoProvincia.Uri = espacioNombre;
            tipoProvincia.Nombre = "Provincia";

            tipoProvincia.CrearPropiedad("Id", types.Obtener(typeof(int)), "id");
            tipoProvincia.CrearPropiedad("Nombre", types.Obtener(typeof(string)), "nombre");

            // distrito
            Tipo tipoDistrito = fabrica.Crear<Tipo>();
            tipoDistrito.Uri = espacioNombre;
            tipoDistrito.Nombre = "Distrito";

            tipoDistrito.CrearPropiedad("Id", types.Obtener(typeof(int)), "id");
            tipoDistrito.CrearPropiedad("Nombre", types.Obtener(typeof(string)), "nombre");

            // ubigeo
            Tipo tipoUbigeo = fabrica.Crear<Tipo>();
            tipoUbigeo.Uri = espacioNombre;
            tipoUbigeo.Nombre = "Ubigeo";

            tipoUbigeo.CrearPropiedad("Id", types.Obtener(typeof(int)), "id");
            tipoUbigeo.CrearPropiedad("Codigo", types.Obtener(typeof(string)), "codigo");

            Propiedad refDepartamento = tipoUbigeo.CrearPropiedad("Departamento", tipoDepartamento, "departamento");
            refDepartamento.Asociacion = Asociacion.Agregacion;
            refDepartamento.Cardinalidad = Cardinalidad.Uno;

            Propiedad refProvincia = tipoUbigeo.CrearPropiedad("Provincia", tipoProvincia, "provincia");
            refProvincia.Asociacion = Asociacion.Agregacion;
            refProvincia.Cardinalidad = Cardinalidad.Uno;

            Propiedad refDistrito = tipoUbigeo.CrearPropiedad("Distrito", tipoDistrito, "distrito");
            refDistrito.Asociacion = Asociacion.Agregacion;
            refDistrito.Cardinalidad = Cardinalidad.Uno;
            
            // direccion
            Tipo tipoDireccion = fabrica.Crear<Tipo>();
            tipoDireccion.Nombre = "Direccion";
            tipoDireccion.Uri = espacioNombre;

            tipoDireccion.CrearPropiedad("Id", types.Obtener(typeof(int)), "id");
            tipoDireccion.CrearPropiedad("Descripcion", types.Obtener(typeof(string)));

            Propiedad refUbigeo = tipoDireccion.CrearPropiedad("Ubigeo", tipoUbigeo, "ubigeo");
            refUbigeo.Asociacion = Asociacion.Agregacion;
            refUbigeo.Cardinalidad = Cardinalidad.Uno;
            
            // cliente
            Tipo tipoCliente = fabrica.Crear<Tipo>();
            tipoCliente.Nombre = "Cliente";
            tipoCliente.Uri = espacioNombre;

            tipoCliente.CrearPropiedad("Id", types.Obtener(typeof(int)), "id");
            tipoCliente.CrearPropiedad("Nombres", types.Obtener(typeof(string)), "nombres");

            Propiedad refDireccion = tipoCliente.CrearPropiedad("Direcciones", tipoDireccion);
            refDireccion.Asociacion = Asociacion.Composicion;
            refDireccion.Cardinalidad = Cardinalidad.CeroAMuchos;


            // itemPedido
            Tipo tipoItemPedido = fabrica.Crear<Tipo>();
            tipoItemPedido.Nombre = "ItemPedido";
            tipoItemPedido.Uri = espacioNombre;

            tipoItemPedido.CrearPropiedad("Cantidad", types.Obtener(typeof(int)), "cantidad");
            tipoItemPedido.CrearPropiedad("Descripcion", types.Obtener(typeof(string)), "descripcion");
            tipoItemPedido.CrearPropiedad("Precio", types.Obtener(typeof(double)), "precio");
            tipoItemPedido.CrearPropiedad("Total", types.Obtener(typeof(double)), "total");

            // pedido
            Tipo tipoPedido = fabrica.Crear<Tipo>();
            tipoPedido.Nombre = "Pedido";
            tipoPedido.Uri = espacioNombre;

            tipoPedido.CrearPropiedad("Fecha", types.Obtener(typeof(DateTime)), "fecha");
            tipoPedido.CrearPropiedad("Total", types.Obtener(typeof(double)), "total");

            Propiedad propiedadCliente = tipoPedido.CrearPropiedad("Cliente", tipoCliente, "cliente");
            propiedadCliente.Asociacion = Asociacion.Agregacion;
            propiedadCliente.Cardinalidad = Cardinalidad.Uno;

            Propiedad propiedadItems = tipoPedido.CrearPropiedad("Items", tipoItemPedido, "Items");
            propiedadItems.Asociacion = Asociacion.Composicion;
            propiedadItems.Cardinalidad = Cardinalidad.CeroAMuchos;

            _items.AddRange(new ConfiguracionBase[]
                {
                    tipoDepartamento,
                    tipoProvincia,
                    tipoDistrito,
                    tipoUbigeo,
                    tipoDireccion,
                    tipoCliente,
                    tipoPedido, 
                    tipoItemPedido
                });
        }

        private void ConstruirTablas()
        {
            Fabrica fabrica = Fabrica.Instancia;

            // Tabla = DEPARTAMENTO
            Tabla tablaDepartamento = fabrica.Crear<Tabla>();
            tablaDepartamento.Nombre = "DEPARTAMENTO";
            tablaDepartamento.TipoAsociado = $"{_espacioNombre}.Departamento";

            tablaDepartamento.CrearColumna("ID", "Id", true);
            tablaDepartamento.CrearColumna("NOMBRE", "Nombre");

            // Tabla = PROVINCIA
            Tabla tablaProvincia = fabrica.Crear<Tabla>();
            tablaProvincia.Nombre = "PROVINCIA";
            tablaProvincia.TipoAsociado = $"{_espacioNombre}.Provincia";

            tablaProvincia.CrearColumna("ID", "Id", true);
            tablaProvincia.CrearColumna("NOMBRE", "Nombre");

            // Tabla = DISTRITO
            Tabla tablaDistrito = fabrica.Crear<Tabla>();
            tablaDistrito.Nombre = "DISTRITO";
            tablaDistrito.TipoAsociado = $"{_espacioNombre}.Distrito";

            tablaDistrito.CrearColumna("ID", "Id", true);
            tablaDistrito.CrearColumna("NOMBRE", "Nombre");

            // Tabla = UBIGEO
            Tabla tablaUbigeo = fabrica.Crear<Tabla>();
            tablaUbigeo.Nombre = "UBIGEO";
            tablaUbigeo.TipoAsociado = $"{_espacioNombre}.Ubigeo";

            tablaUbigeo.CrearColumna("ID", "Id", true);
            tablaUbigeo.CrearColumna("CODIGO", "Codigo");
            

            // Tabla = CLIENTE
            Tabla tablaCliente = fabrica.Crear<Tabla>();
            tablaCliente.Nombre = "CLIENTE";
            tablaCliente.TipoAsociado = $"{_espacioNombre}.Cliente";

            tablaCliente.CrearColumna("ID", "Id", true);
            tablaCliente.CrearColumna("NOMBRES", "Nombres");

            // Tabla = DIRECCION
            Tabla tablaDireccion = fabrica.Crear<Tabla>();
            tablaDireccion.Nombre = "DIRECCION";
            tablaDireccion.TipoAsociado = $"{_espacioNombre}.Direccion";

            tablaDireccion.CrearColumna("ID", "Id", true);
            tablaDireccion.CrearColumna("DESCRIPCION", "Descripcion");
            
            // agregar tablas
            _items.Add(tablaDepartamento);
            _items.Add(tablaProvincia);
            _items.Add(tablaDistrito);
            _items.Add(tablaUbigeo);
            _items.Add(tablaDireccion);
            _items.Add(tablaCliente);
                        
        }

        private void ConstruirRelaciones()
        {
            Fabrica fabrica = Fabrica.Instancia;

            // RELACION UBIGEO=>DEPARTAMENTO
            Relacion relacionUbigeoDepartamento = fabrica.Crear<Relacion>();
            relacionUbigeoDepartamento.TipoAsociado = $"{_espacioNombre}.Ubigeo";
            relacionUbigeoDepartamento.Propiedad = "Departamento";
            relacionUbigeoDepartamento.TablaPrincipal = "DEPARTAMENTO";
            relacionUbigeoDepartamento.TablaSecundaria = "UBIGEO";
            relacionUbigeoDepartamento.ColumnaPrincipal = "ID";
            relacionUbigeoDepartamento.ColumnaSecundaria = "IDDEPARTAMENTO";

            // RELACION UBIGEO=>PROVINCIA
            Relacion relacionUbigeoProvincia = fabrica.Crear<Relacion>();
            relacionUbigeoProvincia.TipoAsociado = $"{_espacioNombre}.Ubigeo";
            relacionUbigeoProvincia.Propiedad = "Provincia";
            relacionUbigeoProvincia.TablaPrincipal = "PROVINCIA";
            relacionUbigeoProvincia.TablaSecundaria = "UBIGEO";
            relacionUbigeoProvincia.ColumnaPrincipal = "ID";
            relacionUbigeoProvincia.ColumnaSecundaria = "IDPROVINCIA";

            // RELACION UBIGEO=>DISTRITO
            Relacion relacionUbigeoDistrito = fabrica.Crear<Relacion>();
            relacionUbigeoDistrito.TipoAsociado = $"{_espacioNombre}.Ubigeo";
            relacionUbigeoDistrito.Propiedad = "Distrito";
            relacionUbigeoDistrito.TablaPrincipal = "DISTRITO";
            relacionUbigeoDistrito.TablaSecundaria = "UBIGEO";
            relacionUbigeoDistrito.ColumnaPrincipal = "ID";
            relacionUbigeoDistrito.ColumnaSecundaria = "IDDISTRITO";

            // RELACION DIRECCION=>UBIGEO
            Relacion relacionDireccionUbigeo = fabrica.Crear<Relacion>();
            relacionDireccionUbigeo.TipoAsociado = $"{_espacioNombre}.Direccion";
            relacionDireccionUbigeo.Propiedad = "Ubigeo";
            relacionDireccionUbigeo.TablaPrincipal = "UBIGEO";
            relacionDireccionUbigeo.ColumnaPrincipal = "ID";
            relacionDireccionUbigeo.TablaSecundaria = "DIRECCION";            
            relacionDireccionUbigeo.ColumnaSecundaria = "IDUBIGEO";

            // RELACION DIRECCION=>CLIENTE
            Relacion relacionDireccionCliente = fabrica.Crear<Relacion>();
            relacionDireccionCliente.TipoAsociado = $"{_espacioNombre}.Cliente";
            relacionDireccionCliente.Propiedad = "Direcciones";
            relacionDireccionCliente.TablaPrincipal = "CLIENTE";
            relacionDireccionCliente.ColumnaPrincipal = "ID";
            relacionDireccionCliente.TablaSecundaria = "DIRECCION";
            relacionDireccionCliente.ColumnaSecundaria = "IDCLIENTE";


            // agregar relaciones
            _items.Add(relacionUbigeoDepartamento);
            _items.Add(relacionUbigeoProvincia);
            _items.Add(relacionUbigeoDistrito);
            _items.Add(relacionDireccionUbigeo);
            _items.Add(relacionDireccionCliente);



        }

        public static ConfiguracionRepositorio Instancia
        {
            get;
        }

        public IEnumerable<Tabla> Tablas
        {
            get => _items.OfType<Tabla>();
        }

        public IEnumerable<Relacion> Relaciones
        {
            get => _items.OfType<Relacion>();
        }

        public IEnumerable<Tipo> Tipos
        {
            get => _items.OfType<Tipo>();
        }

        public IEnumerable<Comando> Comandos
        {
            get => _items.OfType<Comando>();
        }
    }
}
