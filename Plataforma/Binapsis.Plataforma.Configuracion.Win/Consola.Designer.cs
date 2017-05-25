namespace Binapsis.Plataforma.Configuracion.Win
{
    partial class Consola
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Consola));
            this.estadoMain = new System.Windows.Forms.StatusStrip();
            this.menuMain = new System.Windows.Forms.MenuStrip();
            this.menuAccion = new System.Windows.Forms.ToolStripMenuItem();
            this.menuAccionNuevo = new System.Windows.Forms.ToolStripMenuItem();
            this.menuAccionEditar = new System.Windows.Forms.ToolStripMenuItem();
            this.menuAccionEliminar = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.menuAccionSalir = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tvwDefinicion = new System.Windows.Forms.TreeView();
            this.imagenes = new System.Windows.Forms.ImageList(this.components);
            this.lvwDefinicion = new System.Windows.Forms.ListView();
            this.colNombre = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colValor = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colAlias = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contexto = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.contextoAccionNuevo = new System.Windows.Forms.ToolStripMenuItem();
            this.contextoAccionEditar = new System.Windows.Forms.ToolStripMenuItem();
            this.contextoAccionEliminar = new System.Windows.Forms.ToolStripMenuItem();
            this.toolMain = new System.Windows.Forms.ToolStrip();
            this.toolAccionNuevo = new System.Windows.Forms.ToolStripButton();
            this.toolAccionEditar = new System.Windows.Forms.ToolStripButton();
            this.toolAccionEliminar = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolAccionActualizar = new System.Windows.Forms.ToolStripButton();
            this.estadoConfiguracion = new System.Windows.Forms.ToolStripStatusLabel();
            this.estadoContexto = new System.Windows.Forms.ToolStripStatusLabel();
            this.estadoMain.SuspendLayout();
            this.menuMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.contexto.SuspendLayout();
            this.toolMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // estadoMain
            // 
            this.estadoMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.estadoConfiguracion,
            this.estadoContexto});
            this.estadoMain.Location = new System.Drawing.Point(0, 392);
            this.estadoMain.Name = "estadoMain";
            this.estadoMain.Size = new System.Drawing.Size(1046, 22);
            this.estadoMain.TabIndex = 3;
            this.estadoMain.Text = "statusStrip1";
            // 
            // menuMain
            // 
            this.menuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuAccion});
            this.menuMain.Location = new System.Drawing.Point(0, 0);
            this.menuMain.Name = "menuMain";
            this.menuMain.Size = new System.Drawing.Size(1046, 24);
            this.menuMain.TabIndex = 4;
            this.menuMain.Text = "menuStrip1";
            // 
            // menuAccion
            // 
            this.menuAccion.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuAccionNuevo,
            this.menuAccionEditar,
            this.menuAccionEliminar,
            this.toolStripMenuItem2,
            this.menuAccionSalir});
            this.menuAccion.Name = "menuAccion";
            this.menuAccion.Size = new System.Drawing.Size(56, 20);
            this.menuAccion.Text = "Accion";
            // 
            // menuAccionNuevo
            // 
            this.menuAccionNuevo.Image = ((System.Drawing.Image)(resources.GetObject("menuAccionNuevo.Image")));
            this.menuAccionNuevo.Name = "menuAccionNuevo";
            this.menuAccionNuevo.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.menuAccionNuevo.Size = new System.Drawing.Size(175, 22);
            this.menuAccionNuevo.Text = "Nuevo";
            // 
            // menuAccionEditar
            // 
            this.menuAccionEditar.Image = ((System.Drawing.Image)(resources.GetObject("menuAccionEditar.Image")));
            this.menuAccionEditar.Name = "menuAccionEditar";
            this.menuAccionEditar.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
            this.menuAccionEditar.Size = new System.Drawing.Size(175, 22);
            this.menuAccionEditar.Text = "Editar";
            // 
            // menuAccionEliminar
            // 
            this.menuAccionEliminar.Image = ((System.Drawing.Image)(resources.GetObject("menuAccionEliminar.Image")));
            this.menuAccionEliminar.Name = "menuAccionEliminar";
            this.menuAccionEliminar.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Delete)));
            this.menuAccionEliminar.Size = new System.Drawing.Size(175, 22);
            this.menuAccionEliminar.Text = "Eliminar";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(172, 6);
            // 
            // menuAccionSalir
            // 
            this.menuAccionSalir.Name = "menuAccionSalir";
            this.menuAccionSalir.Size = new System.Drawing.Size(175, 22);
            this.menuAccionSalir.Text = "Salir";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 64);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tvwDefinicion);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.lvwDefinicion);
            this.splitContainer1.Size = new System.Drawing.Size(1046, 328);
            this.splitContainer1.SplitterDistance = 380;
            this.splitContainer1.TabIndex = 5;
            // 
            // tvwDefinicion
            // 
            this.tvwDefinicion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvwDefinicion.ImageIndex = 0;
            this.tvwDefinicion.ImageList = this.imagenes;
            this.tvwDefinicion.Location = new System.Drawing.Point(0, 0);
            this.tvwDefinicion.Name = "tvwDefinicion";
            this.tvwDefinicion.SelectedImageIndex = 0;
            this.tvwDefinicion.Size = new System.Drawing.Size(380, 328);
            this.tvwDefinicion.TabIndex = 0;
            this.tvwDefinicion.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvwDefinicion_AfterSelect);
            // 
            // imagenes
            // 
            this.imagenes.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imagenes.ImageStream")));
            this.imagenes.TransparentColor = System.Drawing.Color.Transparent;
            this.imagenes.Images.SetKeyName(0, "Configuracion");
            this.imagenes.Images.SetKeyName(1, "Ensamblado");
            this.imagenes.Images.SetKeyName(2, "Tipo");
            this.imagenes.Images.SetKeyName(3, "Uri");
            this.imagenes.Images.SetKeyName(4, "Propiedad");
            // 
            // lvwDefinicion
            // 
            this.lvwDefinicion.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colNombre,
            this.colValor,
            this.colAlias});
            this.lvwDefinicion.ContextMenuStrip = this.contexto;
            this.lvwDefinicion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvwDefinicion.FullRowSelect = true;
            this.lvwDefinicion.GridLines = true;
            this.lvwDefinicion.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvwDefinicion.HideSelection = false;
            this.lvwDefinicion.Location = new System.Drawing.Point(0, 0);
            this.lvwDefinicion.MultiSelect = false;
            this.lvwDefinicion.Name = "lvwDefinicion";
            this.lvwDefinicion.Size = new System.Drawing.Size(662, 328);
            this.lvwDefinicion.SmallImageList = this.imagenes;
            this.lvwDefinicion.TabIndex = 1;
            this.lvwDefinicion.UseCompatibleStateImageBehavior = false;
            this.lvwDefinicion.View = System.Windows.Forms.View.Details;
            // 
            // colNombre
            // 
            this.colNombre.Text = "Nombre";
            this.colNombre.Width = 100;
            // 
            // colValor
            // 
            this.colValor.Text = "Valor";
            this.colValor.Width = 361;
            // 
            // colAlias
            // 
            this.colAlias.Text = "Alias";
            this.colAlias.Width = 188;
            // 
            // contexto
            // 
            this.contexto.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contextoAccionNuevo,
            this.contextoAccionEditar,
            this.contextoAccionEliminar});
            this.contexto.Name = "contexto";
            this.contexto.Size = new System.Drawing.Size(118, 70);
            // 
            // contextoAccionNuevo
            // 
            this.contextoAccionNuevo.Image = ((System.Drawing.Image)(resources.GetObject("contextoAccionNuevo.Image")));
            this.contextoAccionNuevo.Name = "contextoAccionNuevo";
            this.contextoAccionNuevo.Size = new System.Drawing.Size(117, 22);
            this.contextoAccionNuevo.Text = "Nuevo";
            // 
            // contextoAccionEditar
            // 
            this.contextoAccionEditar.Image = ((System.Drawing.Image)(resources.GetObject("contextoAccionEditar.Image")));
            this.contextoAccionEditar.Name = "contextoAccionEditar";
            this.contextoAccionEditar.Size = new System.Drawing.Size(117, 22);
            this.contextoAccionEditar.Text = "Editar";
            // 
            // contextoAccionEliminar
            // 
            this.contextoAccionEliminar.Image = ((System.Drawing.Image)(resources.GetObject("contextoAccionEliminar.Image")));
            this.contextoAccionEliminar.Name = "contextoAccionEliminar";
            this.contextoAccionEliminar.Size = new System.Drawing.Size(117, 22);
            this.contextoAccionEliminar.Text = "Eliminar";
            // 
            // toolMain
            // 
            this.toolMain.AutoSize = false;
            this.toolMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolAccionNuevo,
            this.toolAccionEditar,
            this.toolAccionEliminar,
            this.toolStripButton1,
            this.toolAccionActualizar});
            this.toolMain.Location = new System.Drawing.Point(0, 24);
            this.toolMain.Name = "toolMain";
            this.toolMain.Size = new System.Drawing.Size(1046, 40);
            this.toolMain.TabIndex = 6;
            // 
            // toolAccionNuevo
            // 
            this.toolAccionNuevo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolAccionNuevo.Image = ((System.Drawing.Image)(resources.GetObject("toolAccionNuevo.Image")));
            this.toolAccionNuevo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolAccionNuevo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolAccionNuevo.Name = "toolAccionNuevo";
            this.toolAccionNuevo.Size = new System.Drawing.Size(36, 37);
            this.toolAccionNuevo.ToolTipText = "Nuevo";
            // 
            // toolAccionEditar
            // 
            this.toolAccionEditar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolAccionEditar.Image = ((System.Drawing.Image)(resources.GetObject("toolAccionEditar.Image")));
            this.toolAccionEditar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolAccionEditar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolAccionEditar.Name = "toolAccionEditar";
            this.toolAccionEditar.Size = new System.Drawing.Size(36, 37);
            this.toolAccionEditar.Text = "toolStripButton2";
            this.toolAccionEditar.ToolTipText = "Editar";
            // 
            // toolAccionEliminar
            // 
            this.toolAccionEliminar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolAccionEliminar.Image = ((System.Drawing.Image)(resources.GetObject("toolAccionEliminar.Image")));
            this.toolAccionEliminar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolAccionEliminar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolAccionEliminar.Name = "toolAccionEliminar";
            this.toolAccionEliminar.Size = new System.Drawing.Size(36, 37);
            this.toolAccionEliminar.Text = "toolStripButton3";
            this.toolAccionEliminar.ToolTipText = "Eliminar";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(6, 40);
            // 
            // toolAccionActualizar
            // 
            this.toolAccionActualizar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolAccionActualizar.Image = ((System.Drawing.Image)(resources.GetObject("toolAccionActualizar.Image")));
            this.toolAccionActualizar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolAccionActualizar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolAccionActualizar.Name = "toolAccionActualizar";
            this.toolAccionActualizar.Size = new System.Drawing.Size(36, 37);
            this.toolAccionActualizar.Text = "toolStripButton2";
            this.toolAccionActualizar.ToolTipText = "Actualizar";
            // 
            // estadoConfiguracion
            // 
            this.estadoConfiguracion.Name = "estadoConfiguracion";
            this.estadoConfiguracion.Size = new System.Drawing.Size(900, 17);
            this.estadoConfiguracion.Spring = true;
            // 
            // estadoContexto
            // 
            this.estadoContexto.AutoSize = false;
            this.estadoContexto.Name = "estadoContexto";
            this.estadoContexto.Size = new System.Drawing.Size(100, 17);
            // 
            // Consola
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1046, 414);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.estadoMain);
            this.Controls.Add(this.toolMain);
            this.Controls.Add(this.menuMain);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainMenuStrip = this.menuMain;
            this.Name = "Consola";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Configuración";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.estadoMain.ResumeLayout(false);
            this.estadoMain.PerformLayout();
            this.menuMain.ResumeLayout(false);
            this.menuMain.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.contexto.ResumeLayout(false);
            this.toolMain.ResumeLayout(false);
            this.toolMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip estadoMain;
        private System.Windows.Forms.MenuStrip menuMain;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView tvwDefinicion;
        private System.Windows.Forms.ListView lvwDefinicion;
        private System.Windows.Forms.ColumnHeader colNombre;
        private System.Windows.Forms.ColumnHeader colValor;
        private System.Windows.Forms.ColumnHeader colAlias;
        private System.Windows.Forms.ToolStripMenuItem menuAccion;
        private System.Windows.Forms.ToolStripMenuItem menuAccionNuevo;
        private System.Windows.Forms.ToolStripMenuItem menuAccionEditar;
        private System.Windows.Forms.ToolStripMenuItem menuAccionEliminar;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem menuAccionSalir;
        private System.Windows.Forms.ToolStrip toolMain;
        private System.Windows.Forms.ToolStripButton toolAccionNuevo;
        private System.Windows.Forms.ToolStripButton toolAccionEditar;
        private System.Windows.Forms.ToolStripButton toolAccionEliminar;
        private System.Windows.Forms.ContextMenuStrip contexto;
        private System.Windows.Forms.ToolStripMenuItem contextoAccionNuevo;
        private System.Windows.Forms.ToolStripMenuItem contextoAccionEditar;
        private System.Windows.Forms.ToolStripMenuItem contextoAccionEliminar;
        private System.Windows.Forms.ImageList imagenes;
        private System.Windows.Forms.ToolStripSeparator toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolAccionActualizar;
        private System.Windows.Forms.ToolStripStatusLabel estadoConfiguracion;
        private System.Windows.Forms.ToolStripStatusLabel estadoContexto;
    }
}

