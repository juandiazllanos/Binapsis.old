namespace Binapsis.Plataforma.Configuracion.Presentacion.Win
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.barMain = new DevExpress.XtraBars.BarManager(this.components);
            this.barBoton = new DevExpress.XtraBars.Bar();
            this.toolBotonCrear = new DevExpress.XtraBars.BarLargeButtonItem();
            this.toolBotonEditar = new DevExpress.XtraBars.BarLargeButtonItem();
            this.toolBotonEliminar = new DevExpress.XtraBars.BarLargeButtonItem();
            this.toolBotonActualizar = new DevExpress.XtraBars.BarLargeButtonItem();
            this.barMenu = new DevExpress.XtraBars.Bar();
            this.barSubItem1 = new DevExpress.XtraBars.BarSubItem();
            this.toolMenuCrear = new DevExpress.XtraBars.BarButtonItem();
            this.toolMenuEditar = new DevExpress.XtraBars.BarButtonItem();
            this.toolMenuEliminar = new DevExpress.XtraBars.BarButtonItem();
            this.toolMenuSalir = new DevExpress.XtraBars.BarButtonItem();
            this.barEstado = new DevExpress.XtraBars.Bar();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.imagenes16 = new System.Windows.Forms.ImageList(this.components);
            this.imagenes32 = new System.Windows.Forms.ImageList(this.components);
            this.splitMain = new DevExpress.XtraEditors.SplitContainerControl();
            this.tvwMain = new System.Windows.Forms.TreeView();
            this.imgElemento16 = new System.Windows.Forms.ImageList(this.components);
            this.lvwMain = new System.Windows.Forms.ListView();
            this.colCategoria = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colNombre = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMain = new DevExpress.XtraBars.PopupMenu(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.barMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitMain)).BeginInit();
            this.splitMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.contextMain)).BeginInit();
            this.SuspendLayout();
            // 
            // barMain
            // 
            this.barMain.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.barBoton,
            this.barMenu,
            this.barEstado});
            this.barMain.DockControls.Add(this.barDockControlTop);
            this.barMain.DockControls.Add(this.barDockControlBottom);
            this.barMain.DockControls.Add(this.barDockControlLeft);
            this.barMain.DockControls.Add(this.barDockControlRight);
            this.barMain.Form = this;
            this.barMain.Images = this.imagenes16;
            this.barMain.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barSubItem1,
            this.toolBotonCrear,
            this.toolBotonEditar,
            this.toolBotonEliminar,
            this.toolBotonActualizar,
            this.toolMenuCrear,
            this.toolMenuEditar,
            this.toolMenuEliminar,
            this.toolMenuSalir});
            this.barMain.LargeImages = this.imagenes32;
            this.barMain.MainMenu = this.barMenu;
            this.barMain.MaxItemId = 15;
            this.barMain.StatusBar = this.barEstado;
            // 
            // barBoton
            // 
            this.barBoton.BarName = "Tools";
            this.barBoton.DockCol = 0;
            this.barBoton.DockRow = 1;
            this.barBoton.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.barBoton.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.toolBotonCrear, DevExpress.XtraBars.BarItemPaintStyle.Standard),
            new DevExpress.XtraBars.LinkPersistInfo(this.toolBotonEditar),
            new DevExpress.XtraBars.LinkPersistInfo(this.toolBotonEliminar),
            new DevExpress.XtraBars.LinkPersistInfo(this.toolBotonActualizar, true)});
            this.barBoton.Text = "Tools";
            // 
            // toolBotonCrear
            // 
            this.toolBotonCrear.Id = 7;
            this.toolBotonCrear.ImageOptions.LargeImageIndex = 0;
            this.toolBotonCrear.Name = "toolBotonCrear";
            this.toolBotonCrear.ShowCaptionOnBar = false;
            this.toolBotonCrear.Tag = "Crear";
            // 
            // toolBotonEditar
            // 
            this.toolBotonEditar.Id = 8;
            this.toolBotonEditar.ImageOptions.LargeImageIndex = 1;
            this.toolBotonEditar.Name = "toolBotonEditar";
            this.toolBotonEditar.ShowCaptionOnBar = false;
            this.toolBotonEditar.Tag = "Editar";
            // 
            // toolBotonEliminar
            // 
            this.toolBotonEliminar.Id = 9;
            this.toolBotonEliminar.ImageOptions.LargeImageIndex = 2;
            this.toolBotonEliminar.Name = "toolBotonEliminar";
            this.toolBotonEliminar.ShowCaptionOnBar = false;
            this.toolBotonEliminar.Tag = "Eliminar";
            // 
            // toolBotonActualizar
            // 
            this.toolBotonActualizar.Id = 10;
            this.toolBotonActualizar.ImageOptions.LargeImageIndex = 3;
            this.toolBotonActualizar.Name = "toolBotonActualizar";
            this.toolBotonActualizar.ShowCaptionOnBar = false;
            this.toolBotonActualizar.Tag = "Actualizar";
            // 
            // barMenu
            // 
            this.barMenu.BarName = "Main menu";
            this.barMenu.DockCol = 0;
            this.barMenu.DockRow = 0;
            this.barMenu.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.barMenu.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barSubItem1)});
            this.barMenu.OptionsBar.MultiLine = true;
            this.barMenu.OptionsBar.UseWholeRow = true;
            this.barMenu.Text = "Main menu";
            // 
            // barSubItem1
            // 
            this.barSubItem1.Caption = "Accion";
            this.barSubItem1.Id = 0;
            this.barSubItem1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.toolMenuCrear),
            new DevExpress.XtraBars.LinkPersistInfo(this.toolMenuEditar),
            new DevExpress.XtraBars.LinkPersistInfo(this.toolMenuEliminar),
            new DevExpress.XtraBars.LinkPersistInfo(this.toolMenuSalir, true)});
            this.barSubItem1.Name = "barSubItem1";
            // 
            // toolMenuCrear
            // 
            this.toolMenuCrear.Caption = "Crear";
            this.toolMenuCrear.Id = 11;
            this.toolMenuCrear.ImageOptions.ImageIndex = 0;
            this.toolMenuCrear.Name = "toolMenuCrear";
            this.toolMenuCrear.Tag = "Crear";
            // 
            // toolMenuEditar
            // 
            this.toolMenuEditar.Caption = "Editar";
            this.toolMenuEditar.Id = 12;
            this.toolMenuEditar.ImageOptions.ImageIndex = 1;
            this.toolMenuEditar.Name = "toolMenuEditar";
            this.toolMenuEditar.Tag = "Editar";
            // 
            // toolMenuEliminar
            // 
            this.toolMenuEliminar.Caption = "Eliminar";
            this.toolMenuEliminar.Id = 13;
            this.toolMenuEliminar.ImageOptions.ImageIndex = 2;
            this.toolMenuEliminar.Name = "toolMenuEliminar";
            this.toolMenuEliminar.Tag = "Eliminar";
            // 
            // toolMenuSalir
            // 
            this.toolMenuSalir.Caption = "Salir";
            this.toolMenuSalir.Id = 14;
            this.toolMenuSalir.Name = "toolMenuSalir";
            // 
            // barEstado
            // 
            this.barEstado.BarName = "Status bar";
            this.barEstado.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.barEstado.DockCol = 0;
            this.barEstado.DockRow = 0;
            this.barEstado.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.barEstado.OptionsBar.AllowQuickCustomization = false;
            this.barEstado.OptionsBar.DrawDragBorder = false;
            this.barEstado.OptionsBar.UseWholeRow = true;
            this.barEstado.Text = "Status bar";
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barMain;
            this.barDockControlTop.Size = new System.Drawing.Size(892, 69);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 393);
            this.barDockControlBottom.Manager = this.barMain;
            this.barDockControlBottom.Size = new System.Drawing.Size(892, 23);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 69);
            this.barDockControlLeft.Manager = this.barMain;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 324);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(892, 69);
            this.barDockControlRight.Manager = this.barMain;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 324);
            // 
            // imagenes16
            // 
            this.imagenes16.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imagenes16.ImageStream")));
            this.imagenes16.TransparentColor = System.Drawing.Color.Transparent;
            this.imagenes16.Images.SetKeyName(0, "FileNew.png");
            this.imagenes16.Images.SetKeyName(1, "EditDocument.png");
            this.imagenes16.Images.SetKeyName(2, "DeclineTask.png");
            // 
            // imagenes32
            // 
            this.imagenes32.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imagenes32.ImageStream")));
            this.imagenes32.TransparentColor = System.Drawing.Color.Transparent;
            this.imagenes32.Images.SetKeyName(0, "Crear");
            this.imagenes32.Images.SetKeyName(1, "Editar");
            this.imagenes32.Images.SetKeyName(2, "Eliminar");
            this.imagenes32.Images.SetKeyName(3, "Refrescar");
            // 
            // splitMain
            // 
            this.splitMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitMain.Location = new System.Drawing.Point(0, 69);
            this.splitMain.Name = "splitMain";
            this.splitMain.Panel1.Controls.Add(this.tvwMain);
            this.splitMain.Panel1.Text = "Panel1";
            this.splitMain.Panel2.Controls.Add(this.lvwMain);
            this.splitMain.Panel2.Text = "Panel2";
            this.splitMain.Size = new System.Drawing.Size(892, 324);
            this.splitMain.SplitterPosition = 350;
            this.splitMain.TabIndex = 4;
            // 
            // tvwMain
            // 
            this.tvwMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tvwMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvwMain.FullRowSelect = true;
            this.tvwMain.HideSelection = false;
            this.tvwMain.ImageIndex = 0;
            this.tvwMain.ImageList = this.imgElemento16;
            this.tvwMain.Location = new System.Drawing.Point(0, 0);
            this.tvwMain.Name = "tvwMain";
            this.tvwMain.SelectedImageIndex = 0;
            this.tvwMain.Size = new System.Drawing.Size(350, 324);
            this.tvwMain.TabIndex = 5;
            // 
            // imgElemento16
            // 
            this.imgElemento16.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgElemento16.ImageStream")));
            this.imgElemento16.TransparentColor = System.Drawing.Color.Transparent;
            this.imgElemento16.Images.SetKeyName(0, "Categoria");
            this.imgElemento16.Images.SetKeyName(1, "Configuracion");
            this.imgElemento16.Images.SetKeyName(2, "Ensamblado");
            this.imgElemento16.Images.SetKeyName(3, "Tipo");
            this.imgElemento16.Images.SetKeyName(4, "Uri");
            this.imgElemento16.Images.SetKeyName(5, "Propiedad");
            this.imgElemento16.Images.SetKeyName(6, "Conexion");
            this.imgElemento16.Images.SetKeyName(7, "Tabla");
            this.imgElemento16.Images.SetKeyName(8, "Columna");
            this.imgElemento16.Images.SetKeyName(9, "Relacion");
            // 
            // lvwMain
            // 
            this.lvwMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lvwMain.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colCategoria,
            this.colNombre});
            this.lvwMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvwMain.FullRowSelect = true;
            this.lvwMain.GridLines = true;
            this.lvwMain.HideSelection = false;
            this.lvwMain.Location = new System.Drawing.Point(0, 0);
            this.lvwMain.MultiSelect = false;
            this.lvwMain.Name = "lvwMain";
            this.barMain.SetPopupContextMenu(this.lvwMain, this.contextMain);
            this.lvwMain.Size = new System.Drawing.Size(536, 324);
            this.lvwMain.SmallImageList = this.imgElemento16;
            this.lvwMain.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lvwMain.TabIndex = 0;
            this.lvwMain.UseCompatibleStateImageBehavior = false;
            this.lvwMain.View = System.Windows.Forms.View.Details;
            // 
            // colCategoria
            // 
            this.colCategoria.Text = "Categoria";
            this.colCategoria.Width = 165;
            // 
            // colNombre
            // 
            this.colNombre.Text = "Nombre";
            this.colNombre.Width = 352;
            // 
            // contextMain
            // 
            this.contextMain.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.toolMenuCrear),
            new DevExpress.XtraBars.LinkPersistInfo(this.toolMenuEditar),
            new DevExpress.XtraBars.LinkPersistInfo(this.toolMenuEliminar)});
            this.contextMain.Manager = this.barMain;
            this.contextMain.Name = "contextMain";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(892, 416);
            this.Controls.Add(this.splitMain);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.LookAndFeel.SkinName = "Office 2010 Blue";
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.Name = "Main";
            this.Text = "Main";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.barMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitMain)).EndInit();
            this.splitMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.contextMain)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarManager barMain;
        private DevExpress.XtraBars.Bar barBoton;
        private DevExpress.XtraBars.Bar barMenu;
        private DevExpress.XtraBars.Bar barEstado;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraEditors.SplitContainerControl splitMain;
        private System.Windows.Forms.TreeView tvwMain;
        private System.Windows.Forms.ListView lvwMain;
        private System.Windows.Forms.ImageList imgElemento16;
        private System.Windows.Forms.ImageList imagenes16;
        private DevExpress.XtraBars.BarSubItem barSubItem1;
        private System.Windows.Forms.ImageList imagenes32;
        private DevExpress.XtraBars.BarLargeButtonItem toolBotonCrear;
        private DevExpress.XtraBars.BarLargeButtonItem toolBotonEditar;
        private DevExpress.XtraBars.BarLargeButtonItem toolBotonEliminar;
        private DevExpress.XtraBars.BarLargeButtonItem toolBotonActualizar;
        private System.Windows.Forms.ColumnHeader colCategoria;
        private System.Windows.Forms.ColumnHeader colNombre;
        private DevExpress.XtraBars.BarButtonItem toolMenuCrear;
        private DevExpress.XtraBars.BarButtonItem toolMenuEditar;
        private DevExpress.XtraBars.BarButtonItem toolMenuEliminar;
        private DevExpress.XtraBars.BarButtonItem toolMenuSalir;
        private DevExpress.XtraBars.PopupMenu contextMain;
    }
}