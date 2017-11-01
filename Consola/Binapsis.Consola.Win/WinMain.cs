using System.Drawing;
using System.Collections.Generic;
using System.Windows.Forms;

using DevExpress.XtraBars;
using DevExpress.XtraBars.Navigation;
using DevExpress.XtraNavBar;
using Binapsis.Consola.Navegacion;
using Binapsis.Consola.Estructura;
using Binapsis.Consola.Win.Controllers;

namespace Binapsis.Consola.Win
{
    public partial class WinMain : DevExpress.XtraEditors.XtraForm
    {        
        #region Constructores        
        public WinMain(Main main, Navegador navegador)
        {
            InitializeComponent();

            Navegador = navegador;
            Main = main;
                        
            Construir(navegador);

            // establecer controlador de página
            tabMain.PageAdded += (sender, e) => e.Page.Image = (e.Page.MdiChild as WinChild)?.Imagen;
        }
        #endregion


        #region Metodos
        public void Construir(Navegador navegador)
        {
            foreach (Elemento elemento in navegador.Categorias)
                ConstruirCategoria(elemento);

            foreach (Elemento elemento in navegador.Comandos)
                ConstruirComando(elemento);
        }

        private void ConstruirCategoria(Elemento elemento)
        {
            var navegadorGrupo = new NavBarGroup();
            var navegadorGrupoContenedor = new NavBarGroupControlContainer();
            var ctrl = new AccordionControl();
            var ctrlElemento = new AccordionControlElement();

            navegadorGrupoContenedor.SuspendLayout();
            ctrl.BeginUpdate();

            try
            {
                if (elemento is Grupo elementoGrupo)
                    ConstruirCategoria(ctrlElemento, elementoGrupo.Elementos);

                ctrlElemento.HeaderVisible = false;

                ctrl.Elements.Add(ctrlElemento);
                ctrl.AllowItemSelection = true;
                ctrl.ScrollBarMode = ScrollBarMode.Auto;
                ctrl.Dock = DockStyle.Fill;
                //ctrl.Images = imageSmallMain;

                navegadorGrupoContenedor.Controls.Add(ctrl);
                
                navegadorGrupo.Caption = elemento.Nombre;
                navegadorGrupo.GroupStyle = NavBarGroupStyle.ControlContainer;
                navegadorGrupo.ControlContainer = navegadorGrupoContenedor;
                navegadorGrupo.LargeImage = ObtenerImagen(elemento, 24); //1;

                navegadorMain.Controls.Add(navegadorGrupoContenedor);
                navegadorMain.Groups.Add(navegadorGrupo);
            }
            finally
            {
                navegadorGrupoContenedor.ResumeLayout();
                ctrl.EndUpdate();
            }

        }

        private void ConstruirCategoria(AccordionControlElement elemento, IEnumerable<Elemento> items)
        {
            foreach (Elemento item in items)
                if (item is Grupo itemGrupo)
                    ConstruirCategoria(elemento, itemGrupo);
                else if (item is Categoria itemCategoria)
                    ConstruirCategoria(elemento, itemCategoria);
        }

        private void ConstruirCategoria(AccordionControlElement elemento, Grupo grupo)
        {
            AccordionControlElement elementoGrupo = new AccordionControlElement();            
            elementoGrupo.Text = grupo.Nombre;
            elementoGrupo.Image = ObtenerImagen(grupo, 24);

            ConstruirCategoria(elementoGrupo, grupo.Elementos);

            elemento.Elements.Add(elementoGrupo);
        }

        private void ConstruirCategoria(AccordionControlElement elemento, Categoria categoria)
        {            
            AccordionControlElement elementoItem = new AccordionControlElement();
            elementoItem.Style = ElementStyle.Item;
            elementoItem.Text = categoria.Nombre;  
            elementoItem.Image = ObtenerImagen(categoria, 24);
            elementoItem.Tag = categoria;

            Nodo nodo;

            if (Main.Nodos.Existe(categoria))
                nodo = Main.Nodos.Obtener(categoria);
            else
                nodo = Main.Nodos.Crear(categoria);
           
            // crear controlador
            AcordeonItemController controller = new AcordeonItemController(nodo, elementoItem);
            nodo.Controller = controller;
            
            elemento.Elements.Add(elementoItem);
        }
        
        private void ConstruirComando(Elemento elemento)
        {
            if (elemento is Grupo grupo)
                ConstruirComando(grupo);
        }

        private void ConstruirComando(Grupo grupo)
        {
            Bar toolBar = new Bar { BarName = grupo.Nombre };

            foreach (Elemento elemento in grupo.Elementos)
                ConstruirComando(toolBar, elemento);

            barMain.Bars.Add(toolBar);
            
            toolBar.DockStyle = BarDockStyle.Top;
            toolBar.DockRow = 0;
        }

        private void ConstruirComando(Bar toolBar, Elemento elemento)
        {
            BarButtonItem item = new BarButtonItem();

            item.Caption = elemento.Nombre;
            item.Glyph = ObtenerImagen(elemento, 16);
            //item.LargeGlyph = ObtenerImagen(elemento, 32);

            toolBar.AddItem(item);

            Boton boton = Main.Botones.Crear(elemento);
            //boton.AccionInfo = Main.ConsolaInfo.Acciones[elemento.Nombre];

            ButtonItemController controller = new ButtonItemController(boton, item);
            boton.Controller = controller;

            //if (_baritems.ContainsKey(elemento.Nombre))
            //    _baritems.Add(elemento.Nombre, item);
        }

        //public void ConstruirMenuContextual(PopupMenu menu, Categoria categoria)
        //{
        //    ModeloInfo modeloInfo = Main.ConsolaInfo.Modelos.Obtener(categoria.Nombre);
        //    if (modeloInfo == null) return;

        //    foreach (AccionModeloInfo ami in modeloInfo.Acciones)
        //        if (_baritems.ContainsKey(ami.AccionInfo.Nombre))
        //            menu.AddItem(_baritems[ami.AccionInfo.Nombre]);

        //    menu.Manager = barMain;
        //}

        private Image ObtenerImagen(Elemento elemento, sbyte size)
        {
            Ruta ruta = new Ruta(elemento.Padre);
            return Main.Galeria?.Obtener(ruta.ToString(), elemento.Nombre, size);
        }
        #endregion


        #region Propiedades
        public Navegador Navegador
        {
            get;
        }
        
        public Main Main
        {
            get;
        }        

        public BarManager BarManager
        {
            get => barMain;
        }
        #endregion
    }
}