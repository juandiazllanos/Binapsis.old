namespace Binapsis.Plataforma.Configuracion.Presentacion.Win.Vistas
{
    partial class VistaParametro
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
            this.Direccion = new Binapsis.Presentacion.Editores.Win.EditorTexto();
            this.Longitud = new Binapsis.Presentacion.Editores.Win.EditorNumerico();
            this.SuspendLayout();
            // 
            // Nombre
            // 
            this.Nombre.Etiqueta.Texto = "Nombre";
            this.Nombre.Location = new System.Drawing.Point(18, 18);
            this.Nombre.Name = "Nombre";
            this.Nombre.Size = new System.Drawing.Size(283, 20);
            this.Nombre.TabIndex = 0;
            // 
            // Tipo
            // 
            this.Tipo.Etiqueta.Texto = "Tipo";
            this.Tipo.Location = new System.Drawing.Point(18, 44);
            this.Tipo.Name = "Tipo";
            this.Tipo.Size = new System.Drawing.Size(283, 20);
            this.Tipo.TabIndex = 1;
            // 
            // Direccion
            // 
            this.Direccion.Etiqueta.Texto = "Dirección";
            this.Direccion.Location = new System.Drawing.Point(18, 70);
            this.Direccion.Name = "Direccion";
            this.Direccion.Size = new System.Drawing.Size(283, 20);
            this.Direccion.TabIndex = 2;
            // 
            // Longitud
            // 
            this.Longitud.Estilo = Binapsis.Presentacion.Editores.Win.Estilo.IntegerEdit;
            this.Longitud.Etiqueta.Texto = "Longitud";
            this.Longitud.Location = new System.Drawing.Point(18, 96);
            this.Longitud.Name = "Longitud";
            this.Longitud.Size = new System.Drawing.Size(283, 20);
            this.Longitud.TabIndex = 3;
            // 
            // VistaParametro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Longitud);
            this.Controls.Add(this.Direccion);
            this.Controls.Add(this.Tipo);
            this.Controls.Add(this.Nombre);
            this.Name = "VistaParametro";
            this.Size = new System.Drawing.Size(324, 145);
            this.ResumeLayout(false);

        }

        #endregion

        private Binapsis.Presentacion.Editores.Win.EditorTexto Nombre;
        private Binapsis.Presentacion.Editores.Win.EditorTexto Tipo;
        private Binapsis.Presentacion.Editores.Win.EditorTexto Direccion;
        private Binapsis.Presentacion.Editores.Win.EditorNumerico Longitud;
    }
}
