namespace Binapsis.Plataforma.Configuracion.Win.Vistas
{
    partial class VistaConexion
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
            this.CadenaConexion = new Binapsis.Presentacion.Win.EditorTexto();
            this.SuspendLayout();
            // 
            // Nombre
            // 
            this.Nombre.Etiqueta.Ancho = 100;
            this.Nombre.Etiqueta.Texto = "Nombre";
            this.Nombre.Location = new System.Drawing.Point(36, 24);
            this.Nombre.Name = "Nombre";
            this.Nombre.Size = new System.Drawing.Size(347, 20);
            this.Nombre.TabIndex = 0;
            // 
            // CadenaConexion
            // 
            this.CadenaConexion.Estilo = Binapsis.Presentacion.Win.Estilo.TextMemoEdit;
            this.CadenaConexion.Etiqueta.Ancho = 100;
            this.CadenaConexion.Etiqueta.Texto = "Cadena de conexión";
            this.CadenaConexion.Location = new System.Drawing.Point(36, 50);
            this.CadenaConexion.Name = "CadenaConexion";
            this.CadenaConexion.Size = new System.Drawing.Size(347, 78);
            this.CadenaConexion.TabIndex = 1;
            // 
            // VistaConexion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.CadenaConexion);
            this.Controls.Add(this.Nombre);
            this.Name = "VistaConexion";
            this.Size = new System.Drawing.Size(413, 156);
            this.ResumeLayout(false);

        }

        #endregion

        private Presentacion.Win.EditorTexto Nombre;
        private Presentacion.Win.EditorTexto CadenaConexion;
    }
}
