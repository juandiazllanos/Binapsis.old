using Binapsis.Plataforma.Configuracion.Win.Contextos;
using Binapsis.Plataforma.Configuracion.Win.Controladores;
using Binapsis.Plataforma.Configuracion.Win.Modelo;
using System;
using System.Windows.Forms;

namespace Binapsis.Plataforma.Configuracion.Win
{
    public partial class Consola : Form
    {
        public Consola()
        {
            InitializeComponent();
            Inicializar();
        }

        private void Inicializar()
        {
            //Definicion definicion = Recuperar(null);

            IRepositorio repositorio = new Repositorio(Config.Url);
            Elemento elemento = new ElementoRoot(repositorio);
            TreeNode nodo = new TreeNode() { Tag = elemento };
            // agregar nodo
            tvwDefinicion.Nodes.Add(nodo);
            // mostrar jerarquia
            VistaArbol vista = new VistaArbol(nodo, null);
            vista.Mostrar();

            
            
            // asignar controladores
            menuAccionEditar.Click += (s, e) => EjecutarAccionEditar();
            menuAccionNuevo.Click += (s, e) => EjecutarAccionCrear();
            menuAccionEliminar.Click += (s, e) => EjecutarAccionEliminar();

            contextoAccionEditar.Click += (s, e) => EjecutarAccionEditar(CrearContexto(s));
            contextoAccionEliminar.Click += (s, e) => EjecutarAccionEliminar(CrearContexto(s));
            contextoAccionNuevo.Click += (s, e) => EjecutarAccionCrear(CrearContexto(s));

            toolAccionEditar.Click += (s, e) => EjecutarAccionEditar();
            toolAccionEliminar.Click += (s, e) => EjecutarAccionEliminar();
            toolAccionNuevo.Click += (s, e) => EjecutarAccionCrear();
            toolAccionActualizar.Click += (s,e) => EjecutarAccionActualizar();

        }


        private void ControlarError(Exception error)
        {
            MessageBox.Show(this, error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
                
        private void EjecutarAccion(IContexto contexto, string accion)
        {
            IControlador controlador = null;

            try
            {
                controlador = new Controlador(contexto, new Accion() { Nombre = accion });
                controlador.Ejecutar();
            }
            catch(Exception ex)
            {
                ControlarError(ex);
            }
            
        }

        private IContexto CrearContexto()
        {
            return CrearContexto(null);
        }

        private IContexto CrearContexto(object sender)
        {
            IContexto contexto = null;

            MenuItem menuItem = (sender as MenuItem);
            ContextMenu menu = null;
            Control control = null;
            VistaElemento vista = null;
            Elemento elem = null;
            IRepositorio repositorio = null;

            if (menuItem != null)
                menu = menuItem.GetContextMenu();

            if (menu != null)
                control = menu.SourceControl;

            TreeNode nodoItem = tvwDefinicion.SelectedNode;
            ListViewItem filaItem = null;
            
            if (lvwDefinicion.SelectedItems.Count > 0)
                filaItem = lvwDefinicion.SelectedItems[0];

            elem = (nodoItem.Tag as Elemento);

            if (elem != null) repositorio = elem.Repositorio;

            vista = new VistaLista(lvwDefinicion, elem);
            vista = new VistaArbol(nodoItem, vista);
                        
            contexto = new ContextoLista(nodoItem, filaItem) { Vista = vista, Repositorio = repositorio };
            
            return contexto;
        }


        private void EjecutarAccionActualizar(IContexto contexto)
        {
            EjecutarAccion(contexto, "Actualizar");
        }

        private void EjecutarAccionCrear(IContexto contexto)
        {              
            EjecutarAccion(contexto, "Crear");
        }

        private void EjecutarAccionEditar(IContexto contexto)
        {
            EjecutarAccion(contexto, "Editar");
        }

        private void EjecutarAccionEliminar(IContexto contexto)
        {
            EjecutarAccion(contexto, "Eliminar");
        }


        private void EjecutarAccionActualizar()
        {
            EjecutarAccionActualizar(CrearContexto());
        }

        private void EjecutarAccionCrear()
        {
            EjecutarAccionCrear(CrearContexto());
        }

        private void EjecutarAccionEditar()
        {
            EjecutarAccionEditar(CrearContexto());
        }

        private void EjecutarAccionEliminar()
        {
            EjecutarAccionEliminar(CrearContexto());
        }


        private void tvwDefinicion_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                Elemento elemento = (e.Node?.Tag as Elemento);
                VistaLista vista = new VistaLista(lvwDefinicion, elemento);
                vista.Mostrar();

                estadoContexto.Text = $"{lvwDefinicion.Items.Count} items";
            }
            catch (Exception ex)
            {
                ControlarError(ex);
            }
        }
    }
}
