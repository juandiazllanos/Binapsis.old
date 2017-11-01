namespace Binapsis.Plataforma.Configuracion.Presentacion.Win.Vistas
{
    partial class VistaTabla
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
            this.Nombre = new Binapsis.Presentacion.Editores.Win.EditorTexto();
            this.Tipo = new Binapsis.Presentacion.Editores.Win.EditorTexto();
            this.SuspendLayout();
            // 
            // Nombre
            // 
            this.Nombre.Etiqueta.Texto = "Nombre";
            this.Nombre.Location = new System.Drawing.Point(42, 29);
            this.Nombre.Name = "Nombre";
            this.Nombre.Size = new System.Drawing.Size(354, 20);
            this.Nombre.TabIndex = 0;
            // 
            // Tipo
            // 
            this.Tipo.Etiqueta.Texto = "Tipo";
            this.Tipo.Location = new System.Drawing.Point(42, 55);
            this.Tipo.Name = "Tipo";
            this.Tipo.Size = new System.Drawing.Size(354, 20);
            this.Tipo.TabIndex = 1;
            // 
            // VistaTabla
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Tipo);
            this.Controls.Add(this.Nombre);
            this.Name = "VistaTabla";
            this.Size = new System.Drawing.Size(431, 107);
            this.UsarReflexion = false;
            this.ResumeLayout(false);

        }

        #endregion

        private Binapsis.Presentacion.Editores.Win.EditorTexto Nombre;
        private Binapsis.Presentacion.Editores.Win.EditorTexto Tipo;
    }
}
