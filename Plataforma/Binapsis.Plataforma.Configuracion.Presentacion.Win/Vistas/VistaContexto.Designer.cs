namespace Binapsis.Plataforma.Configuracion.Presentacion.Win.Vistas
{
    partial class VistaContexto
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
            this.Url = new Binapsis.Presentacion.Editores.Win.EditorTexto();
            this.SuspendLayout();
            // 
            // Nombre
            // 
            this.Nombre.Etiqueta.Texto = "Nombre";
            this.Nombre.Location = new System.Drawing.Point(22, 20);
            this.Nombre.Name = "Nombre";
            this.Nombre.Size = new System.Drawing.Size(328, 20);
            this.Nombre.TabIndex = 0;
            // 
            // Url
            // 
            this.Url.Etiqueta.Texto = "Url";
            this.Url.Location = new System.Drawing.Point(22, 46);
            this.Url.Name = "Url";
            this.Url.Size = new System.Drawing.Size(328, 20);
            this.Url.TabIndex = 1;
            // 
            // VistaContexto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Url);
            this.Controls.Add(this.Nombre);
            this.Name = "VistaContexto";
            this.Size = new System.Drawing.Size(370, 93);
            this.ResumeLayout(false);

        }

        #endregion

        private Binapsis.Presentacion.Editores.Win.EditorTexto Nombre;
        private Binapsis.Presentacion.Editores.Win.EditorTexto Url;
    }
}
