namespace Binapsis.Plataforma.Configuracion.Presentacion.Win.Vistas
{
    partial class VistaSeleccionar
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

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.lvwClave = new System.Windows.Forms.ListView();
            this.colNombre = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // lvwClave
            // 
            this.lvwClave.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lvwClave.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colNombre});
            this.lvwClave.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvwClave.FullRowSelect = true;
            this.lvwClave.GridLines = true;
            this.lvwClave.HideSelection = false;
            this.lvwClave.Location = new System.Drawing.Point(3, 3);
            this.lvwClave.MultiSelect = false;
            this.lvwClave.Name = "lvwClave";
            this.lvwClave.Size = new System.Drawing.Size(301, 288);
            this.lvwClave.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lvwClave.TabIndex = 0;
            this.lvwClave.UseCompatibleStateImageBehavior = false;
            this.lvwClave.View = System.Windows.Forms.View.Details;
            // 
            // colNombre
            // 
            this.colNombre.Text = "Nombre";
            this.colNombre.Width = 282;
            // 
            // VistaSeleccionar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lvwClave);
            this.Name = "VistaSeleccionar";
            this.Size = new System.Drawing.Size(308, 294);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lvwClave;
        private System.Windows.Forms.ColumnHeader colNombre;
    }
}
