namespace Binapsis.Plataforma.Configuracion.Win.Vistas
{
    partial class VistaColumna
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
            this.Nombre = new Binapsis.Presentacion.Win.EditorTexto();
            this.Propiedad = new Binapsis.Presentacion.Win.EditorTexto();
            this.ClavePrincipal = new Binapsis.Presentacion.Win.EditorBoolean();
            this.SuspendLayout();
            // 
            // Nombre
            // 
            this.Nombre.Etiqueta.Texto = "Nombre";
            this.Nombre.Location = new System.Drawing.Point(30, 26);
            this.Nombre.Name = "Nombre";
            this.Nombre.Size = new System.Drawing.Size(286, 20);
            this.Nombre.TabIndex = 0;
            // 
            // Propiedad
            // 
            this.Propiedad.Etiqueta.Texto = "Propiedad";
            this.Propiedad.Location = new System.Drawing.Point(30, 52);
            this.Propiedad.Name = "Propiedad";
            this.Propiedad.Size = new System.Drawing.Size(286, 20);
            this.Propiedad.TabIndex = 1;
            // 
            // ClavePrincipal
            // 
            this.ClavePrincipal.Estilo = Binapsis.Presentacion.Win.Estilo.CheckEdit;
            this.ClavePrincipal.Etiqueta.Texto = "Clave principal";
            this.ClavePrincipal.Etiqueta.Visible = false;
            this.ClavePrincipal.Location = new System.Drawing.Point(108, 78);
            this.ClavePrincipal.Name = "ClavePrincipal";
            this.ClavePrincipal.Size = new System.Drawing.Size(160, 18);
            this.ClavePrincipal.TabIndex = 2;
            this.ClavePrincipal.Texto = "Clave principal";
            // 
            // VistaColumna
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ClavePrincipal);
            this.Controls.Add(this.Propiedad);
            this.Controls.Add(this.Nombre);
            this.Name = "VistaColumna";
            this.Size = new System.Drawing.Size(346, 124);
            this.UsarReflexion = false;
            this.ResumeLayout(false);

        }

        #endregion

        private Presentacion.Win.EditorTexto Nombre;
        private Presentacion.Win.EditorTexto Propiedad;
        private Presentacion.Win.EditorBoolean ClavePrincipal;
    }
}
